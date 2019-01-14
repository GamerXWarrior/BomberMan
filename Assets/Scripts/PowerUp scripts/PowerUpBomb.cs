using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpBomb : MonoBehaviour
{
    public static bool BombOnOff = true;
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
        if (collision.gameObject.tag == "Player1"&& BombOnOff==true)
        {
            Movement_1 bombnumber = collision.GetComponent<Movement_1>();
            bombnumber.MaxBomCount++;
            Destroy(gameObject);
        }else if (collision.gameObject.tag == "Player2"&& BombOnOff==true)
        {
            Movement_2 Bombnumber = collision.GetComponent<Movement_2>();
            Bombnumber.MaxBombNum++;
            Destroy(gameObject);
        }
    }


   
}
