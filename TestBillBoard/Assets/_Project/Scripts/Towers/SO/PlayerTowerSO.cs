using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    [CreateAssetMenu(fileName = "New Tower", menuName = "Tower/New Player Tower")]
    public class PlayerTowerSO : BaseTowerSO
    {
        [Header("Information for Player")]
        public int TowerPrice;
        public int Height = 1;
        public int Width = 1;

        [TextArea(5, 10)]
        public string TowerDescription;

        public List<Vector3Int> CoordinatesTowerTakesUp(Vector3Int tileCooridnatePlayerClicked, Directions dir)
        {
            List<Vector3Int> coordinatesTowerTakesUp = new List<Vector3Int>();

            if (Height == Width)
            {
                for (int x = 0; x < Width; x++)
                {
                    for (int z = 0; z < Height; z++)
                    {
                        coordinatesTowerTakesUp.Add(tileCooridnatePlayerClicked + new Vector3Int(x, 0, z));
                    }
                }

                dir = Directions.Down;

                return coordinatesTowerTakesUp;
            }

            switch (dir)
            {
                case Directions.Down:
                    for (int x = 0; x < Width; x++)
                    {
                        for (int z = 0; z < Height; z++)
                        {
                            coordinatesTowerTakesUp.Add(tileCooridnatePlayerClicked + new Vector3Int(x, 0, z));
                        }
                    }
                    break;
                case Directions.Left:
                    for (int x = 0; x < Height; x++)
                    {
                        for (int z = 0; z < Width; z++)
                        {
                            coordinatesTowerTakesUp.Add(tileCooridnatePlayerClicked + new Vector3Int(x, 0, z));
                        }
                    }
                    break;
                case Directions.Up:
                    for (int x = 0; x < Width; x++)
                    {
                        for (int z = 0; z < Height; z++)
                        {
                            coordinatesTowerTakesUp.Add(tileCooridnatePlayerClicked - new Vector3Int(x, 0, -z));
                        }
                    }
                    break;
                case Directions.Right:
                    for (int x = 0; x < Height; x++)
                    {
                        for (int z = 0; z < Width; z++)
                        {
                            coordinatesTowerTakesUp.Add(tileCooridnatePlayerClicked - new Vector3Int(-x, 0, z));
                        }
                    }
                    break;
                default:
                    break;
            }

            return coordinatesTowerTakesUp;
        }

        public static Directions GetNextDir(Directions dir)
        {
            switch (dir)
            {
                default:
                case Directions.Down:
                    return Directions.Left;
                case Directions.Left:
                    return Directions.Up;
                case Directions.Up:
                    return Directions.Right;
                case Directions.Right:
                    return Directions.Down;
            }
        }

        public enum Directions
        {
            Down,
            Left,
            Up,
            Right
        }
    }
}
