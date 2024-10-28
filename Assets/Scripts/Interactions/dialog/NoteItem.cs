using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class NoteItem : MonoBehaviour, IInteractable
{
    // Start is called before the first frame update
    public Dialog note;
    //public DialogueManager managerd;


    private void Awake() {
        //managerd = GameObject.FindGameObjectWithTag("Dialog").GetComponent<DialogueManager>();
        
    }
    public void Interact(PlayerInteractor plInter)
    {
        //Debug.Log("i tryyyyy");
        plInter.dialogueManager.ForceDialog(note);
    }

}
