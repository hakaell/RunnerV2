using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterBehaviour : MonoBehaviour
{
    [SerializeField] private float power = 3, scale = 1, timeScale = 1, yOffsetValue = 0.1f;

    private float xOffset, yOffset;

    private MeshFilter mf;

    private void Start()
    {
        mf = GetComponent<MeshFilter>();
        Behave();
    }

    private void Update()
    {
        Behave();
        xOffset += Time.deltaTime * timeScale;
        if (yOffset <= yOffsetValue) yOffset += Time.deltaTime * timeScale;
        if(yOffset >= power) yOffset -= Time.deltaTime * timeScale;
    }

    void Behave()
    {
        Vector3[] vertices = mf.mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i].y = CalculateHeight(vertices[i].x, vertices[i].z) * power;
        }

        mf.mesh.vertices = vertices;
    }

    float CalculateHeight(float x , float y)
    {
        float xCord = x * scale + xOffset;
        float yCord = y * scale + yOffset;

        return Mathf.PerlinNoise(xCord, yCord);
    }
}
