using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : IPlayerSkills
{
    IEntityController _entityController;
    public PlayerSkills(IEntityController entityController)
    {
        _entityController = entityController;
    }
    public void AddSpeed(float value)
    {
        _entityController.VerticalSpeed += value;
         Control();
    }
    public void RemoveSpeed(float value)
    {
        _entityController.VerticalSpeed -= value;
        Control();
    }
    void Control()
    {
        if (_entityController.transform.GetComponent<PlayerController>())
        {
            ChangeStatePlayer();
        }
        else
        {
            ChangeStateEnemy();
        }
    }
    void ChangeStatePlayer()
    {
        if (_entityController.VerticalSpeed >= 20)
        {
            PlayerManager.Instance.SetRunningMOD();
        }
        else if(_entityController.VerticalSpeed<20 && _entityController.VerticalSpeed > 0)
        {
            PlayerManager.Instance.SetInjuredRunningMOD();
        }
    }
    void ChangeStateEnemy()
    {
        if (_entityController.VerticalSpeed >= 20)
        {
            _entityController.transform.GetComponent<EnemyManager>().SetRunningMOD();
        }
        else if (_entityController.VerticalSpeed < 20 && _entityController.VerticalSpeed > 0)
        {
            _entityController.transform.GetComponent<EnemyManager>().SetInjuredRunningMOD();
        }
    }
}
