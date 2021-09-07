using UnityEngine;

   public class AnimationController :IAnimationController
   {
      public Animator _animator{ get; set; }
      int IdleID = Animator.StringToHash("Idle");
      int RunningID = Animator.StringToHash("Running");
      int InjuredRunID = Animator.StringToHash("Injured");
      int DeadID = Animator.StringToHash("Dead");
      int DanceID = Animator.StringToHash("Dance");
      int SlideRunID = Animator.StringToHash("SlideRun");
      public AnimationController(Animator animator)
      {
         _animator = animator;
      }
      public void Idle()
      {
         _animator.ResetTrigger(DeadID);
         _animator.ResetTrigger(DanceID);
         _animator.SetTrigger(IdleID);
      }
      public void Run()
      {
         _animator.ResetTrigger(IdleID);
         _animator.SetTrigger(RunningID);
      }
      public void InjuredRun()
      {
         _animator.SetTrigger(InjuredRunID);
      }
      public void Dead()
      {
        _animator.ResetTrigger(InjuredRunID);
        _animator.ResetTrigger(RunningID);
        _animator.SetTrigger(DeadID);
      }
      public void Dance()
      {
        _animator.ResetTrigger(InjuredRunID);
        _animator.ResetTrigger(IdleID);
        _animator.ResetTrigger(RunningID);
        _animator.SetTrigger(DanceID);
      }
      public void SlideRun()
      {
        _animator.SetTrigger(SlideRunID);
      }
}

