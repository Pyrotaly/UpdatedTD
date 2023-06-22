using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public abstract class BaseTowerAttackHandler : MonoBehaviour
    {
        [SerializeField] protected LayerMask targetLayer;
        protected List<GameObject> targetList = new List<GameObject>();

        protected abstract void Attack();

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.layer == targetLayer)
            {
                targetList.Add(collision.gameObject);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            //TODO : Do i need to compare on exit?
            if (collision.gameObject.layer == targetLayer)
            {
                targetList.Remove(collision.gameObject);
            }
        }
    }
}
