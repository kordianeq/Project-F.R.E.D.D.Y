using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerActDis : MonoBehaviour, ITrigger
{
    // Start is called before the first frame update
    public GameObject activ;
    public bool activate;
    
    public void Triggered()
    {
        if(activate)
        {
            activ.SetActive(true);
            activate = false;
        }else
        {
            activ.SetActive(false);
            activate =  true;
        }
        Debug.Log("ForceScene");
        //Debug.Log("i tryyyyy");


    }
}
