using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigidbody2D;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();    
    }

    // Update is called once per frame
    void Update()
    {
        if (IsFacingRight())
        {
            Vector2 vector2 = new Vector2(moveSpeed, 0f);
            rigidbody2D.velocity = vector2;
        }
        else
        {
            Vector2 vector2 = new Vector2(-moveSpeed, 0f);

            rigidbody2D.velocity = vector2;
        }

    }



    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2D.velocity.x)), 1f);
        if (collision.tag == "Projetile")
        {
            Debug.Log("Be hit");
            Destroy(gameObject);
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }
}
