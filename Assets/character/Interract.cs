using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interract : MonoBehaviour {


    [SerializeField]
	private Dialogue m_dialog = null;

		[SerializeField]
	private DialogBox m_dialogBox = null;



    private void OnTriggerStay2D(Collider2D collider)
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
			PlayDialog();
            Debug.Log("Je suis vieux!");
		}
    }

    private void PlayDialog()
		{
			m_dialogBox.DisplayDialog(m_dialog);		
		}
    
}