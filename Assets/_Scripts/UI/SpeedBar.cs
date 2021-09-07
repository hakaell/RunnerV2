using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBar : MonoBehaviour
{
    [SerializeField] SpriteRenderer frontRenderer;
    [SerializeField] PlayerManager _playerManager;
    
    [SerializeField] float speedLimit;
    IEntityController _entityController;
    float spriteValue;
    float firstValue;
    void Awake()
    {
        _entityController = GetComponentInParent<IEntityController>();
    }
    void Start()
    {
        firstValue = _entityController.VerticalSpeed;
        spriteValue = 7 / speedLimit;
        SetValue();
    }
    void Update()
    {
        if (_entityController.VerticalSpeed != firstValue)
        {
           firstValue = Mathf.Lerp(firstValue, _entityController.VerticalSpeed, Time.deltaTime * 10);
           SetValue();  
        }
    }
    void SetValue()
    {
       frontRenderer.size = new Vector2(firstValue * spriteValue, 0.7f);
    }
}

