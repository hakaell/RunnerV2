using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObjects", menuName = "Create ObjectData/Create TeslaCoilData", order = 1)]
public class TeslaCoilData : ScriptableObject
{
    [field: SerializeField] public Material GlassMaterial { get; private set; }
    [field: SerializeField] public Material BodyMaterial { get; private set; }
    [field: SerializeField] public Material ConMaterial { get; private set; }
    [field: SerializeField] public Material LightMaterial { get; private set; }
}
