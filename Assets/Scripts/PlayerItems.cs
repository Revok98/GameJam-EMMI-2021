using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerItems : MonoBehaviour
{
    List<CollectibleItem> listItems = new List<CollectibleItem>();
    // Start is called before the first frame update
    public List<Image> images;
    List<Image> drawn = new List<Image>();
    public float lightTime = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Light light = GetComponentInChildren<Light>();
        if (lightTime > 0)
        {
            lightTime -= Time.deltaTime;
        }
        else
        {
            light.enabled = false;
        }

        if (Input.GetKeyDown("1"))
        {
            if (listItems.Count > 0) {
                listItems[0].collectibleMethod();
                listItems.RemoveAt(0);
                UpdateInterface();             
            }
        }

        if (Input.GetKeyDown("2"))
        {
            if (listItems.Count > 1)
            {
                listItems[1].collectibleMethod();
                listItems.RemoveAt(1);
                UpdateInterface();
            }
        }

        if (Input.GetKeyDown("3"))
        {
            if (listItems.Count > 2)
            {
                listItems[2].collectibleMethod();
                listItems.RemoveAt(2);
                UpdateInterface();
            }
        }

        if (Input.GetKeyDown("4"))
        {
            if (listItems.Count > 3)
            {
                listItems[3].collectibleMethod();
                listItems.RemoveAt(3);
                UpdateInterface();
            }
        }
    }

    public void CollectItem(CollectibleItem obj) {
        Image image;
        if(obj.GetType() == typeof(CollectibleLight))
        {
            image = images[1];
        }
        else if (obj.GetType() == typeof(CollectibleSpeed))
        {
            image = images[0];
        }
        else
        {
            image = images[0];
        }
        listItems.Add(obj);
        Image draw = Instantiate(image, new Vector3(0, 0, 0), Quaternion.identity);
        GameObject inventory = GameObject.Find("Inventory");
        draw.transform.SetParent(inventory.transform, false);
        draw.transform.localPosition = new Vector3(-37 + 25 * (listItems.Count -1), -1, 0);
        draw.enabled = true;
        drawn.Add(draw);
    }

    void UpdateInterface()
    {
        for (int i = 0; i < drawn.Count; i++)
        {
            drawn[i].enabled = false;
        }
        for (int i = 0; i < listItems.Count; i++)
        {
            Image image;
            if (listItems[i].GetType() == typeof(CollectibleLight))
            {
                image = images[1];
            }
            else if (listItems[i].GetType() == typeof(CollectibleSpeed))
            {
                image = images[0];
            }
            else
            {
                image = images[0];
            }
            Debug.Log(listItems[i].GetType());
            Image draw = Instantiate(image, new Vector3(0, 0, 0), Quaternion.identity);
            GameObject inventory = GameObject.Find("Inventory");
            draw.transform.SetParent(inventory.transform, false);
            draw.transform.localPosition = new Vector3(-37 + 25 * i, -1, 0);
            draw.enabled = true;
            drawn.Add(draw);
        }
    }
}
