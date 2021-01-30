using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CollectibleSound : CollectibleItem
{

    private GameObject[] monsters;
    public Image image;
    public Canvas canvas;

    private void Start()
    {
        longterm = true;
    }

    public override void collectibleMethod()
    {
        monsters = GameObject.FindGameObjectsWithTag("Ennemy");
        foreach(GameObject monster in monsters)
        {
            addSoundSprite(monster);
        }
    }

    private void addSoundSprite(GameObject monster)
    {
        CameraSpriteFollow csf = monster.AddComponent<CameraSpriteFollow>();
        Image imageInstance = Instantiate(image, new Vector3(0, 0, 0), Quaternion.identity);
        imageInstance.transform.parent = canvas.transform;
        csf.image = imageInstance;
    }
}
