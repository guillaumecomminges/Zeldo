using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agress : MonoBehaviour {

	[SerializeField]
	private float m_range = 1f;

	[SerializeField]
	public int maxObjectsHit = 1;

	[SerializeField]
	public int m_degats = 1;
    public Collider2D[] objectsHit;
    public LayerMask selectObjectsToHit;

	private bool m_canHit;

	private void Awake()
	{
		objectsHit = new Collider2D[maxObjectsHit];
		selectObjectsToHit = LayerMask.GetMask("Player");
		m_canHit = true;
	}


    private void Update()
	{
		Physics2D.OverlapCircleNonAlloc(transform.position, m_range, objectsHit, selectObjectsToHit);

            if(objectsHit.Length > 0)  
            {
				Collider2D Oldhit = null;
                foreach(Collider2D hit in objectsHit)
                {
					if(hit != null && hit != Oldhit /*&& m_canHit*/){
						//Debug.Log(hit.gameObject.GetComponent<Entity>().GetName() + ", pv :" + hit.gameObject.GetComponent<Entity>().GetLife());
						hit.gameObject.GetComponent<Entity>().TakeDamage(m_degats, transform, true);
						objectsHit = new Collider2D[maxObjectsHit];
						//m_canHit = false;
						//Invoke("ResetHit", 0.5f);
					}
                }
            }
	}

	private void ResetHit(){
		m_canHit = true;
	}
    
}