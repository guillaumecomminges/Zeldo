using UnityEngine;
using UnityEngine.UI;
	public class DialogBox : MonoBehaviour
	{
		[SerializeField]
		private Image m_CharacterAvatar =null;

		[SerializeField]
		private Text m_Text = null;
		[SerializeField]
		private Text m_Nom = null;
		[SerializeField]
		private Dialogue m_NexDial = null;

		private void Awake()
		{
			HideDialog();
		}

		public void DisplayDialog(Dialogue _dial)
		{
			m_CharacterAvatar.sprite = _dial.GetSpeakerAvatar();
			m_Text.text = _dial.GetText();
			m_Nom.text = _dial.GetNom();
			m_NexDial = _dial.GetNextDialog();
			gameObject.SetActive(true);
			Invoke("HideDialog", 3f);
		}

		public void HideDialog()
		{
			if(m_NexDial != null){
				DisplayDialog(m_NexDial);
			}
			else{
				m_CharacterAvatar.sprite = null;
				m_Text.text = null;
				gameObject.SetActive(false);
			}
		}

	}