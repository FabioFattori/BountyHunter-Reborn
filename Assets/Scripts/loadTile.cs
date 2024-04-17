using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Tilemaps;

public class loadTile : MonoBehaviour
{
    [SerializeField] Tilemap tilemap;

    [SerializeField] Tilemap collisionMap;

    [SerializeField] TileBase[] tile;

    [SerializeField] Camera cam;

    public string fileName = "map.txt";

    

    // Update is called once per frame
    void Start()
    {
        //open file and read the tile position, the file is in the position ../Tiles/maps/map.txt
        
        string filePath = Path.Combine("Assets/Tiles/maps/", fileName);
        string[] lines = File.ReadAllLines(filePath);
        for (int i = 0; i < lines.Length; i++)
        {
            string[] tilePosition = lines[i].Split(' ');
            for(int j = 0; j < tilePosition.Length; j++)
            {
                if (tilePosition[j] != "")
                {
                    setTile(new Vector3Int(j, i, 0), Convert.ToInt32(tilePosition[j]));
                }
            }

        }
        
            
        
    }

    private void setTile(Vector3Int position,int index)
    {
        

        if(index == 5){
            collisionMap.SetTile(position, tile[index-1]);
            tilemap.SetTile(position, tile[0]);
        }else{
            tilemap.SetTile(position, tile[index-1]);
        }
    }

    private Vector3Int getVectorInt(Vector3 newPos)
    {
        return new Vector3Int(Convert.ToInt32(newPos.x), Convert.ToInt32(newPos.y),Convert.ToInt32(newPos.z));
    }

    private void removeTile(Vector3Int position)
    {
        tilemap.SetTile(position, null);
    }
}
