using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 direction;
    private int inputInt;

    public int GetMoveInput()
    {
        if (Input.touchCount > 0)
        {
            Touch _touch = Input.GetTouch(0);

            switch (_touch.phase)
            {
                case TouchPhase.Began:
                    startPos = _touch.position;
                    break;
                case TouchPhase.Moved:
                    direction = _touch.position - startPos;
                    if (direction.x > 0)
                    {
                        inputInt = 1;
                        // vector3 eklemesi yap ve playerın x pozisyonunu bir **SAĞ**lane e geçecek kadar değiştir
                    }
                    else
                    {
                        inputInt = -1;
                        // vector3 eklemesi yap ve playerın x pozisyonunu bir **SOL** lane e geçecek kadar değiştir
                    }
                    break;
                case TouchPhase.Ended:
                    inputInt = 0;
                    break;
            }
                
        }
        return inputInt;
    }
}
