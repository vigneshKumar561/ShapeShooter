using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Player : MonoBehaviour
{

    Vector3 direction;
    Rigidbody2D rb;
    [SerializeField] float moveSpeed = 1;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(touch.position);
            direction = (touchPosition - transform.position);
            direction.z = 0;
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            if(touch.phase == TouchPhase.Ended)
            {
                rb.velocity = Vector2.zero;
            }
        }

        if(Input.GetMouseButton(0))
        {
            Vector3 clickPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            clickPosition.z = transform.position.z;
            direction = (clickPosition - transform.position);
            direction.z = 0;
            rb.velocity = new Vector2(direction.x, direction.y) * moveSpeed;

            /*if(!Input.GetMouseButton(0))
            {
                rb.velocity = Vector2.zero;
            }*/
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
    }
}
