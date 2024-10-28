using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTask : MonoBehaviour
{
    public List<TaskHolder> tList;
    public float taskTime,taskTimer;
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
        }


    }
}
