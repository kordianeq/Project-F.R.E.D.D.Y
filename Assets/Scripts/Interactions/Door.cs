using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    //will make animated or smth
    public GameObject doorr;
    bool closed = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Interact(PlayerInteractor plInter)
    {
        Debug.Log("try to open");
        Close();
        Debug.Log("door is "+closed);
    }

    void Close()
    {
        //first check
        if(doorr.activeSelf)
        {
            closed = false;
        }

        if(closed)
        {
            doorr.SetActive(true);
            closed = false;
        }else
        {
            doorr.SetActive(false);
            closed = true;
        }
    }
}
