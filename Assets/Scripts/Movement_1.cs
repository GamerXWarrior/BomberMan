using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;


public class Movement_1 : MonoBehaviour
{
    public Animator animator;
  //  public AudioSource WalkingClip;
    public GameObject bomb;
    public float PlayerSpeed = 0.8f;
    public Tilemap tilemap;
    public AudioSource bombDropSound;
    public AudioSource WalkingClip;
    private bool axisInuse = false;
    public  int BombCheck= 1;
    public  int MaxBomCount = 1;
    public bool gamePause = false;
    public AudioSource pauseSound;
    

   // Start is called before the first frame update
   void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 Movement = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0f);
        animator.SetFloat("Horizontal", Movement.x);
        animator.SetFloat("Vertical", Movement.y);
        animator.SetFloat("Magnitude", Movement.magnitude);
        transform.position = transform.position + Movement*PlayerSpeed*Time.deltaTime;
        WalkingClip = GetComponent<AudioSource>();
        //if(Input.GetAxis("Horizontal") || Input.GetAxis("Vertical"))
        //{    
        //        WalkingClip.Play();
        // }
       
            if (Input.GetButtonDown("Space")&& BombCheck<=MaxBomCount )
            {
                Vector3Int cell = tilemap.WorldToCell(transform.position);
                Vector3 CellCenter = tilemap.GetCellCenterWorld(cell);
                GameObject BombShells=  Instantiate(bomb, CellCenter, Quaternion.identity);
            bombDropSound.Play();
            
            if (!BombSpawner.isRemoteBomb)
                Destroy(BombShells, 3.1f);
                BombCheck++;        
            }

        //Pause the game//
        if (Input.GetButtonDown("Cancel"))
        {
            if (gamePause == false)
            {
                pauseSound.Play();
                Time.timeScale = 0;
            gamePause = true;
                
            }
        else
            if (gamePause == true)
            {
                pauseSound.Play();
                Time.timeScale = 1;
                gamePause = false;
            }

                
        }
    }
   
   
   
}
