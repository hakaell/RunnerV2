using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialDoor : MonoBehaviour
{
    [SerializeField] Vector3 targetPos;
    [SerializeField] float speed;
    Vector3 startPos;
    bool IsBottom;

    void Start()
    {
        startPos = transform.position;
        targetPos = new Vector3(startPos.x, targetPos.y, startPos.z);
    }
    void FixedUpdate()
    {
        if (IsBottom)
        {
            MoveBottom();
        }
        else
        {
            MoveTop();
        }
    }
    void MoveBottom()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.fixedDeltaTime * 10);
        if (transform.position == targetPos)
        {
            IsBottom = false;
        }
    }
    void MoveTop()
    {
        transform.position = Vector3.Lerp(transform.position, startPos, Time.fixedDeltaTime * 10);
        if (transform.position == startPos)
        {
            IsBottom = true;
        }
    }
}
