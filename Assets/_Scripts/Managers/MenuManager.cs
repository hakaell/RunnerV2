using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;


public class MenuManager : ASingleton<MenuManager>
{
    public static event System.Action OnStartGame;
    public static event System.Action OnRestartGame;

    [SerializeField] GameObject WinGameCanvas;
    [SerializeField] GameObject LoseGameCanvas;
    [SerializeField] GameObject SkillCanvas;
    [SerializeField] Text GoldText;
    [SerializeField] GameObject NextLevelButton;
    [SerializeField] Text InGameGoldText;

    PlayerManager _playerManager;
    PlayerController _playerController;
    GameManager _gameManager;
    bool activatedMenu,calculateLerp;
    float playerTotalPoint;
    float t;
    int pointer;
    void Awake()
    {
        StartSingleton(this);
        _gameManager = FindObjectOfType<GameManager>();
        _playerManager = FindObjectOfType<PlayerManager>();
        _playerController = FindObjectOfType<PlayerController>();
    }
    void Update()
    {
        InGameGoldText.text = _playerManager.Point.ToString();
        if (calculateLerp)
        {
            CalculateLerp();
        }
        if (activatedMenu) {
            return;
        }
        switch (_playerManager.currentState)
        {
            case PlayerManager.State.Win:
                StartCoroutine(ActivatedWinGameCanvas());
                activatedMenu = true;
                break;

            case PlayerManager.State.GameOver:
                StartCoroutine(ActivatedGameOverCanvas());
                activatedMenu = true;
                break;
        }
        if (_playerController.IsPower)
        {
            SkillCanvas.SetActive(true);
        }
        else
        {
            SkillCanvas.SetActive(false);
        }
    }
    IEnumerator ActivatedWinGameCanvas() 
    {
        yield return new WaitForSeconds(2f);
        CalculatePoint();
        WinGameCanvas.SetActive(true);
        calculateLerp = true;
    }
    IEnumerator ActivatedGameOverCanvas()
    {
        yield return new WaitForSeconds(2f);
        LoseGameCanvas.SetActive(true);
    }
    void CalculatePoint()
    {
        playerTotalPoint = _playerManager.Point * _playerManager.BonusPoint;
    }
    void CalculateLerp()
    {
        pointer = (int) Mathf.Lerp(0f, playerTotalPoint,t);
        t += Time.deltaTime * 0.5f;
        GoldText.text =pointer.ToString();
        if (pointer == playerTotalPoint)
        {
            calculateLerp = false;
            NextLevelButton.SetActive(true);
        }
    }
    public void Play()
    {
        NextLevelButton.SetActive(false);
        OnStartGame?.Invoke();
    }
    public void RestartLevel()
    {
        _gameManager.CreateLevel(false);
        ResetValues();
    }
    public void NextLevel()
    {
        _gameManager.CreateLevel(true);
        ResetValues();
    }
    void ResetValues()
    {
        activatedMenu = false;
        calculateLerp = false;
        pointer = 0;
        t = 0;
    }
}
