using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions.Must;

public class Puddle : Task, IInteractable
{
    //will make animated or smth
    PlayerInteractor p;
    public GameObject stain;
    public float size;
    bool inRange = false;
    public ItemType requerdType;
    public float interactionTime,interactionTimer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                inRange = false;
            }
            if (p.CheckInteractionObject(this.gameObject))
            {
                if(interactionTimer<interactionTime)
                {
                    interactionTimer+=Time.deltaTime;
                    stain.transform.localScale+= new Vector3(1,1,0)*size*Time.deltaTime;
                }else
                {
                    Debug.Log("Finished interaction");
                    FinishTask();
                    p.ClearInteract(this.gameObject);
                    Destroy(this.gameObject);
                    inRange = false;
                }
            }
            else
            {
                
                inRange = false;
            }
        }
    }

    public void Interact(PlayerInteractor plInter)
    {
        if (plInter.GetItemType() == requerdType)
        {
            p = plInter;
            inRange = true;
        }
        else
        {
            Debug.Log("use "+ requerdType);
        }

    }


}
