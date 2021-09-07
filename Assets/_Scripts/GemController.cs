using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GemController : MonoBehaviour
{
    public bool IsFollow;
    bool selectedPoint;
    float distance;
    PlayerController _playerController;
    void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        float x = _playerController.transform.position.x;
        float y = _playerController.transform.position.y + 0.5f;
        float z = _playerController.transform.position.z;
        
        if (IsFollow)
        {
            if (!selectedPoint)
            {
                SoundManager.Instance.PlayCollectableSound();
                PlayerManager.Instance.Point += 10;
                selectedPoint = true;
            }
            transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.001f, 0.001f, 0.001f), Time.deltaTime * 7);
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, 10f, transform.position.z), Time.deltaTime);
        }
        if (PlayerManager.Instance.currentState == PlayerManager.State.Win)
        {
            Destroy(this.gameObject);
        }
    }
   

}
