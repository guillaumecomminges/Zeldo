using UnityEngine;

	//[AddComponentMenu("Scripts/IADetectPlayer")]
	public class IAFollow : StateMachineBehaviour
	{

		public override void OnStateUpdate(Animator _Animator, AnimatorStateInfo _AnimatorStateInfo, int _LayerIndex) 
		{
			_Animator.GetComponent<Follow>().UpdateFollow();
		}
	}
