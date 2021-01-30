using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerItems : MonoBehaviour
{
    List<CollectibleItem> listItems = new List<CollectibleItem>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("1"))
        {
            if (listItems.Count > 0) {
                listItems[0].collectibleMethod();
            }
        }

        if (Input.GetKeyDown("2"))
        {
            if (listItems.Count > 1)
            {
                listItems[1].collectibleMethod();
            }
        }

        if (Input.GetKeyDown("3"))
        {
            if (listItems.Count > 2)
            {
                listItems[2].collectibleMethod();
            }
        }

        if (Input.GetKeyDown("4"))
        {
            if (listItems.Count > 3)
            {
                listItems[3].collectibleMethod();
            }
        }
    }

    void CollectItem(CollectibleItem obj) {
        listItems.Add(obj);

    }
}
