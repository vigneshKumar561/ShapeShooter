using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Eye : MonoBehaviour
{
    Vector3 direction;
    [SerializeField] GameObject player;
    [SerializeField] float moveSpeed = 1;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        direction = (transform.position - player.transform.position);
        direction.z = 0;     
        rb.velocity = new Vector2(direction.x, direction.y) * -moveSpeed;
    }
}
