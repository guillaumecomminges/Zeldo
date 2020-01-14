using UnityEngine;

	//[AddComponentMenu("Scripts/IADetectPlayer")]
	public class IADetectPlayer : StateMachineBehaviour
	{

		public override void OnStateUpdate(Animator _Animator, AnimatorStateInfo _AnimatorStateInfo, int _LayerIndex) 
		{
			_Animator.SetBool(
				"IsPlayerInRange",
				_Animator.gameObject.GetComponent<DetectPlayer>().IsCHaracterInRange()
				);
		}
	}
