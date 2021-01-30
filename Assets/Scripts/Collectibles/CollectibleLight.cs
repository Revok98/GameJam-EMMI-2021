using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleLight : CollectibleItem
{

    // Usage : ajouter une directional light (ou une light quelconque) dans la scène et le placer en paramètre 
    public Light light;
    float lightTime = 0;

    public void Start()
    {
        light.enabled = false;
        longterm = true;
    }

    public override void collectibleMethod()
    {
        light.enabled = true;
        GameObject.Find("Player").GetComponent<PlayerItems>().lightTime = 10000;
    }
}
