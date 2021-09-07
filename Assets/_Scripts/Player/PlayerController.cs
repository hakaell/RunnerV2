using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : PlayerData, IEntityController
{
    ICollisionController _IcollisionController;
    IEntityManager _IplayerManager;
    IHorizontalMover _IhorizontalMover;
    IVerticalMover _IverticalMover;
    
    PlayerInput _playerInput;
    float inputHorValue;

    public CurrentState currentState;
    public enum CurrentState
    {
        Center,
        Left,
        Right
    }
    void Awake()
    {
        _playerInput = GetComponent<PlayerInput>();
        _IhorizontalMover = new HorizontalMover(this);
        _IverticalMover = new VerticalMover(this);
        _IplayerManager = FindObjectOfType<PlayerManager>();
        _IcollisionController = new CollisionController(this,_IplayerManager);
    }
    void Update()
    {
        currentState = (CurrentState)_IhorizontalMover.GetState();
        inputHorValue = _playerInput.GetMoveInput();
        if (VerticalSpeed <= 0)
        {
            PlayerManager.Instance.SetGameOverMOD();
        }
    }
    void FixedUpdate()
    {
        if (IsStopMode)
        {
            return;
        }
        StartCoroutine(_IhorizontalMover.Active(inputHorValue));
        _IverticalMover.Active(VerticalSpeed);
    }
    void OnCollisionEnter(Collision collision)
    {
        _IcollisionController.Control(collision.collider);
    }
    void OnTriggerEnter(Collider collider)
    {
        _IcollisionController.Control(collider);
    }
}
