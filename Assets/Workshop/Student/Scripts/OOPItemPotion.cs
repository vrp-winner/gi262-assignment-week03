using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OOPItemPotion : Identity
{
    public override void Hit()
    {
        mapGenerator.player.Heal(1);
        Destroy(this.gameObject);
        mapGenerator.mapdata[positionX, positionY] = mapGenerator.empty;
        
    }
}