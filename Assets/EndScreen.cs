using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScreen : MonoBehaviour, ITrigger
{
    public GameObject Screen;
    public UiMenager uiMenager;
    bool deathScreenActive = false;
    public void Triggered()
    {
        Screen.SetActive(true);
        deathScreenActive = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        deathScreenActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && deathScreenActive == true)
        {
            uiMenager.OnChangeScene(0);

        }
    }
}
