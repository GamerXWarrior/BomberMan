using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class MapDestroyer2 : MonoBehaviour
{
    // Start is called before the first frame update
    public Tilemap tilemap;
    public Tile wallTile;
    public Tile DestructibleTile;
    public GameObject player;
    public GameObject explosionPrefab;
    public AudioSource explosionSound;
    public GameObject[] PowerUps = new GameObject[4];



    public void ExplodeWithPower(Vector2 worldPos, int range)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);
        ExplodeCell(originCell);
        explosionSound = GetComponent<AudioSource>();
        explosionSound.Play();
        //for (int x = 1; x <= range; x++)
        //{
        //ExplodeCell(originCell + new Vector3Int(x, 0, 0));
        //ExplodeCell(originCell + new Vector3Int(-x, 0, 0));
        //ExplodeCell(originCell + new Vector3Int(0, x, 0));
        //ExplodeCell(originCell + new Vector3Int(0, -x, 0));
        //}

        int x = 1;

        while (isTile(originCell + new Vector3Int(x, 0, 0)) && x <= range)
        {
            ExplodeCell(originCell + new Vector3Int(x, 0, 0));
            x++;
        }
        x = 1;
        while (isTile(originCell + new Vector3Int(-x, 0, 0)) && x <= range)
        {
            ExplodeCell(originCell + new Vector3Int(-x, 0, 0));
            x++;
        }
        x = 1;
        while (isTile(originCell + new Vector3Int(0, x, 0)) && x <= range)
        {
            ExplodeCell(originCell + new Vector3Int(0, x, 0));
            x++;
        }
        x = 1;
        while (isTile(originCell + new Vector3Int(0, -x, 0)) && x <= range)
        {
            ExplodeCell(originCell + new Vector3Int(0, -x, 0));
            x++;
        }

    }

    public void Explode(Vector2 worldPos)
    {
        Vector3Int originCell = tilemap.WorldToCell(worldPos);
        ExplodeCell(originCell);
        explosionSound = GetComponent<AudioSource>();
        explosionSound.Play();
        int x = 1;
        ExplodeCell(originCell + new Vector3Int(x, 0, 0));
        ExplodeCell(originCell + new Vector3Int(-x, 0, 0));
        ExplodeCell(originCell + new Vector3Int(0, x, 0));
        ExplodeCell(originCell + new Vector3Int(0, -x, 0));


    }

    bool isTile(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        if (tile == wallTile)
            return false;
        else return true;
    }

    bool isDestructibleTile(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        if (tile == DestructibleTile && tile != wallTile)
            return false;
        else return true;
    }

    bool ExplodeCell(Vector3Int cell)
    {
        Tile tile = tilemap.GetTile<Tile>(cell);
        if (tile == wallTile)
        {
            return false;
        }
        if (tile == DestructibleTile)
        {
            tilemap.SetTile(cell, null);
            if (Random.value > 0.75)
            {
                Instantiate(PowerUps[Random.Range(0, 3)], tilemap.GetCellCenterWorld(cell), Quaternion.identity);
            }

        }

        // GameObject player = tilemap.GetComponent<GameObject>();


        Vector3 pos = tilemap.GetCellCenterWorld(cell);
        GameObject ExplosionShell = Instantiate(explosionPrefab, pos, Quaternion.identity);
        Destroy(ExplosionShell, 0.4f);
        return false;
    }

}
