using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
public class BombSpawner : MonoBehaviour
{ 
    //Countdown timer for the explode time delay of bomb//
    public float countdown = 3f;
    public static bool isUpFire = false;
    public static bool isRemoteBomb = false;
   
    // Start is called before the first frame update
    void Start()
    {
       // StartCoroutine(DelayCollider());
    }

    // Update is called once per frame
    //This is used to explode the bomb after the countdown gonna end//
    void Update()
    {
        if(!isRemoteBomb)
        countdown -= Time.deltaTime;
        if(countdown<= 0f)
        {   //Calling the explode from the MapDestroyer script to explode the desired tiles or to avoid the wall tiles//
            if (isUpFire)
                FindObjectOfType<MapDestroyer>().ExplodeWithPower(transform.position, PowerUpFire.ExplodeRange);
            else
                FindObjectOfType<MapDestroyer>().Explode(transform.position);
           

            //setting boolian true for the next bomb drop for player movement script//
            FindObjectOfType<Movement_1>().BombCheck--;

           //Destroying Bomb prefab//
            Destroy(gameObject);
        }
        else if(isRemoteBomb && countdown==3f)
            if (Input.GetButtonDown("Blast"))
        {
                if (isUpFire)
                    FindObjectOfType<MapDestroyer>().ExplodeWithPower(transform.position, PowerUpFire.ExplodeRange);
                else
                    FindObjectOfType<MapDestroyer>().Explode(transform.position);
                FindObjectOfType<Movement_1>().BombCheck--;
                Debug.Log("spawner me niche mar raha h");
                Destroy(gameObject);
                
            }else if (DestroyedObjects.BombtoBomExplode)
            {
                if (isUpFire)
                    FindObjectOfType<MapDestroyer>().ExplodeWithPower(transform.position, PowerUpFire.ExplodeRange);
                else
                    FindObjectOfType<MapDestroyer>().Explode(transform.position);
                Destroy(gameObject);
            }
    }
    //private IEnumerator DelayCollider()
    //{
    //    yield return new WaitForSeconds(1f);
    //}

    //To Avoid Collision with After Dropping the Bomb//
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player1")
        {    
            //Enabling the circular cillider on the bomb prefab after exiting the trigger by player//
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
