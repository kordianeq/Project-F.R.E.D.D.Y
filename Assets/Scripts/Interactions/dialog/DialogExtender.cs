using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogExtender : MonoBehaviour, ITrigger
{
    public Dialog note;
    public DialogueManager managerd;

    private void Awake()
    {
        managerd = GameObject.FindGameObjectWithTag("Dialog").GetComponent<DialogueManager>();

    }
    public void Triggered()
    {

        //Debug.Log("i tryyyyy");
        managerd.ForceDialog(note);

    }
}
