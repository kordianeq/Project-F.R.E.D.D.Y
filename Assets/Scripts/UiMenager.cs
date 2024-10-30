using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMenager : MonoBehaviour,ITrigger
{
    public void Triggered()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
    bool isGamePaused;
    public KeyCode pauseGame = KeyCode.Escape;
    //public GameObject pausePanel;
    // Start is called before the first frame update
    void Start()
    {
       // pausePanel.SetActive(false);
       
    }

    // Update is called once per frame
    void Update()
    {
     
        //if(Input.GetKeyDown(pauseGame)&& isGamePaused == false)
        //{
        //    PauseGame();
        //    isGamePaused = true;
        //}
        //if(Input.GetKey(pauseGame)&& isGamePaused == true)
        //{
        //    UnpauseGame();
        //    isGamePaused=false;
        //}
    }

    public void OnChangeScene(int SceneId)
    {
        SceneManager.LoadScene(SceneId);
        
    }
    
    public void OnClickExit()
    {
        Application.Quit();
    }

   public void PauseGame()
    {
        Debug.Log("Game Paused");
        isGamePaused = true;
        //pausePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnpauseGame()
    {
        isGamePaused = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    public void SetTimeScale(float TimeScale)
    {
        Time.timeScale = TimeScale;
    }


    private void OnLevelWasLoaded(int level)
    {
        if (SceneManager.GetActiveScene().buildIndex == 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }







}
