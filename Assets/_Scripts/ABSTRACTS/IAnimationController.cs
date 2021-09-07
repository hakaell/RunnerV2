using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimationController
{
    public Animator _animator { get; set; }
    public void Idle();
    public void Run();
    public void InjuredRun();
    public void Dead();
    public void Dance();
    public void SlideRun();
}
