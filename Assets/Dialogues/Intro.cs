using UnityEngine;

public class Intro : MonoBehaviour
{
	[SerializeField]
	Dialogue m_intro = null;

	[SerializeField]
	private DialogBox m_dialogBox = null;

	public void Start()
	{
		Invoke("Introduction", 2f);
	}

	private void Introduction()
	{
		m_dialogBox.DisplayDialog(m_intro);
	}
}
