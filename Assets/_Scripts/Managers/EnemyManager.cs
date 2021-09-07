using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class EnemyManager : AManager,IEntityManager
{
    IEntityController _entityController;
    IProcess _process;
    PlayerParticle _playerParticle;
    void Awake()
    {
        _playerParticle = GetComponentInChildren<PlayerParticle>();
        _entityController = GetComponent<IEntityController>();
        _process = new Process(_entityController,this);
    }
    void OnEnable()
    {
        MenuManager.OnStartGame += SetRunningMOD;
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
                _process.GameOver();
                break;
            case State.Win:
                _process.Win();
                break;
        }
        if (currentState == State.Running && _entityController.VerticalSpeed >= _playerParticle.superRunBoundValue)
        {
            _playerParticle.superRunParticle.Play();
        }
        else
        {
            _playerParticle.superRunParticle.Stop();
        }
    }

}
