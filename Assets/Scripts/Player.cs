using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    Vector3 direction;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 1;
    SpriteRenderer spriteRenderer;
    [SerializeField] Sprite shootSprite;
    [SerializeField] Sprite idleSprite;
    
    
   
    // Start is called before the first frame update

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    void Update()
    {

        if(Input.touchCount > 0)
        {
            ChangeSprite();
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            direction = (touchPosition - transform.position);
            direction.z = 0;
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if(touch.phase == TouchPhase.Ended)
            {
                RevertSprite();
                rb.velocity = Vector2.zero;
            }
        }

        if(Input.GetMouseButton(0))
        {
            ChangeSprite();
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = transform.position.z;
            direction = (clickPosition - transform.position);
            direction.z = 0;
            rb.velocity = (new Vector2(direction.x, direction.y) * moveSpeed);

            /*if(!Input.GetMouseButton(0))
            {
                rb.velocity = Vector2.zero;
            }*/
        }
        else
        {
            RevertSprite();
            rb.velocity = Vector2.zero;
        }
     
    }

    void ChangeSprite()
    {
        for(int i=0; i<1; i++)
        {
            spriteRenderer.sprite = shootSprite;          
        }  
    }

    void RevertSprite()
    {
        for (int i = 0; i < 1; i++)
        {
            spriteRenderer.sprite = idleSprite;
        }
    }
}
