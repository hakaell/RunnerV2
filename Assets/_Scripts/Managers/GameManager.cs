using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : ASingleton<GameManager>
{
    [SerializeField] PlayerStartData DataPlayer;
    [SerializeField] PlayerController Player;
    [SerializeField] GameObject PlayerBody;
    [SerializeField] List<GameObject> LevelList;
    
    public int Level { get; private set; }
    void Awake()
    {
        StartSingleton(this);
    }
    void Start()
    {
        Level = 0;
        ResetPlayer();
    }
    public void CreateLevel(bool IsNextLevel)
    {
        if (IsNextLevel)
        {
            Level++;
        }
        Destroy(FindObjectOfType<LevelController>().gameObject);
        Instantiate(LevelList[Level], transform.position, transform.rotation);
        ResetPlayer();
    }
    void ResetPlayer()
    {
        PlayerManager.Instance.SetIdleMOD();
        Player.transform.position = DataPlayer.Position;
        PlayerBody.transform.position = Player.transform.position;
        Player.currentState = PlayerController.CurrentState.Center;
        Player.VerticalSpeed = DataPlayer.VerticalSpeed;
        Player.IsPower = false;
    }
}
