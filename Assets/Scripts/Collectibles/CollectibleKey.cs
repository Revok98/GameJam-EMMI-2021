using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CollectibleKey : CollectibleItem
{
    public Image image;
    // Usage : Mettre la porte en paramètre
    public DoorController Door;

    public void Start()
    {
        Door.locked = true;
    }

    public override void collectibleMethod()
    {
        Door.locked = false;

        GameObject KeyImage = GameObject.Find("KeyImage");
        KeyImage.GetComponent<Image>().enabled = true;
    }
}
