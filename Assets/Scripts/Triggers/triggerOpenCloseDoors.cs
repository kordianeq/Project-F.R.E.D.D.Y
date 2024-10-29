using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerOpenCloseDoors : MonoBehaviour, ITrigger
{
    // Start is called before the first frame update
    public Animator anim;
    public GameObject col;
    bool closed;
    public bool oneTime;
    public bool iteration;
    
    public void Triggered()
    {
        if (iteration)
        {
            if (col.activeSelf)
            {
                closed = false;
            }

            if (closed)
            {
                col.SetActive(true);
                anim.SetTrigger("Close");
                closed = false;
                
            }
            else
            {
                col.SetActive(false);
                anim.SetTrigger("Open");
                closed = true;
            }

            if(oneTime)
            {
                iteration = false;  
            }

        }
        
        //Debug.Log("i tryyyyy");


    }
}
