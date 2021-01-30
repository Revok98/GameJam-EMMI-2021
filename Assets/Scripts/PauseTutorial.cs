using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseTutorial : MonoBehaviour
{
    public GameObject Button;
    public GameObject Image;
    public void Tuto()
    {
        Button.SetActive(true);
        Image.SetActive(true);
    }
}
