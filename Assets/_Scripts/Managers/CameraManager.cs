using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraManager : MonoBehaviour
{
    public Camera _camera;
    public PlayerController player;

    public Transform camPos;
    public Transform introCam;
    public Transform follewerCam;
    public Transform superFollewerCam;
    public Transform slideCam;
    public Transform deadCam;
    public Transform finishCam;

    PlayerManager _playerManager;
    void Awake()
    {
        _camera = Camera.main;
        _playerManager = FindObjectOfType<PlayerManager>();
    }
    void LateUpdate()
    {
        CamFollow();
    }
    void CamLerp()
    {
        _camera.transform.localPosition = Vector3.Lerp(_camera.transform.localPosition, Vector3.zero, Time.deltaTime * 3);
        _camera.transform.localRotation = Quaternion.Lerp(_camera.transform.localRotation, Quaternion.identity, Time.deltaTime * 3);
    }
   
    void CamFollow()
    {
        camPos.position = Vector3.Lerp(camPos.position, player.transform.position, Time.deltaTime * 10);
        switch (_playerManager.currentState)
        {
            case PlayerManager.State.Idle:
                if (_camera.transform.parent != introCam)
                {
                    _camera.transform.SetParent(introCam);
                }
                CamLerp();
                break;
            case PlayerManager.State.Running:
                if (_camera.transform.parent != follewerCam)
                {
                    _camera.transform.SetParent(follewerCam);
                }
                CamLerp();
                break;
            case PlayerManager.State.InjuredRunning:
                if (_camera.transform.parent != superFollewerCam)
                {
                    _camera.transform.SetParent(superFollewerCam);
                }
                CamLerp();
                break;
            case PlayerManager.State.Slide:
                if (_camera.transform.parent != slideCam)
                {
                    _camera.transform.SetParent(slideCam);
                }
                CamLerp();
                break;
            case PlayerManager.State.GameOver:
                if (_camera.transform.parent != deadCam)
                {
                    _camera.transform.SetParent(deadCam);
                }
                CamLerp();
                break;
            case PlayerManager.State.Win:
                if (_camera.transform.parent != finishCam)
                {
                    _camera.transform.SetParent(finishCam);
                }
                CamLerp();
                break;
            
        }
    }
}
