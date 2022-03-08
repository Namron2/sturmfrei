using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeyserAscenseur : MonoBehaviour
{
    public GameObject player;
    public Rigidbody2D quiBouge;


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            quiBouge.velocity = Vector2.up*6f;
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            quiBouge.gravityScale = 0f;
            quiBouge.AddForce(transform.up * 2f);
            
        }
    }    
    
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject == player)
        {
            quiBouge.gravityScale = 3f;
        }
    }
    
}
