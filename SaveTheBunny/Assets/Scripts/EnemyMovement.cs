using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{

    public float rotationSpeed;
    public GameObject dust;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {   
        // rotating the enemy
        transform.Rotate(0, 0, rotationSpeed);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // destroying the object with which the collision happened i.e. the player
            Destroy(collision.gameObject);

            // tell game manager that game is over
            // since game manager has a public instance no need to find it
            GameManager.instance.GameOver();

        }
        else if(collision.gameObject.tag == "Ground")
        {
            // increment the score when the enemy touches the ground i.e. enemy is dodged
            GameManager.instance.IncrementScore();
            
            // deactivating the gameobject i.e. enemy
            gameObject.SetActive(false);

            // Instantiating dust partical, at the position of colision and with identity rotation i.e. zero rotation
            GameObject dustEffect = Instantiate(dust, transform.position, Quaternion.identity);

            // destroying the dust
            Destroy(dustEffect, 1f);
            
            // destroying the object to which the script is attached i.e. the enemy
            Destroy(gameObject, 1.1f);    
        }
    }

}
