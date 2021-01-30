using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectibleItem : MonoBehaviour
{
    // Usage : placer ou non une audioSource dans la scène, à mettre en paramètre (si null, ça fait pas de son)
    public AudioSource audioSource;

    private void OnTriggerEnter(Collider element)
    {
        if (element.tag == "Player")
        {
            if(audioSource != null) audioSource.Play();
            Destroy(gameObject);
            collectibleMethod();
        }
    }

    public abstract void collectibleMethod();
}
