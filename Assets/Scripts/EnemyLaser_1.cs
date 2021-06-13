using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyLaser_1 : MonoBehaviour
{
    Transform playerPos;
    Vector2 direction;
    [SerializeField] float laserSpeed;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = FindObjectOfType<Player>().gameObject.transform;
        direction = playerPos.position - transform.position;
        Rigidbody2D rb = gameObject.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(direction.x, direction.y) * laserSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
