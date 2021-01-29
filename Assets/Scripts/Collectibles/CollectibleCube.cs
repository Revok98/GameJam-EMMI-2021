using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleCube : CollectibleItem
{
    public override void collectibleMethod()
    {
        Debug.Log("Collected cube !");
    }
}
