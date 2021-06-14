using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    Vector3 direction;
    Rigidbody2D rb;
    SpriteRenderer spriteRenderer;

    [Header("PlayerSettings")]

    [SerializeField] float moveSpeed = 1;
    [SerializeField] Sprite shootSprite;
    [SerializeField] Sprite idleSprite;
    [SerializeField] AudioClip deathClip;
    [SerializeField] [Range(0, 1)] float deathClipVolume = 0.75f;
    public bool playerAlive;

    [Header("LaserSettings")]

    [SerializeField] GameObject laserPrefab;
    [SerializeField] float fireRate = 0.5f;
    [SerializeField] AudioClip shootClip;
    [SerializeField] [Range(0, 1)] float shootClipVolume = 0.75f;
    float nextFire = 0;
    
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
            Fire();
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
            Fire();
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
    
    void Fire()
    {
        if(Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1f, 0) , Quaternion.identity);
            PlayShootSound();
        }     
    }

    private void PlayShootSound()
    {
        AudioSource.PlayClipAtPoint(shootClip, Camera.main.transform.position, shootClipVolume);
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EnemyLaser")
        {
            Die();
        }
    }

    private void Die()
    { 
        Destroy(gameObject);
        PlayDeathSound();
        playerAlive = false;
    }

    private void PlayDeathSound()
    {
        AudioSource.PlayClipAtPoint(deathClip, Camera.main.transform.position, shootClipVolume);
    }
}
