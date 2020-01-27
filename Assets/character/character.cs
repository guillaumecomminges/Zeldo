using UnityEngine;
 using System.Collections;
public class character : MonoBehaviour
{
	private Animator m_Animator = null;
	private bool m_IsWalking;

	[SerializeField]
	private float m_swordRange = 2f;

	[SerializeField]
	public int maxObjectsHit = 1;

	[SerializeField]
	public int m_degats = 1;
    public Collider2D[] objectsHit;
    public LayerMask selectObjectsToHit;

	[SerializeField]	
	Dialogue m_gmeOver;

	[SerializeField]
	private DialogBox m_dialogBox = null;

	private bool m_fini = false;

	float life;
	public GUIStyle myGUIStyle;

	private void Awake()
	{
		m_Animator = GetComponent<Animator>();
		objectsHit = new Collider2D[maxObjectsHit];
		selectObjectsToHit = LayerMask.GetMask("EnemyAndDestructibles");
	}

	private void Update()
	{

		if(!transform.gameObject.GetComponentInParent<Entity>().IsDead()){
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
				
				/// combat directionnel en cône (WIP)
				/*
				Vector3 startVec = transform.position;
		
				RaycastHit hitInfo;
				Vector3 rayDirection = Vector3.right;
				Physics2D.OverlapCircleNonAlloc(transform.position, m_swordRange, objectsHit, selectObjectsToHit);  

				
				if ((Vector3.Angle(rayDirection, startVec)) < 90 &&
					Physics.Raycast(startVec, rayDirection, out hitInfo, Mathf.Infinity, selectObjectsToHit))
				{ 
					
					Debug.Log(hitInfo.collider.name);
					if(hitInfo.collider.gameObject != null)
					{
						Debug.Log("je tappe");
					}
				}else{
					Debug.Log("Je tappe pas :(");
				}*/

				
				Physics2D.OverlapCircleNonAlloc(transform.position, m_swordRange, objectsHit, selectObjectsToHit);

				if(objectsHit.Length > 0)  
				{
					Collider2D Oldhit = null;
					foreach(Collider2D hit in objectsHit)
					{
						if(hit != null && hit != Oldhit){
							Debug.Log(hit.gameObject.GetComponent<Entity>().GetName() + ", pv :" + hit.gameObject.GetComponent<Entity>().GetLife());
							hit.gameObject.GetComponent<Entity>().TakeDamage(m_degats, transform, false);
							Oldhit = hit;
							
						}
					}
					objectsHit = new Collider2D[maxObjectsHit];
				}
			}
			else m_Animator.SetBool("is_attack", false);

		}else{
			if(!m_fini){
				Invoke("GameOver", 0.5f);
				m_fini = true;
			}
		
		
		}
		life = transform.gameObject.GetComponentInParent<Entity>().GetLife();
		if(life <= 0){
			life = 0;
		}
		
	}

	private void GameOver()
	{
		m_dialogBox.DisplayDialog(m_gmeOver);
	}

	private void OnGUI () {
 
	//For example you have 100 life’s maximum.
	
	GUI.Box(new Rect(10f, 10f, 0.001f * Screen.width * life,  0.1f * Screen.height), "LIFE : " +  life, myGUIStyle);
 
 }
}