using UnityEngine;


public class IAEntityLife : StateMachineBehaviour
{
	bool dead = false;
	public override void OnStateUpdate(Animator _Animator, AnimatorStateInfo _AnimatorStateInfo, int _LayerIndex) 
		{
			dead = _Animator.gameObject.GetComponentInParent<Entity>().IsDead() ;
			_Animator.SetBool("kaput", dead);
			Debug.Log("mort ? " + dead);
			
		}

}