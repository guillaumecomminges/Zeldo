using UnityEngine;

[CreateAssetMenu]
	public class Dialogue : ScriptableObject 
	{
		[SerializeField, TextArea]
		private string m_Text = string.Empty;
		[SerializeField]
		private string m_Nom = string.Empty;

		[SerializeField]
		private Sprite m_SpeakerAvatar = null;

		[SerializeField]
		private Dialogue m_nextDialog;

		public string GetText()
		{
			return m_Text;
		}

		public string GetNom()
		{
			return m_Nom;
		}

		public Sprite GetSpeakerAvatar()
		{
			return m_SpeakerAvatar;
		}

		public Dialogue GetNextDialog()
		{
			return m_nextDialog;
		}

		public void Update()
		{
			
		}
	}