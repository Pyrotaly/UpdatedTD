using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace UpdatedTD
{
    public interface ISlowable 
    {
        float SpeedPercentageChange { get; set; } // The property you want to modify
    }
}
