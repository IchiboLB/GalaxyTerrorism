using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamShip : MonoBehaviour
{
    public DirMove direction;
    public SpriteRenderer shipRenderer;
    private float speed = 0.3f;
    private float halfSide;
    private int health = 180;

    
    void Start()
    {
        halfSide = shipRenderer.sprite.bounds.size.y/2;
    }

    
    public void FixedUpdate()
    {
        switch(direction) {
            case DirMove.right:
            Vector3 newPos = new Vector3(transform.position.x + speed, transform.position.y, 0);
            Vector3 checkPos = new Vector3(transform.position.x + speed + halfSide, transform.position.y, 0);
            bool IsOnScr = ScreenHelpers.ObjectNah(checkPos);
            if(IsOnScr) {
                transform.position = newPos;
            } else {
               if (transform.position.y > 0) {
                transform.rotation = Quaternion.Euler(0 , 0 , 180);
                direction = DirMove.down;
               } else {
                transform.rotation = Quaternion.Euler(0 , 0 , 0);
                direction = DirMove.up;
               }
            }
            
            break;

             case DirMove.left:
             newPos = new Vector3(transform.position.x - speed, transform.position.y, 0);
             checkPos = new Vector3(transform.position.x - speed - halfSide, transform.position.y, 0);
             IsOnScr = ScreenHelpers.ObjectNah(checkPos);
                if(IsOnScr) {
                transform.position = newPos;
            } else {
               if (transform.position.y > 0) {
                transform.rotation = Quaternion.Euler(0 , 0 , 180);
                direction = DirMove.down;
               } else {
                transform.rotation = Quaternion.Euler(0 , 0 , 0);
                direction = DirMove.up;
               }
            }
            
            break;

             case DirMove.up:
             newPos = new Vector3(transform.position.x, transform.position.y + speed, 0);
           checkPos = new Vector3(transform.position.x, transform.position.y  + speed + halfSide, 0);
             IsOnScr = ScreenHelpers.ObjectNah(checkPos);
                if(IsOnScr) {
                transform.position = newPos;
            } else {
               if (transform.position.x > 0) {
                transform.rotation = Quaternion.Euler(0 , 0 , 90);
                direction = DirMove.left;
               } else {
                direction = DirMove.right;
                transform.rotation = Quaternion.Euler(0 , 0 , 270);
               }
            }
            
            break;

             case DirMove.down:
             newPos = new Vector3(transform.position.x, transform.position.y - speed, 0);
             checkPos = new Vector3(transform.position.x, transform.position.y  - speed - halfSide, 0);
             IsOnScr = ScreenHelpers.ObjectNah(checkPos);
                if(IsOnScr) {
                transform.position = newPos;
            } else {
               if (transform.position.x > 0) {
                transform.rotation = Quaternion.Euler(0 , 0 , 90);
                direction = DirMove.left;
               } else {
                transform.rotation = Quaternion.Euler(0 , 0 , 270);
                direction = DirMove.right;
               }
            }
            
            break;

        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        GameObject othObject = collider.gameObject;
        SpaceBullet bulletScript = othObject.GetComponent<SpaceBullet>();
        if(bulletScript != null){
            health = health - bulletScript.damage;
            if(health <= 0){
                Destroy(gameObject);
            }
            Destroy(othObject);
        }
        
    }
}
