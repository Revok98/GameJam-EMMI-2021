using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectibleItem : MonoBehaviour
{
    // Usage : placer ou non une audioSource dans la scène, à mettre en paramètre (si null, ça fait pas de son)
    public AudioSource audioSource;
    private bool longterm =false;

    private void OnTriggerEnter(Collider element)
    {
        if (element.tag == "Player")
        {
            if(audioSource != null) audioSource.Play();
            Destroy(gameObject);
            if (!longterm)
            {
                collectibleMethod();
            }
            else {
                element.gameObject.GetComponents<PlayerItems>().CollectItem(this);
            }
        }
    }

    public abstract void collectibleMethod();
}
