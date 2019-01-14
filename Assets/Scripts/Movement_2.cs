using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Movement_2 : MonoBehaviour
{
    public Animator animator;
    //  public AudioSource WalkingClip;
    public GameObject bomb;
    public float PlayerSpeed = 0.8f;
    public Tilemap tilemap;
    public AudioSource bombDropSound;
    public AudioSource WalkingClip;
    GameObject check;
    public int BombCheck2 =1;
    public int MaxBombNum = 1;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"), 0f);
        animator.SetFloat("Horizontal", Movement.x);
        animator.SetFloat("Vertical", Movement.y);
        animator.SetFloat("Magnitude", Movement.magnitude);
        transform.position = transform.position + Movement * PlayerSpeed * Time.deltaTime;
        WalkingClip = GetComponent<AudioSource>();
        //if ( )
        {
            // WalkingClip.Play();
        }

        if (Input.GetButtonDown("Enter") && BombCheck2<=MaxBombNum )
        {
            Vector3Int cell = tilemap.WorldToCell(transform.position);
            Vector3 CellCenter = tilemap.GetCellCenterWorld(cell);
            GameObject BombShells = Instantiate(bomb, CellCenter, Quaternion.identity);
            bombDropSound.Play();

            if (!BombSpawner2.isRemoteBomb2)
            {
                Debug.Log("kyu dag raha h ");
                Destroy(BombShells, 3.1f);
                BombCheck2++;
            }
        }



    }
}


