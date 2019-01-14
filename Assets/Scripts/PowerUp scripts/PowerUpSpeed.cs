using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpeed : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1" )
        {
            PickupSpeed1(collision);
        }else
        
            if(collision.gameObject.tag == "Player2")
            {
                PickupSpeed2(collision);
            }
        
    }
    void PickupSpeed1(Collider2D player)
    {
      Movement_1 move=   player.GetComponent<Movement_1>();
        if (move.PlayerSpeed < 1)
        {
            move.PlayerSpeed *= 1.5f;
        }
           
        Destroy(gameObject);
    }
    void PickupSpeed2(Collider2D player2)
    {
        Movement_2 move2 = player2.GetComponent<Movement_2>();
        if (move2.PlayerSpeed < 1)
        {
            move2.PlayerSpeed *= 1.5f;
        }
        Destroy(gameObject);
    }
    
}

