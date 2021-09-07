using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : AManager,IEntityManager
{
    public static PlayerManager Instance;
    public float Point { get; set; }
    public float BonusPoint { get; set; }

    PlayerParticle _playerParticle;
    IEntityController _entityController;
    IProcess _process;
    bool IsGameOver,IsWin,IsSuperRun;
    void Awake()
    {
        _entityController = FindObjectOfType<PlayerController>();
        _playerParticle = _entityController.transform.GetComponentInChildren<PlayerParticle>();
        _process = new Process(_entityController, this);
        StartSingleton();
    }
    void OnEnable()
    {
        MenuManager.OnStartGame += SetRunningMOD;
        MenuManager.OnRestartGame += SetIdleMOD;
    }
    void Start()
    {
        SetIdleMOD();
    }
    void LateUpdate()
    {
        switch (currentState)
        {
            case State.Idle:
                _process.Idle();
                _playerParticle.idleParticle.Play();
                BonusPoint = 0;
                Point = 0;
                IsGameOver = false;
                IsWin = false;
                SoundManager.Instance.PlayBackgroundSound();
                break;
            case State.Running:
                _process.Running();
                break;
            case State.InjuredRunning:
                _process.InjuredRunning();
                break;
            case State.Slide:
                _process.Slide();
                break;
            case State.GameOver:
                if (!IsGameOver)
                {
                    SoundManager.Instance.PlayDeathbellSound();
                    IsGameOver = true;
                }
                _process.GameOver();
                break;
            case State.Win:
                if (!IsWin)
                {
                    SoundManager.Instance.PlayWinSound();
                    IsWin = true;
                }
                _process.Win();
                break;
        }
        if (currentState == State.GameOver)
        {
            SoundManager.Instance.StopBackgroundSound();
        }

        if (currentState == State.Running && _entityController.VerticalSpeed >= _playerParticle.superRunBoundValue)
        {
            if (!IsSuperRun)
            {
                SoundManager.Instance.PlaySuperRunSound();
                IsSuperRun = true;
            }
            _playerParticle.superRunParticle.Play();
        }
        else
        {
            _playerParticle.superRunParticle.Stop();
            IsSuperRun = false;
        }
    }
    void StartSingleton()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}
