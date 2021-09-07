using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HorizontalMover : MonoBehaviour, IHorizontalMover
{
    IEntityController _entityController;
    public CurrentState currentState;
    public enum CurrentState
    {
        Center,
        Left,
        Right
    }
    float leftPosX, rightPosX, currentPosX;
    float delayTime;
    public HorizontalMover(IEntityController entityController)
    {
        _entityController = entityController;
        leftPosX = -entityController.BoundX;
        rightPosX = entityController.BoundX;
        currentPosX = _entityController.transform.position.x;
    }
    public void SetStartEnum(int index)
    {
        switch (index)
        {
            case 0:
                currentState = CurrentState.Left;
                break;
            case 1:
                currentState = CurrentState.Right;
                break;
            case 2:
                currentState = CurrentState.Center;
                break;
        }
    }
    public CurrentState GetState()
    {
        return currentState;
    }
    public IEnumerator Active(float inputHorValue)
    {
        float y = _entityController.transform.position.y;
        float z = _entityController.transform.position.z;
        if (Time.time > delayTime + 0.4)
        {
            switch (inputHorValue)
            {
                //SOLA
                case -1:
                    switch (currentState)
                    {
                        case CurrentState.Center:
                            currentState = CurrentState.Left;
                            currentPosX = leftPosX;
                            break;
                        case CurrentState.Right:
                            currentState = CurrentState.Center;
                            currentPosX = 0;
                            break;
                    }
                    delayTime = Time.time;
                    break;
                //SAÐA
                case 1:
                    switch (currentState)
                    {
                        case CurrentState.Center:
                            currentState = CurrentState.Right;
                            currentPosX = rightPosX;
                            break;
                        case CurrentState.Left:
                            currentState = CurrentState.Center;
                            currentPosX = 0;
                            break;

                    }
                    delayTime = Time.time;
                    break;
            }
        }
        _entityController.transform.position = Vector3.Lerp(_entityController.transform.position, new Vector3(currentPosX, y, z), Time.deltaTime * 10);
        yield return null;
    }
}

