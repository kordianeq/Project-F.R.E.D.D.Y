using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicTriggerInteractor : MonoBehaviour, IInteractable
{

    public GameObject trig;

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
       // Debug.Log("Trying to open doorss");
        ITrigger _yesTrigger = null;
        if (trig != null) { trig.TryGetComponent<ITrigger>(out _yesTrigger); }
        if (_yesTrigger != null)
        {
            Debug.Log("Trying to open doorss");
            _yesTrigger.Triggered(); }
    }
}
