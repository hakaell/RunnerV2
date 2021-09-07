using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    public int value;
    TextMeshPro text;
    void Awake()
    {
        text = GetComponentInChildren<TextMeshPro>();
    }
    void Start()
    {
        text.text ="x"+value.ToString();
    }
}
