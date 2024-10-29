using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskHolder : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject triggerAfterTask;
    public MainTask mtask;
    void Start()
    {

    }
    public List<Task> tasks;

    // Update is called once per frame
    void Update()
    {

    }
    public void RemoveTask(Task _t)
    {
        tasks.Remove(_t);
        Debug.Log("removedTask");

        if (tasks.Count <= 0)
        {
            Debug.Log("TaskGroupCompleate");
            UpdateTaskState();
        }


    }
    void UpdateTaskState()
    {

        ITrigger triggered = null;
        if (triggerAfterTask != null)
        {
            triggerAfterTask.TryGetComponent<ITrigger>(out triggered);
        }
        if (triggered != null)
        { 
            triggered.Triggered(); 
           
        
        }
         mtask.RemoveTaskList(this);

    }
}
