using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueTeleg : MonoBehaviour
{
    public int health = 210;
    public GameObject bulletOrig;
    private SpriteRenderer sprRenderer;
     private float halfWidth;
    void Start()
    {
        sprRenderer = GetComponent<SpriteRenderer>();
        halfWidth = sprRenderer.bounds.size.x / 2;
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

    public void EnShoot() 
    {
        GameObject clone = Instantiate(bulletOrig);
        clone.transform.position = transform.position;
    }
}
