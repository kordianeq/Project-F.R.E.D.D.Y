using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public abstract class Task: MonoBehaviour
{
    [SerializeField] TaskHolder taskC;
    public void FinishTask()
    {
        if(taskC!=null)
        {
            taskC.RemoveTask(this);
        }
    }
}
