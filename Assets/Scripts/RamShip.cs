using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public DirMove direction;
    private float speed = 0.1f;

    
    void Start()
    {
        
    }

    
    public void FixedUpdate()
    {
        switch(direction) {
            case DirMove.right:
            Vector3 newPos = new Vector3(transform.position.x + speed, transform.position.y, 0);
            bool isOnScr = ScreenHelpers.ObjectNah(newPos);
            if(isOnScr) {
                transform.position = newPos;
            } else {
                direction = DirMove.down;
            }
            
            break;

             case DirMove.left:
            
            break;

             case DirMove.up:
            
            break;

             case DirMove.down:
            
            break;

        }
    }
}
