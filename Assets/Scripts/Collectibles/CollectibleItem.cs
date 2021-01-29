using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CollectibleItem : MonoBehaviour
{
    private void OnTriggerEnter(Collider element)
    {
        if (element.tag == "CanCollect")
        {
            Destroy(gameObject);
            collectibleMethod();
        }
    }

    public abstract void collectibleMethod();
}
