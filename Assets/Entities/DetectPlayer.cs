using UnityEngine;
	public class DetectPlayer : MonoBehaviour
	{
		[SerializeField]
		private float m_sightRange = 3f;

		[SerializeField]
		private Transform m_Character = null;

		public bool IsCHaracterInRange()
		{
			return Vector3.Distance(m_Character.position, transform.position) <= m_sightRange;
		}

		private void OnDrawGizmos()
		{
				Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(transform.position, m_sightRange);
		}
	}