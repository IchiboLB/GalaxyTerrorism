using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnBullet : MonoBehaviour
{
    float speed = 0.1f;
    public int damage = 22;
    void Start()
    {
        
    }

    
    void FixedUpdate()
    {
        Vector3 newPos = new Vector3(transform.position.x, transform.position.y - speed, 0);
        bool check = ScreenHelpers.ObjectNah(newPos);
        if (!check) {
            Destroy(gameObject);
        } else {
            transform.position = newPos;
        }
        
    }
}
