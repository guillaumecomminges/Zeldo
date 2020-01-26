using UnityEngine;


public class IADie : StateMachineBehaviour
{
	public override void OnStateUpdate(Animator _Animator, AnimatorStateInfo _AnimatorStateInfo, int _LayerIndex) 
		{
			Destroy(_Animator.gameObject);
		}

}