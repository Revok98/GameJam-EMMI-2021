using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleSpeed : CollectibleItem
{
    // Start is called before the first frame update
    public void Start()
    {
        longterm = true;
    }

    public override void collectibleMethod()
    {
        PlayerMove player = GameObject.Find("Player").GetComponent<PlayerMove>();
        PlayerMoveInverse player2 = GameObject.Find("Player").GetComponent<PlayerMoveInverse>();
        Debug.Log(player);
        Debug.Log(player2);
        if(player != null && player.isActiveAndEnabled)
        {
            player.speedBonus = 2;
            player.speedBonusTime = 10;
        }
        else if(player2 != null && player2.isActiveAndEnabled)
        {
            player2.speedBonus = 2;
            player2.speedBonusTime = 10;
        }
        
    }
}
