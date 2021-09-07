using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProcess
{
    void Idle();
    void Running();
    void InjuredRunning();
    void Slide();
    void GameOver();
    void Win();
}
