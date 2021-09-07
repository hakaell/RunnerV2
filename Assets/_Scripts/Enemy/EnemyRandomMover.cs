using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRandomMover : MonoBehaviour
{
    [Range(0.1f, 4f)][SerializeField] float repeatMoveTime;
    float time;
    public int RandomMove()
    {
        if (Time.time > time + repeatMoveTime)
        {
            time = Time.time;
            switch (Random.Range(1, 3))
            {
                case 1:
                    return -1;
                case 2:
                    return 1;
            }
        }
        return 0;
    }
}
