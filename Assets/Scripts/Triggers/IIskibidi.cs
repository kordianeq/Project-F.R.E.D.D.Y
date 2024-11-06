using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IIskibidi : Task, ITrigger
{
    [SerializeField] PlayerInteractor inter;
    // Start is called before the first frame update
    void Start()
    {
        inter = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInteractor>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Triggered()
    {
        FinishTask();
    }
    /*public void Interact(PlayerInteractor plInter)
    {
        //if(type = )
        Debug.Log("Taking item");
            if(inter.RemoveItem(type))
            {
                Debug.Log("iTEMtAKEN");
                FinishTask();
                if(destroyOnFinish)
                {
                    inter.ClearInteract(this.gameObject);
                    //Destroy(this.gameObject);
                    a.SetActive(false);
                    b.SetActive(true);
                }
            }else
            {
                Debug.Log("Cant take item");
            }
            

        
        
    }*/

    /*public void Interact()
    {
        //if(type = )
        Debug.Log("Taking item");
        
    }*/

    
}
