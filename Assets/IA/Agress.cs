using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agress : MonoBehaviour {


    [SerializeField]
	private Dialogue m_dialog = null;

		[SerializeField]
	private DialogBox m_dialogBox = null;



    private void OnTriggerEnter2D(Collider2D collider)
    {
			PlayDialog();
    }

    private void PlayDialog()
		{
			m_dialogBox.DisplayDialog(m_dialog);		
		}
    
}