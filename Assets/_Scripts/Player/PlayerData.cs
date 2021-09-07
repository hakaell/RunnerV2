using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData : MonoBehaviour
{
    [field: SerializeField]
    public float VerticalSpeed { get; set; }

    [field: SerializeField]
    public float BoundX { get; set; }
    public bool IsStopMode { get; set; }
    public bool IsPower { get; set; }
    public Rigidbody rb => GetComponent<Rigidbody>();
}
