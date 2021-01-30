using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject Button;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Debug.Log("LA");
            gameIsPaused = !gameIsPaused;
            PauseGame();
        }
    }

    void PauseGame()
    { 
        Debug.Log(gameIsPaused);
        if (gameIsPaused)
        {
            Debug.Log("IF");
            GetComponent<Image>().enabled = true;
            Time.timeScale = 0f;
            Button.SetActive(true);
        }
        else
        {
            GetComponent<Image>().enabled = false;
            Time.timeScale = 1;
            Button.SetActive(false);
        }
    }
}
