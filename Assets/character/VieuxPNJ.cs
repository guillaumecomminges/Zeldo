using UnityEngine;

	public class VieuxPNJ : MonoBehaviour
	{

		private Animator m_Animator = null;
		private int m_random;	
		private float m_timer = 0.0f;

		private float m_seconds = 4.0f;
			
		private void Awake() 
		{
			m_Animator = GetComponent<Animator>();
		}

		private void Update()
		{

			m_timer += Time.deltaTime;
			//Debug.Log("temps : " + m_timer);
			
			if(m_timer > m_seconds)
			{
				m_random = Random.Range(1,5);
				m_timer = 0.0f;
			}

			if(m_random == 1)
			{
				m_Animator.SetTrigger("Down");
			}
			else if(m_random == 2)
			{
				m_Animator.SetTrigger("Up");
			}
			else if(m_random == 3)
			{
				m_Animator.SetTrigger("Left");
			}
			else if(m_random == 4)
			{
				m_Animator.SetTrigger("Right");
			}

			m_random = 0;
		}

		public void Interract(){
			Debug.Log("AHAHA TU as REUSSI !!!");
		}
 	}