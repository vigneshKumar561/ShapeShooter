using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser_1 : MonoBehaviour
{
    Transform playerPos;
    Vector2 direction;
    [SerializeField] float laserSpeed;
    [SerializeField] bool followPlayer = true;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();

        if (followPlayer == true)
        {
            playerPos = FindObjectOfType<Player>().gameObject.transform;
            direction = playerPos.position - transform.position;  
            rb.velocity = new Vector2(direction.x, direction.y) * laserSpeed;
        }
        
        else
        {
            //rb.velocity = new Vector2(this.transform.localPosition.x, 0) * laserSpeed;
            rb.AddRelativeForce(new Vector2(Mathf.Clamp(transform.localPosition.x, 1, 1), 0) * laserSpeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }        
    }
}
