using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using JetBrains.Annotations;
//using UnityEditorInternal;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInteractor : MonoBehaviour
{
    bool holding = false;
    public Transform holder;
    [SerializeField] private Item cItem;
    public DialogueManager dialogueManager;

    [SerializeField] List<GameObject> pickeable = new List<GameObject>();
    [SerializeField] List<GameObject> interacteable = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        cItem = null;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (holding)
            {
                DropItem();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) // yes, this is stupid
        {
            if (!holding)
            {
                if (pickeable.Count == 1)
                {
                    PickUpItem(pickeable[0]);
                }
                else if (pickeable.Count > 1)
                {
                    PickUpItem(pickeable[GetClosest(pickeable)]);
                }
                else if (interacteable.Count == 1)
                {
                    InteractItem(interacteable[0]);
                }
                else if (interacteable.Count > 1)
                {
                    InteractItem(interacteable[GetClosest(pickeable)]);
                }
            }
            else
            {
                if (interacteable.Count == 1)
                {
                    InteractItem(interacteable[0]);
                }
                else if (interacteable.Count > 1)
                {
                    PickUpItem(interacteable[GetClosest(pickeable)]);
                }
            }
        }


        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    if (cItem.GetHandItem() != null)
        //    {
        //        cItem.GetWorldItem().transform.position = gameObject.transform.position;
        //        cItem.GetWorldItem().SetActive(true);
        //        cItem = null;
        //    }
        //}
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Item")
        {
            if (!pickeable.Contains(other.gameObject))
            {
                pickeable.Add(other.gameObject);
            }
        }
        else if (other.tag == "Interact")
        {
            if (!interacteable.Contains(other.gameObject))
            {
                interacteable.Add(other.gameObject);
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Item")
        {
            if (pickeable.Contains(other.gameObject))
            {
                pickeable.Remove(other.gameObject);
            }
        }
        else if (other.tag == "Interact")
        {
            if (interacteable.Contains(other.gameObject))
            {
                interacteable.Remove(other.gameObject);
            }
        }
    }

    public void PickUpItem(GameObject _item)
    {
        holding = true;
        pickeable.Remove(_item);
        if (_item.TryGetComponent<ITakeable>(out ITakeable pickup))
        {
            cItem = pickup.Take();
            //if (cItem.GetHandItem() == null)
            //{ cItem = pickup.Take(); }
        }
        else
        {
            Debug.Log("what the fuck, cant pick up");
            holding = false;
        }
        //Debug.Log("uuu sigma");
    }

    void DropItem()
    {
        holding = false;
        if (cItem.GetWorldItem() != null)
        {
            cItem.GetWorldItem().SetActive(true);
            cItem.GetWorldItem().transform.position = holder.transform.position;
            cItem.GetHandItem().SetActive(false);

        }
        cItem = null;
    }

    public bool RemoveItem(ItemType _item)
    {
        if (holding)
        {
            if (cItem.GetTypeItem() == _item)
            {
                holding = false;
                if (cItem.GetWorldItem() != null)
                {
                    cItem.GetWorldItem().SetActive(false);
                    cItem.GetHandItem().SetActive(false);
                    Destroy(cItem.GetWorldItem());

                }
                cItem = null;
                Debug.Log("sigma");
                return true;
            }
            else
            {
                Debug.Log("not sigma");
                return false;
            }
        }
        return false;
    }

    public void InteractItem(GameObject _item)
    {
        //interacteable.Remove(_item);
        if (_item.TryGetComponent<IInteractable>(out IInteractable pickup))
        {
            pickup.Interact(this);
            //if (cItem.GetHandItem() == null)
            //{ cItem = pickup.Take(); }
        }
        else
        {
            Debug.Log("what the fuck, cant interact");
        }
    }

    public int GetClosest(List<GameObject> it)
    {
        int closest = 0;
        float bestDist = 100;// xd
        for (int i = 0; i < it.Count; i++)
        {
            float dis = Vector3.Distance(it[i].transform.position, this.transform.position);
            if (dis < bestDist)
            {
                closest = i;
                bestDist = dis;
            }
        }
        return closest;
    }

    public bool CheckInteractionObject(GameObject a)
    {
        if (interacteable.Contains(a))
        {
            return true;
        }
        return false;
    }

    public ItemType GetItemType()
    {
        if (holding)
        {
            return cItem.GetTypeItem();
        }
        else
        {

        }
        return ItemType.none;
    }

    public void ClearInteract(GameObject cl)
    {
        interacteable.Remove(cl);
    }

    /*private void OnTriggerStay(Collider other)
        {
            //Debug.Log("InTriggerRange");

            if (click)
            {
                Debug.Log("Interact try");
                if(other.TryGetComponent<IInteractable>(out IInteractable interaction))
                {
                    interaction.Interact();
                }else if(other.TryGetComponent<ITakeable>(out ITakeable pickup))
                {
                    if(cItem.GetHandItem()==null)
                    {cItem = pickup.Take();}
                }
                else
                {
                    Debug.Log("could not interact ");
                }
                click = false;
            }


        }*/

}
