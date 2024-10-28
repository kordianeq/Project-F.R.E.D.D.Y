using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
public enum ItemType{food,mop,junk,pack,none};
public class Junk : MonoBehaviour, ITakeable
{
    
    public Item i;

    public Item Take()
    {
        //i.worldItemBody.SetActive(false);
        Debug.Log("picking up");
        i.GetWorldItem().SetActive(false);
        i.GetHandItem().SetActive(true);
        return i;
    }

    private void Awake() {
        i.GetHandItem().SetActive(false);
    }



}
