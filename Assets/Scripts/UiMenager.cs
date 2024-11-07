using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UiMenager : MonoBehaviour, ITrigger

{
    public void Triggered()
    {
        OnChangeScene(0);
    }
    public KeyCode pauseGame = KeyCode.P;
    bool isGamePaused;

    public GameObject pausePanel;
    int activeSecene;
  

   
    void Start()
    {
        activeSecene = SceneManager.GetActiveScene().buildIndex;
        isGamePaused = false;
        pausePanel.SetActive(false);
       if( activeSecene == 0)
       {
            UnpauseGame();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
       }
        else
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (activeSecene != 0)
        {
            if (Input.GetKeyDown(pauseGame) && isGamePaused == false)
            {
                Debug.Log("Pasue");
                PauseGame();
                isGamePaused = true;
            }
            else
            if (Input.GetKeyDown(pauseGame) && isGamePaused == true)
            {
                UnpauseGame();
                isGamePaused = false;
            }

            Debug.Log(isGamePaused);
        }
        else
        {

        }
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
        pausePanel.SetActive(true);
        Time.timeScale = 0;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    public void UnpauseGame()
    {
        
        pausePanel.SetActive(false);
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
        activeSecene = SceneManager.GetActiveScene().buildIndex;

        isGamePaused = false;
        pausePanel.SetActive(false);
        if (activeSecene == 0)
        {
            UnpauseGame();
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            UnpauseGame();
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
    }







}
