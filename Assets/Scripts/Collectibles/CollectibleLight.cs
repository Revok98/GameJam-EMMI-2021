using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleLight : CollectibleItem
{

    public Light light;

    public void Start()
    {
        light.enabled = false;
    }

    public override void collectibleMethod()
    {
        light.enabled = true;
    }
}
