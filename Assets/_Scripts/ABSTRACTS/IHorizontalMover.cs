using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHorizontalMover 
{
    IEnumerator Active(float inputHorValue);
    void SetStartEnum(int index);
    HorizontalMover.CurrentState GetState();
}
