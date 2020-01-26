using UnityEngine;


public class IAPlayerLife : StateMachineBehaviour
{
	bool dead = false;
	public override void OnStateUpdate(Animator _Animator, AnimatorStateInfo _AnimatorStateInfo, int _LayerIndex) 
		{
			if(!dead){
				dead = _Animator.gameObject.GetComponentInParent<Entity>().IsDead() ;
				_Animator.SetBool("kaput", dead);
				Debug.Log("PV : " + _Animator.gameObject.GetComponentInParent<Entity>().GetLife() + " mort ? " + _Animator.gameObject.GetComponentInParent<Entity>().IsDead() );
			}else{
				_Animator.SetBool("kaput", !dead);
			}
		}

}