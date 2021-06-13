using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shredder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "HeroLaser")
        {
            Destroy(collider.gameObject);
        }
        
        if(collider.gameObject.tag == "EnemyLaser")
        {
            Destroy(collider.gameObject);
        }
    }
     /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "HeroLaser")
        {
            Destroy(collision.gameObject);
        }
    }*/
}
