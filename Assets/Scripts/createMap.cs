using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class createMap : MonoBehaviour
{
    public GameObject tilePrefab;
    void Start(){
        for(int i = 0; i < 10; i++){
            for(int j = 0; j < 10; j++){
                GameObject tile = Instantiate(tilePrefab, new Vector3(i, 0, j), Quaternion.identity);
                tile.transform.parent = this.transform;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
