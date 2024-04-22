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

    private int maxX;
    private int maxY;

    

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
                    maxX = j;
                }
            }
            maxY = i;
        }
        
        Debug.Log("Tilemap loaded, borderds are " + getBorderds()[0] + " " + getBorderds()[1] + " " + getBorderds()[2] + " " + getBorderds()[3]);
        
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

    private void removeTile(Vector3Int position)
    {
        tilemap.SetTile(position, null);
    }
    /**
        @return int[] borders, the borders of the map, at index 0 is the left border, at index 1 is the bottom border, at index 2 is the right border and at index 3 is the top border
    */
    public int[] getBorderds(){
        int[] borders = new int[4];
        borders[0] = 0;
        borders[1] = 0;
        borders[2] = maxX;
        borders[3] = maxY;
        return borders;
    }

    public bool checkValidTile(Vector3Int position){
        if(tilemap.GetTile(position) == null){
            return false;
        }
        if(collisionMap.GetTile(position) != null){
            return false;
        }
        var borders = getBorderds();
        if(borders[0] > position.x || borders[1] > position.y || borders[2] < position.x || borders[3] < position.y){
            return false;
        }
        return true;
    }

    
}
