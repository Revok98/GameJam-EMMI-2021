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
        if(player == null)
        {
            player.speedBonus = 2;
            player.speedBonusTime = 10;
        }
        else
        {
            player2.speedBonus = 2;
            player2.speedBonusTime = 10;
        }
        
    }
}
