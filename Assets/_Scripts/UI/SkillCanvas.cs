using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCanvas : MonoBehaviour
{
    [SerializeField] List<GameObject> buttons;
    [SerializeField] GameObject obj;
    PlayerController _playerController;
    void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        switch (_playerController.currentState)
        {
            case PlayerController.CurrentState.Center:
                buttons[0].SetActive(true);
                buttons[1].SetActive(false);
                buttons[2].SetActive(true);
                break;
            case PlayerController.CurrentState.Left:
                buttons[0].SetActive(false);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                break;
            case PlayerController.CurrentState.Right:
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
                buttons[2].SetActive(false);
                break;
        }
    }
    public void CreateObstacleLeft()
    {
        Spawn(-_playerController.BoundX);
    }
    public void CreateObstacleRight()
    {
        Spawn(_playerController.BoundX);
    }
    public  void CreateObstacleCenter()
    {
        Spawn(0);
    }
    void Spawn(float x) {

        Transform parent = FindObjectOfType<LevelController>().transform;
        float y = 5f;
        float z = _playerController.transform.position.z + 7;

        Vector3 pos = new Vector3(x, y, z);
        Instantiate(obj, pos, transform.rotation,parent);
        _playerController.IsPower = false;
    }
}
