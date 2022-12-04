using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstEnGroup : GroupBase
{
    
    public BlueTeleg ship1;
    public BlueTeleg ship2;
    public BlueTeleg ship3;
    public BlueTeleg ship4;
    public BlueTeleg ship5;
    private int direction = -1;
    private float speed = 0.1f;
    
    private List<BlueTeleg> ships = new List<BlueTeleg>();
    private System.Random randGen = new System.Random();
    void Start()
    {
        ships.Add(ship1);
        ships.Add(ship2);
        ships.Add(ship3);
        ships.Add(ship4);
        ships.Add(ship5);
        InvokeRepeating("GroupShoot", 0.0f, 0.5f);
    }

    
    void Update()
    {
        ships.RemoveAll(item => item == null);

        if(ship1 == null 
        && ship2 == null 
        && ship3 == null 
        && ship4 == null 
        && ship5 == null) {
            isAlive = false;
            CancelInvoke("GroupShoot");
        }
        if(direction == -1) {
            float left = GetLeft();
            left += speed*direction;
            if(left <= -12.44) {
                direction = direction * -1;
                
            } else {
                transform.position = new Vector3(
                    transform.position.x - speed,
                    transform.position.y,
                    0
                );
            }
            
        } else {
            float right = GetRight();
            right += speed*direction;
            if(right >= 12.44) {
                direction *= -1;
                
            } else {
                transform.position = new Vector3(
                    transform.position.x + speed,
                    transform.position.y,
                    0
                );
            }
        }

    }

    float GetLeft() 
    {
        float min = float.MaxValue;

        for(int i = 0; i < ships.Count; i++) {
            if(ships[i].transform.position.x < min) {
                min = ships[i].transform.position.x;
            }
        }
        return min;
    }
    float GetRight() 
    {
        float max = float.MinValue;
        for(int i = 0; i < ships.Count; i++) {
            if(ships[i].transform.position.x > max) {
                max = ships[i].transform.position.x;
            }
        }
        return max;
    }

    void GroupShoot() 
{
    int randomIndex = randGen.Next(0, ships.Count - 1);
    ships[randomIndex].EnShoot();
} 

}

