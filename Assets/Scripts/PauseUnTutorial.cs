using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseUnTutorial : MonoBehaviour
{
    public GameObject Image;
    public void Tuto()
    {
        gameObject.SetActive(false);
        Image.SetActive(false);
    }
}
