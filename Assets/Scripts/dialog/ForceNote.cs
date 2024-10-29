using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ForceNote : MonoBehaviour
{
    // Start is called before the first frame update
    public Dialog note;
    public DialogueManager managerd;
    public bool once;
    private void Awake()
    {
        managerd = GameObject.FindGameObjectWithTag("Dialog").GetComponent<DialogueManager>();

    }
    private void OnTriggerEnter(Collider other) {
        if(other.transform.tag=="Player")
        {
            managerd.ForceDialog(note);
            if(once)
            {
                Destroy(gameObject);
            }
        }
    }
   

}
