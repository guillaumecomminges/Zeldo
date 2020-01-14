using UnityEngine;
	public class Movement : MonoBehaviour
	{
			[SerializeField]
			float m_speed=10.0f;
			private Rigidbody2D m_rigidbody = null;

			private	void Awake()
			{
				m_rigidbody = GetComponent<Rigidbody2D>();
				m_rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
			}

			private void Update()
			{
				m_rigidbody.velocity = new Vector3(Mathf.Lerp(0, Input.GetAxisRaw("Horizontal")* m_speed, 0.5f),
                                                Mathf.Lerp(0, Input.GetAxisRaw("Vertical")* m_speed, 0.5f));	
			}
	}