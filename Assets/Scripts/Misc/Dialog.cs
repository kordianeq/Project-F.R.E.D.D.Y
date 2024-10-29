using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
[System.Serializable]
public class Dialog
{
    [SerializeField] string title;
    
    [SerializeField] string[] text;
    [SerializeField] public bool Choice;
    
    [SerializeField] GameObject yesTrigger;
    [SerializeField] GameObject noTrigger;

    //public bool Choice { get; }

    

    public Dialog(string _title, string[] _text, ITrigger _trig)
    {
        title = _title;
        text = _text;
    }

    public string GetText(int i)
    {
        if (i < text.Length)
        {
            return text[i];
        }
        else
        {
            return null;
        }
    }

    public string GetTitle()
    {
        return title;
    } 

    public void SetOffDefaultTrigger(bool t)
    {//TryGetComponent<IInteractable>(out IInteractable pickup)
        ITrigger _yesTrigger = null;
        ITrigger _noTrigger = null;
        if(yesTrigger!=null){yesTrigger.TryGetComponent<ITrigger>(out _yesTrigger);}
        

        if(noTrigger!=null){noTrigger.TryGetComponent<ITrigger>(out _noTrigger);}
        
        if (t)
        {
            if (_yesTrigger != null)
            { _yesTrigger.Triggered(); }
        }
        else
        {
            if (_noTrigger != null)
            { _noTrigger.Triggered(); }
        }
    }
}
