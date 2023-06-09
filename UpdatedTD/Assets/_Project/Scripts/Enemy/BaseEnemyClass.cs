using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public class BaseEnemyClass : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 2f;

        private int pathIndex = 0;


        private void Update()
        {
            if (pathIndex == LevelHander.Instance.GetPath.Length) 
            { 
                Destroy(gameObject);
                return;
            }

            transform.position = Vector2.MoveTowards(transform.position, LevelHander.Instance.GetPath[pathIndex].position, moveSpeed * Time.deltaTime);

            if (Vector2.Distance(transform.position, LevelHander.Instance.GetPath[pathIndex].position) < 0.1f)
            {
                pathIndex++;
            }
        }
    }
}
