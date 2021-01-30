using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleKey : CollectibleItem
{

    // Usage : Mettre la porte en paramètre
    public DoorController Door;

    public void Start()
    {
        Door.locked = true;
    }

    public override void collectibleMethod()
    {
        Door.locked = false;
    }
}
