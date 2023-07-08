using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace UpdatedTD
{
    public class CubePainter : EditorWindow
    {
        private GameObject cubePrefab;
        private bool enablePainting = false;
        private bool useDragSpawn = true; // Toggle option for drag spawn or single click spawn
        private int restrictedY = 0;
        private Vector3 startDragPosition;
        private Vector3 endDragPosition;

        [MenuItem("Window/Cube Painter")]
        public static void ShowWindow()
        {
            EditorWindow.GetWindow(typeof(CubePainter));
        }

        private void OnGUI()
        {
            GUILayout.Label("Cube Painter", EditorStyles.boldLabel);
            cubePrefab = EditorGUILayout.ObjectField("Cube Prefab", cubePrefab, typeof(GameObject), false) as GameObject;
            restrictedY = EditorGUILayout.IntField("Restricted Y", restrictedY);

            enablePainting = GUILayout.Toggle(enablePainting, "Enable Painting");
            useDragSpawn = GUILayout.Toggle(useDragSpawn, "Use Drag Spawn");

            if (enablePainting)
            {
                SceneView.duringSceneGui += OnSceneGUI;
            }
            else
            {
                SceneView.duringSceneGui -= OnSceneGUI;
                return;
            }
        }

        private void OnSceneGUI(SceneView sceneView)
        {
            Event e = Event.current;

            if (useDragSpawn)
            {
                if (e.type == EventType.MouseDown && e.button == 0)
                {
                    startDragPosition = GetMouseWorldPosition(e.mousePosition);

                    if (IsPositionOccupied(startDragPosition))
                    {
                        Debug.Log("Position is occupied.");
                        return;
                    }

                    enablePainting = true;
                    e.Use();
                }
                else if (e.type == EventType.MouseDrag && e.button == 0 && enablePainting)
                {
                    endDragPosition = GetMouseWorldPosition(e.mousePosition);

                    if (IsPositionOccupied(endDragPosition))
                    {
                        Debug.Log("Position is occupied.");
                        return;
                    }

                    PaintBlocksInArea(startDragPosition, endDragPosition);
                    e.Use();
                }
                else if (e.type == EventType.MouseUp && e.button == 0)
                {
                    enablePainting = false;
                    e.Use();
                }

                DrawAreaHighlight(startDragPosition, endDragPosition);
            }
            else
            {
                if (e.type == EventType.MouseDown && e.button == 0)
                {
                    Ray ray = HandleUtility.GUIPointToWorldRay(e.mousePosition);
                    Vector3 position = ray.origin + ray.direction * (restrictedY - ray.origin.y) / ray.direction.y;

                    if (Mathf.RoundToInt(position.y) != restrictedY)
                    {
                        Debug.Log("Cannot place block at this Y-axis value.");
                        return;
                    }

                    if (!IsPositionOccupied(position))
                    {
                        if (cubePrefab != null)
                        {
                            GameObject cube = PrefabUtility.InstantiatePrefab(cubePrefab) as GameObject;
                            cube.transform.position = RoundPositionToNearestInt(position);
                            TileDictionary.tilesDictionary.Add(cube.transform.position, cube);
                            Undo.RegisterCreatedObjectUndo(cube, "Paint Cube");
                            Debug.Log("Cube spawned at position: " + cube.transform.position);
                        }
                        else
                        {
                            Debug.Log("Cube Prefab is not assigned.");
                        }
                    }
                    else
                    {
                        Debug.Log("Position is occupied.");
                    }

                    e.Use();
                }
            }
        }

        private Vector3 GetMouseWorldPosition(Vector2 mousePosition)
        {
            Ray ray = HandleUtility.GUIPointToWorldRay(mousePosition);

            float distance = Mathf.Abs((restrictedY - ray.origin.y) / ray.direction.y);
            Vector3 intersectionPoint = ray.origin + ray.direction * distance;

            intersectionPoint = RoundPositionToNearestInt(intersectionPoint);

            return intersectionPoint;
        }

        private Vector3 RoundPositionToNearestInt(Vector3 position)
        {
            return new Vector3(Mathf.RoundToInt(position.x), Mathf.RoundToInt(position.y), Mathf.RoundToInt(position.z));
        }

        private bool IsPositionOccupied(Vector3 position)
        {
            Collider[] colliders = Physics.OverlapBox(position, Vector3.one * 0.4f);

            foreach (var collider in colliders)
            {
                if (collider.gameObject != null && collider.gameObject.CompareTag("Cube"))
                {
                    return true;
                }
            }

            return false;
        }

        private void DrawAreaHighlight(Vector3 startPosition, Vector3 endPosition)
        {
            if (startPosition == Vector3.zero || endPosition == Vector3.zero)
                return;

            Handles.zTest = UnityEngine.Rendering.CompareFunction.LessEqual;
            Handles.color = new Color(0.5f, 0.5f, 1f, 0.2f);
            Handles.DrawSolidRectangleWithOutline(GetAreaRect(startPosition, endPosition), new Color(0.5f, 0.5f, 1f, 0.2f), new Color(0.5f, 0.5f, 1f));

            Handles.color = new Color(0.5f, 0.5f, 1f, 0.5f);
            Handles.DrawWireCube(GetAreaCenter(startPosition, endPosition), GetAreaSize(startPosition, endPosition));
        }

        private Rect GetAreaRect(Vector3 startPosition, Vector3 endPosition)
        {
            Vector3 min = new Vector3(Mathf.Min(startPosition.x, endPosition.x), Mathf.Min(startPosition.y, endPosition.y), Mathf.Min(startPosition.z, endPosition.z));
            Vector3 max = new Vector3(Mathf.Max(startPosition.x, endPosition.x), Mathf.Max(startPosition.y, endPosition.y), Mathf.Max(startPosition.z, endPosition.z));

            return new Rect(min.x, min.z, max.x - min.x, max.z - min.z);
        }

        private Vector3 GetAreaCenter(Vector3 startPosition, Vector3 endPosition)
        {
            Vector3 min = new Vector3(Mathf.Min(startPosition.x, endPosition.x), Mathf.Min(startPosition.y, endPosition.y), Mathf.Min(startPosition.z, endPosition.z));
            Vector3 max = new Vector3(Mathf.Max(startPosition.x, endPosition.x), Mathf.Max(startPosition.y, endPosition.y), Mathf.Max(startPosition.z, endPosition.z));

            return new Vector3((min.x + max.x) * 0.5f, (min.y + max.y) * 0.5f, (min.z + max.z) * 0.5f);
        }

        private Vector3 GetAreaSize(Vector3 startPosition, Vector3 endPosition)
        {
            Vector3 min = new Vector3(Mathf.Min(startPosition.x, endPosition.x), Mathf.Min(startPosition.y, endPosition.y), Mathf.Min(startPosition.z, endPosition.z));
            Vector3 max = new Vector3(Mathf.Max(startPosition.x, endPosition.x), Mathf.Max(startPosition.y, endPosition.y), Mathf.Max(startPosition.z, endPosition.z));

            return new Vector3(max.x - min.x, max.y - min.y, max.z - min.z);
        }

        private void PaintBlocksInArea(Vector3 startPosition, Vector3 endPosition)
        {
            Vector3 min = new Vector3(Mathf.Min(startPosition.x, endPosition.x), Mathf.Min(startPosition.y, endPosition.y), Mathf.Min(startPosition.z, endPosition.z));
            Vector3 max = new Vector3(Mathf.Max(startPosition.x, endPosition.x), Mathf.Max(startPosition.y, endPosition.y), Mathf.Max(startPosition.z, endPosition.z));

            for (int x = Mathf.RoundToInt(min.x); x <= Mathf.RoundToInt(max.x); x++)
            {
                for (int y = Mathf.RoundToInt(min.y); y <= Mathf.RoundToInt(max.y); y++)
                {
                    for (int z = Mathf.RoundToInt(min.z); z <= Mathf.RoundToInt(max.z); z++)
                    {
                        Vector3 position = new Vector3(x, y, z);

                        if (!IsPositionOccupied(position))
                        {
                            if (cubePrefab != null)
                            {
                                GameObject cube = PrefabUtility.InstantiatePrefab(cubePrefab) as GameObject;
                                cube.transform.position = position;
                                TileDictionary.tilesDictionary.Add(cube.transform.position, cube);  // Add to dictionary
                                Undo.RegisterCreatedObjectUndo(cube, "Paint Cube");
                                Debug.Log("Cube spawned at position: " + cube.transform.position);
                            }
                            else
                            {
                                Debug.Log("Cube Prefab is not assigned.");
                            }
                        }
                        else
                        {
                            Debug.Log("Position is occupied.");
                        }
                    }
                }
            }
        }
    }
}
