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

		private void Awake()
		{
			HideDialog();
		}

		public void DisplayDialog(Dialogue _dial)
		{
			m_CharacterAvatar.sprite = _dial.GetSpeakerAvatar();
			m_Text.text = _dial.GetText();
			m_Nom.text = _dial.GetNom();
			gameObject.SetActive(true);
		}

		public void HideDialog()
		{
			m_CharacterAvatar.sprite = null;
			m_Text.text = null;
			gameObject.SetActive(false);
		}

	}