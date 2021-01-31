using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterAnimated : MonoBehaviour
{

    public enum states {WALKING,STOP}
    public states state;

    void Update()
    {
        switch (state)
        {
            case (states.WALKING):
                gameObject.GetComponent<Animator>().enabled = true;
                break;
            case (states.STOP):
                gameObject.GetComponent<Animator>().enabled = false;
                break;
            default:
                gameObject.GetComponent<Animator>().enabled = true;
                break;
        }
    }
}
