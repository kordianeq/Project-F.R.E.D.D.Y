using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;
using UnityEditor.AnimatedValues;
public class DialogueManager : MonoBehaviour
{

    public bool inDialog = false;
    public bool choosing = false;
    public PlayerInteractor pInter;
    public Player pPlayer;
    [SerializeField] TextMeshProUGUI textTitle;
    [SerializeField] TextMeshProUGUI textBody;
    [SerializeField] Dialog dialog;
    [SerializeField] GameObject box;
    [SerializeField] GameObject choiceHolder;
    [SerializeField] public int index;
    bool trueChoice = true;
    [SerializeField] TextMeshProUGUI[] choices;
    // Start is called before the first frame update
    void Start()
    {
        //SwitchChoises(0,1);
        SwitchChoises(0,1);
            pInter.enabled = true;
            pPlayer.enabled = true;
            choosing = false;
            box.SetActive(false);
            choiceHolder.SetActive(false);
        //guo.text = text[tIndex];
    }

    // Update is called once per frame
    void Update()
    {
        if (inDialog)
        {
            
            pInter.enabled = false;
            pPlayer.enabled = false;
            if (Input.GetKeyDown(KeyCode.Space) && !choosing)
            {
                IterateD();

            }else if(choosing)
            {
                if(Input.GetKeyDown(KeyCode.A))
                {
                    SwitchChoises(0,1);
                    trueChoice = true;
                }
                if(Input.GetKeyDown(KeyCode.D))
                {
                    SwitchChoises(1,0);
                    trueChoice = false;
                }

                if(Input.GetKeyDown(KeyCode.Space))
                {
                    inDialog = false;
                    dialog.SetOffDefaultTrigger(trueChoice);
                    
                }
            }
        }
        else
        {
            SwitchChoises(0,1);
            pInter.enabled = true;
            pPlayer.enabled = true;
            choosing = false;
            box.SetActive(false);
            choiceHolder.SetActive(false);
        }
    }

    public void ForceDialog(Dialog d)
    {
        dialog = d;
        index = 0;
        inDialog = true;
        choosing = false;
        choiceHolder.SetActive(false);
        SwitchChoises(0,1);
        IterateD();

    }

    void IterateD()
    {
        box.SetActive(true);
        textBody.text = dialog.GetText(index);
        textTitle.text = dialog.GetTitle();
        index++;
        if (dialog.GetText(index) == null)
        {
            //textBody.text = dialog.GetText(index-2);
            Debug.Log("NotSigma");
            
            if(dialog.Choice)
            {
                Debug.Log("choice box?");
                choiceHolder.SetActive(true);
                choosing = true;
            }else if(dialog.GetText(index-1) == null)
            {
                inDialog = false;
                dialog.SetOffDefaultTrigger(true);
            }
        }
        else
        {
            Debug.Log("Skibidi");
        }
    }

    void SwitchChoises(int a, int b)
    {
        choices[a].fontStyle = FontStyles.Underline;
        choices[b].fontStyle &= ~ FontStyles.Underline;
    }
}
