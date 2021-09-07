using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CollisionController:MonoBehaviour, ICollisionController
{
    IEntityController _IentityController;
    IEntityManager _IentityManager;
    IPlayerSkills _IplayerSkills;
    float goldBugTimer;
    public CollisionController(IEntityController entityController, IEntityManager entityManager)
    {
        _IentityController = entityController;
        _IentityManager = entityManager;
        _IplayerSkills = new PlayerSkills(_IentityController);
    }
    public void Control(Collider collider)
    {
        //COIL
        if (collider.GetComponentInParent<Coil>())
        {
            switch (collider.GetComponentInParent<Coil>().CurrentState)
            {
                case Coil.State.Red:
                    _IplayerSkills.RemoveSpeed(10);
                    if (_IentityController.transform.GetComponent<PlayerController>())
                    {
                        SoundManager.Instance.PlaySlowerSound();
                    }
                    break;

                case Coil.State.Blue:
                    _IplayerSkills.AddSpeed(15);
                    if (_IentityController.transform.GetComponent<PlayerController>())
                    {
                        SoundManager.Instance.PlayFasterSounds();
                    }
                    break;
            }
            return;
        }
        ///ALTIN
        if (collider.GetComponent<GemController>())
        {
            if (_IentityController.transform.GetComponent<PlayerController>())
            {
                if (Time.time > goldBugTimer + 0.1f)
                {
                    GemController gemController = collider.GetComponent<GemController>();
                    gemController.IsFollow = true;
                    goldBugTimer = Time.time;
                }

            }
        }
        //FINISHLINE
        if (PlayerManager.Instance.currentState == PlayerManager.State.Win)
        {
            if (_IentityController.transform.GetComponent<PlayerController>())
            {
                int point = 0;
                if (collider.GetComponent<FinishLine>()) 
                {
                    point = collider.GetComponent<FinishLine>().value;
                    PlayerManager.Instance.BonusPoint = point;
                }
            }
        }
        //TAGS
        switch (collider.tag)
        {
            case "Skill":
                if (_IentityController.transform.GetComponent<PlayerController>())
                {
                    Destroy(collider.gameObject);
                    _IentityController.IsPower = true;
                }
                break;

            case "SpeedUp":
                _IplayerSkills.AddSpeed(5f);
                if (_IentityController.transform.GetComponent<PlayerController>())
                {
                    SoundManager.Instance.PlayFasterSounds();
                }
                break;

            case "Obstacle":
                _IplayerSkills.RemoveSpeed(5f);
                if (_IentityController.transform.GetComponent<PlayerController>())
                {
                    SoundManager.Instance.PlaySlowerSound();
                }
                break;

            case "FinishLine":
                _IentityManager.SetSlideMOD();
                break;
        }

    }
}
