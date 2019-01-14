using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class BombSpawner2 : MonoBehaviour
{
    public float countdown = 3f;
    public static bool isUpFire2 = false;
    public static bool isRemoteBomb2 = false;

    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(DelayCollider());
    }

    // Update is called once per frame
    void Update()
    {if(!isRemoteBomb2)
        countdown -= Time.deltaTime;
        if (countdown <= 0f)
        {
            if (isUpFire2)
                FindObjectOfType<MapDestroyer2>().ExplodeWithPower(transform.position, PowerUpFire.ExplodeRange);
            else
                FindObjectOfType<MapDestroyer>().Explode(transform.position);

            FindObjectOfType<Movement_2>().BombCheck2--;

            Destroy(gameObject);
        }
        else if (isRemoteBomb2 && countdown == 3f)
            if (Input.GetButtonDown("Blast2"))
            {
                if (isUpFire2)
                    FindObjectOfType<MapDestroyer>().ExplodeWithPower(transform.position, PowerUpFire.ExplodeRange);
                else
                    FindObjectOfType<MapDestroyer>().Explode(transform.position);
                FindObjectOfType<Movement_2>().BombCheck2--;
                Debug.Log("spawner me niche mar raha h");
                Destroy(gameObject);
            }
    }
    //private IEnumerator DelayCollider()
    //{
    //    yield return new WaitForSeconds(1f);
    //    this.GetComponent<CircleCollider2D>().enabled = true;
    //}

    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player2")
        {
            this.GetComponent<CircleCollider2D>().enabled = true;
        }
    }
}
