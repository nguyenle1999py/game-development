using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float lifeTime;
    [SerializeField] GameObject explosion;
    [SerializeField] AudioClip coinPickupSFX;


    // Start is called before the first frame update
    void Start()
    {

        AudioSource.PlayClipAtPoint(coinPickupSFX, Camera.main.transform.position);

    }




    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "Player" && collision.tag != "Coin"  && collision.tag != "Climp")
        {
            Debug.Log("Projectile Trigger with " + collision.gameObject);
            GameObject game =  Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
            
        }
   
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
