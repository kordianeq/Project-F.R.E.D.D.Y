using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTask : MonoBehaviour
{
    public List<TaskHolder> tList;
    public float taskTime,taskTimer;

    public GameObject triggerAfterAllTasks;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(taskTimer <= taskTime)
        {
            taskTimer+=Time.deltaTime;
        }
    }

    public void RemoveTaskList(TaskHolder _t)
    {
        tList.Remove(_t);
        Debug.Log("removedTask");

        if(tList.Count<=0)
        {
            Debug.Log("TaskGroupCompleeteee");
            FinishLevel();
        }


    }

    void FinishLevel()
    {

        ITrigger triggered = null;
        if (triggerAfterAllTasks != null)
        {
            triggerAfterAllTasks.TryGetComponent<ITrigger>(out triggered);
        }
        if (triggered != null)
        { 
            triggered.Triggered(); 
           
        
        }
         

    }
}
