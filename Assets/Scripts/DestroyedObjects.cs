using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DestroyedObjects : MonoBehaviour
{
    public GameObject PlayerExplosion;
    public AudioSource PlayerExplodeSound;
    public static bool BombtoBomExplode = false;
   

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      
    }

    
    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Powerup"))
        {
            Destroy(collision.gameObject);
            Debug.Log("powerUp gone");
        }
       
        if (collision.gameObject.tag == "Player1" || collision.gameObject.tag == "Player2")
        {
            if (collision.gameObject.tag == "Player1")
            {
               
                Destroy(collision.gameObject);
                Instantiate(PlayerExplosion, transform.position, Quaternion.identity);
                PlayerExplodeSound = GetComponent<AudioSource>();
                PlayerExplodeSound.Play();
            }
            else if (collision.gameObject.tag == "Player2")
            {
                Destroy(collision.gameObject);
                Instantiate(PlayerExplosion, transform.position, Quaternion.identity);
                PlayerExplodeSound = GetComponent<AudioSource>();
                PlayerExplodeSound.Play();

            }


        }
        else if (collision.gameObject.tag == "Player1" && collision.gameObject.tag == "Player2")
        {
            
        }



    }
   


}
