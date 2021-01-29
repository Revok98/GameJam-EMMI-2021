using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class goToScene : MonoBehaviour
{
    public string SceneName;

    public void goToMyScene()
    {
        SceneManager.LoadScene(SceneName);
    }
}
