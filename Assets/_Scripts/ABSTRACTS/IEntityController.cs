using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEntityController 
{
    GameObject gameObject { get; }
    Rigidbody rb { get; }
    Transform transform { get; }
    float BoundX { get; }
    float VerticalSpeed{ get; set; }
    bool IsStopMode { get; set; }
    bool IsPower { get; set; }
}
