using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamEnGroup : GroupBase
{
    public RamShip firstShip;
    public RamShip secShip;
    
    void Update()
    {
        if(firstShip == null && secShip == null) {
            isAlive = false;
            
        }           
    }
}
