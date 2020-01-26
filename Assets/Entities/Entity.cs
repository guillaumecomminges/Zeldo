using UnityEngine;

public class Entity : MonoBehaviour
{

    [SerializeField]
	public string m_name = "name";
	[SerializeField]
	public int m_life = 1;
    private bool m_alive = true;


	public bool IsDead()
	{   
        if(m_life > 0){
            m_alive = true;
        }else{
            m_alive = false;   
        }

		return !m_alive;
	}

	public void TakeDamage(int _damage, Transform _entityPos, bool _isPlayer)
	{
		m_life -= _damage;
        Debug.Log("Life :" + m_life);
        if(m_life > 0)
        {
            if(_isPlayer)
            {
            KnockBackPlayer(_entityPos.position);
            }else{
                KnockBack(_entityPos.position);
            }
        }
	}

    public void KnockBack(Vector3 _entityPos)
    {
        Vector3 knockbackPosition = transform.position + (transform.position - _entityPos).normalized ;
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.MoveTowards(transform.position, knockbackPosition, Time.deltaTime) / 8; 
        Invoke("StopKnock", 0.08f);
    }

    private void StopKnock()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    public void KnockBackPlayer(Vector3 _entityPos)
    {
        Vector3 knockbackPosition = transform.position + (transform.position - _entityPos).normalized *100 ;
        gameObject.GetComponent<Rigidbody2D>().position = Vector2.MoveTowards(transform.position, knockbackPosition, 100 * Time.deltaTime); 
    }

    public string GetName()
    {
        return m_name;
    }
    public int GetLife()
    {
        return m_life;
    }
}