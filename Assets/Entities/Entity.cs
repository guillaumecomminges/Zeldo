using UnityEngine;

public class Entity : MonoBehaviour
{

    [SerializeField]
	public string m_name = "name";
	[SerializeField]
	public float m_lifeMax = 1f;

    [SerializeField]
    public float m_KnockForce = 20f;
    private bool m_alive; 
	private float m_life;
	
	[SerializeField]
	GameObject m_canvas = null;
	RectTransform m_rt = null;
    float m_originLifeWitdh;

    
    private void Awake()
    {
        m_life = m_lifeMax;
        if(m_canvas != null)
        {
            SetCanvasSize();
        }
    }

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
        if(m_life > 0)
        {
            KnockBack(_entityPos.position);
        }
        if(_isPlayer)
        {
            UpdateLifeBar();
        }
	}

    public void KnockBack(Vector3 _entityPos)
    {
        Vector3 knockbackPosition = (_entityPos - transform.position).normalized * 100;
        gameObject.GetComponent<Rigidbody2D>().AddForce(-knockbackPosition * m_KnockForce);
        Debug.Log(transform.position + " " + knockbackPosition);
        Invoke("StopKnock", 0.08f);
    }

    private void StopKnock()
    {
        gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
    public string GetName()
    {
        return m_name;
    }
    public float GetLife()
    {
        return m_life;
    }

    private void SetCanvasSize()
    {
        if(m_canvas != null)
        {
            m_rt = m_canvas.GetComponent<RectTransform>();
            m_originLifeWitdh = m_rt.sizeDelta.x;
        }
    }

    private void UpdateLifeBar()
	{
        if(m_canvas != null)
        {
            if(m_life >= 0){
                m_rt.sizeDelta = new Vector2 (m_originLifeWitdh * (m_life/m_lifeMax), m_rt.sizeDelta.y);
            }
            
        }
	}
}