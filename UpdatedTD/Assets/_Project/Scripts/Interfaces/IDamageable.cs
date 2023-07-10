using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    interface IDamageable
    {
        public float Health { get; set; }

        public void AlterHealth(float healthAlterAmount);
    }
}
