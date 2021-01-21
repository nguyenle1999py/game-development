using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

    }


    [SerializeField] float moveSpeed = 1f;
    Rigidbody2D rigidbody2D;
    [SerializeField] GameObject projectile;

    // Start is called before the first frame update


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
        Invoke("Shoot", 1);
    }
    
    private void Shoot()
    {
        Debug.LogError("Hitttt");
                GameObject bullet = Instantiate(projectile, rigidbody2D.position, Quaternion.identity) as GameObject;
                if (IsFacingRight())
                {
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(1000, 0));

                }
                else
                    bullet.GetComponent<Rigidbody2D>().AddForce(new Vector2(-1000, 0));
    }


    private bool IsFacingRight()
    {
        return transform.localScale.x > 0;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        transform.localScale = new Vector2(-(Mathf.Sign(rigidbody2D.velocity.x)), 1f);
        //if (collision.tag == "Projetile")
        //{
        //    Debug.Log("Be hit");
        //    Destroy(gameObject);
        //}
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {

    }
}
