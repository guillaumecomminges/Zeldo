using UnityEngine;
public class character : MonoBehaviour
{
	private Animator m_Animator = null;
	private bool m_IsWalking;


	private void Awake()
	{
		m_Animator = GetComponent<Animator>();
	}

	private void Update()
	{

		///////////////////////////Animation/////////////////////////

		if(( Input.GetKeyDown(KeyCode.DownArrow) && Input.GetAxisRaw("Horizontal") == 0)  || (Input.GetAxisRaw("Vertical") < 0 && (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))))
		{
			m_Animator.SetTrigger("Down");
		}
		if(( Input.GetKeyDown(KeyCode.UpArrow) && Input.GetAxisRaw("Horizontal") == 0) || (Input.GetAxisRaw("Vertical") > 0 &&  (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow))))
		{
			m_Animator.SetTrigger("Up");
		}
		if(( Input.GetKeyDown(KeyCode.LeftArrow) && Input.GetAxisRaw("Vertical") == 0)|| (Input.GetAxisRaw("Horizontal") < 0 &&  (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))))
		{
			m_Animator.SetTrigger("Left");
		}
		if(( Input.GetKeyDown(KeyCode.RightArrow) && Input.GetAxisRaw("Vertical") == 0) || (Input.GetAxisRaw("Horizontal") > 0 &&  (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))))
		{
			m_Animator.SetTrigger("Right");
		}

		m_IsWalking = true;
		if(Input.GetKey(KeyCode.DownArrow)){}
		else if(Input.GetKey(KeyCode.UpArrow)){}
		else if(Input.GetKey(KeyCode.LeftArrow)){}
		else if(Input.GetKey(KeyCode.RightArrow)){}
		else { m_IsWalking=false; }
		m_Animator.SetBool("is_walking", m_IsWalking);

		/////////////////////////////Interraction//////////////////////////////

		if(Input.GetKeyDown(KeyCode.Space)){
			m_Animator.SetBool("is_attack", true);

		}
		else m_Animator.SetBool("is_attack", false);

	}

}