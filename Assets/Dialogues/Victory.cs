using UnityEngine;

public class Victory : MonoBehaviour
{
	[SerializeField]
	Dialogue m_winMessage = null;

	[SerializeField]
	private DialogBox m_dialogBox = null;

	private void Update()
	{
		if(transform.gameObject.GetComponent<Entity>().GetLife() <= 0 )
		{
			VictoryClaim();
		}
	}

	private void VictoryClaim()
	{
		m_dialogBox.DisplayDialog(m_winMessage);
	}
}
