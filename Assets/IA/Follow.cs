using UnityEngine;
	public class Follow : MonoBehaviour
	{
		[SerializeField]
		private float m_Speed = 3f;

		[SerializeField]
		private Transform m_FollowedObject = null;

		[SerializeField]
		private float m_ArrivalDistance = 0.5f;

		public void UpdateFollow()
		{
			if(Vector3.Distance(transform.position, m_FollowedObject.position) > m_ArrivalDistance)
			{
				transform.position = Vector3.MoveTowards
				(
					transform.position, 
					m_FollowedObject.position, 
					m_Speed * Time.deltaTime
				);
			}

		}

	}