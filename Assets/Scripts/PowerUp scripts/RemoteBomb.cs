using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoteBomb : MonoBehaviour
{
    public float RemoteCountdown = 0f;
    //creating a bool to stop 3 seconds countdown of bomb//
    public static bool StopBombCount = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

       
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1" )
        {
            // InvokeRepeating("CountDown", 1, 1);
            RemoteCountdown += Time.deltaTime;
            Debug.Log("timer chalu ho gya");
            BombSpawner.isRemoteBomb = true;
            StopBombCount = true;
            
            Destroy(gameObject);
            if (collision.gameObject.tag == "Player1" && RemoteCountdown == 10f)
            {
                BombSpawner.isRemoteBomb = false;
                StopBombCount = false;
                PowerUpBomb.BombOnOff = true;
                RemoteCountdown = 10f;
                Debug.Log("timer ruk gaya");
            }
        }else if (collision.gameObject.tag == "Player2")
        {
            // InvokeRepeating("CountDown", 1, 1);
            RemoteCountdown += Time.deltaTime;
            Debug.Log("timer chalu ho gya");
            BombSpawner2.isRemoteBomb2 = true;
            StopBombCount = true;

            Destroy(gameObject);
            if (collision.gameObject.tag == "Player2" && RemoteCountdown == 10f)
            {
                BombSpawner2.isRemoteBomb2 = false;
                StopBombCount = false;
                PowerUpBomb.BombOnOff = true;
                RemoteCountdown = 10f;
                Debug.Log("timer ruk gaya");
            }
        }
       

    }
    //public void CountDown()
    //{
    //    if (RemoteCountdown >=0)
    //    {
    //        RemoteCountdown+= Time.deltaTime;
    //    }
    //    else
    //    {
    //        CancelInvoke(); // Stops all repeating invokes
    //        RemoteCountdown = 0;
    //    }
    // }
}
