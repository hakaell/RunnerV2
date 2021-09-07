using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Process :MonoBehaviour,IProcess
{
    IAnimationController _animationController;
    IEntityController _entityController;
    IEntityManager _entityManager;
    Animator animator;
    public Process(IEntityController entityController,IEntityManager entityManager)
    {
        _entityManager = entityManager;
        _entityController = entityController;
        animator = _entityController.gameObject.GetComponentInChildren<Animator>();
        _animationController = new AnimationController(animator);
    }
    public void Idle()
    {
        _animationController.Idle();
        _entityController.IsStopMode = true;
    }

    public void Running()
    {
        _animationController.Run();
        _entityController.IsStopMode = false;
    }
    public void InjuredRunning()
    {
        _animationController.InjuredRun();
    }
    public void Slide()
    {
        _animationController.SlideRun();
        if (_animationController._animator.velocity == Vector3.zero)
        {
            _entityManager.SetWinMOD();
        }
    }
    public void GameOver()
    {
        _entityController.IsStopMode = true;
        _animationController.Dead();
    }

    public void Win()
    {
        _entityController.IsStopMode = true;
        _animationController.Dance();
    }
}
