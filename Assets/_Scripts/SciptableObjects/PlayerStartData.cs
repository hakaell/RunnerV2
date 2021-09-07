using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Create PlayerData/Create NewData", order = 2)]
public class PlayerStartData : ScriptableObject
{
    [field: SerializeField] public float VerticalSpeed{ get; private set; }
    [field: SerializeField] public Vector3 Position { get; private set; }
}
