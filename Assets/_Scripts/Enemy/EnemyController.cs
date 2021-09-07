using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController:PlayerData,IEntityController
{
    IEntityManager _IenemyManager;
    ICollisionController _IcollisionController;
    IHorizontalMover _IhorizontalMover;
    IVerticalMover _IverticalMover;
    EnemyRandomMover _enemyRandomMover;
    int horizontalValue;

    public State state;
    public enum State
    {
        Left,
        Right,
        Center
    }
    void Awake()
    {   
        _IhorizontalMover = new HorizontalMover(this);
        _IverticalMover = new VerticalMover(this);
        _IenemyManager = GetComponent<EnemyManager>();
        _enemyRandomMover = GetComponent<EnemyRandomMover>();
        _IcollisionController = new CollisionController(this,_IenemyManager);
    }
    void Start()
    {
        _IhorizontalMover.SetStartEnum((int)(state));
    }
    void Update()
    {
        horizontalValue = _enemyRandomMover.RandomMove();
        if (VerticalSpeed <= 0)
        {
            _IenemyManager.SetGameOverMOD();
        }
    }
    void FixedUpdate()
    {
        if (IsStopMode)
        {
            return;
        }
        StartCoroutine(_IhorizontalMover.Active(horizontalValue));
        _IverticalMover.Active(VerticalSpeed);
    }
    void OnTriggerEnter(Collider collider)
    {
        _IcollisionController.Control(collider);
    }
    void OnCollisionEnter(Collision collision)
    {
        _IcollisionController.Control(collision.collider);
    }
}
