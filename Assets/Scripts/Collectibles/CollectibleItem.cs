using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectibleItem : MonoBehaviour
{
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider element)
    {
        if (element.tag == "CanCollect")
        {
            if(audioSource != null) audioSource.Play();
            Destroy(gameObject);
            collectibleMethod();
        }
    }

    public abstract void collectibleMethod();
}
