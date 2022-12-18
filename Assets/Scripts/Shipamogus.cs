using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shipamogus : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;
    public GameObject bullet;

    private float speed = 0.1f;
    public int health = 300;
    private float halfWidth;

    void Start()
    {
        halfWidth = spriteRenderer.bounds.size.x / 2;
    }

    void Update()
    {
        Vector3 newRPos = new Vector3(transform.position.x + speed, transform.position.y, 0);
        Vector3 newLPos = new Vector3(transform.position.x - speed, transform.position.y, 0);
        Vector3 checkLPos = new Vector3(newLPos.x - halfWidth, newLPos.y, 0);
        Vector3 checkRPos = new Vector3(newRPos.x + halfWidth, newRPos.y, 0);

        if (Input.GetKey(KeyCode.D)) {
            bool check = ScreenHelpers.ObjectNah(checkRPos);
            if (check) {
                transform.position = newRPos; 
            }            
        }

        if (Input.GetKey(KeyCode.A)) {
            bool check = ScreenHelpers.ObjectNah(checkLPos);
            if (check) {
                transform.position = newLPos; 
            }
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            GameObject clone = Instantiate(bullet);
            clone.transform.position = transform.position;
        }
    }

    void OnTriggerEnter2D(Collider2D otherCollider) 
    {
      GameObject secObject = otherCollider.gameObject;
      EnBullet bulletScript = secObject.GetComponent<EnBullet>();
      if(bulletScript != null) {
        health -= bulletScript.damage;
        Destroy(secObject);
        if(health <= 0) {
            Destroy(gameObject);
        }
      }
    }
}
