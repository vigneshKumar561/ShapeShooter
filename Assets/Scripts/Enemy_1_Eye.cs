using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_1_Eye : MonoBehaviour
{
    Vector3 direction;
    GameObject player;
    [SerializeField] float moveSpeed = 1;
    SceneManager sceneManager;
    Rigidbody2D rb;
    
    // Start is called before the first frame update
    void Start()
    {
        sceneManager = FindObjectOfType<SceneManager>();
        
        player = FindObjectOfType<Player>().gameObject;
             
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {  
        if(sceneManager.playerDied == false)
        {
            direction = (transform.position - player.transform.position);
            direction.z = 0;
            rb.velocity = new Vector2(direction.x, direction.y) * -moveSpeed;
        }
                
    }
}
