using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpFire : MonoBehaviour
{

    public static int ExplodeRange = 1;

    
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
        if (collision.gameObject.tag == "Player1")
        {
            // Pickupfire1(collision);
            ExplodeRange++;
            BombSpawner.isUpFire = true;
            Destroy(gameObject);
        }else if (collision.gameObject.tag == "Player2")
        {
            ExplodeRange++;
            BombSpawner2.isUpFire2 = true;
            Destroy(gameObject);
        }else
        if (collision.gameObject.tag == "Fire")
        {
            //   BombtoBomExplode = true;
            Destroy(gameObject);
            Debug.Log("choo gya");

        }
    }
    //void Pickupfire1(Collider2D player)
    //{
    //    MapDestroyer BombReach = player.GetComponent<MapDestroyer>();
        

    //    Destroy(gameObject);
    //}
}
