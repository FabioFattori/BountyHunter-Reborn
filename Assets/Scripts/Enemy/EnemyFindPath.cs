using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFindPath : MonoBehaviour
{
    [SerializeField]
    public AStarManager aStarManager;
    [SerializeField]
    public Transform playerPosition;

    private int despawnDistance;

    // Start is called before the first frame update
    void Start()
    {
        aStarManager = GameObject.Find("AStarManager").GetComponent<AStarManager>();
        playerPosition = GameObject.Find("Player").transform;
        despawnDistance = GameObject.Find("EnemyManager").GetComponent<EnemySpawner>().getDespawnDistance();
    }

    // Update is called once per frame
    void Update()
    {
        //subratct the player position from the enemy position
        Vector3 distance = playerPosition.position - transform.position;

        if (Math.Abs(distance.x) > despawnDistance || Math.Abs(distance.y) > despawnDistance)
        {
            Debug.Log("Enemy despawned " + GetComponent<Enemy>().getID());
            Debug.Log("Distance: " + distance);
            GameObject.Find("EnemyManager").GetComponent<EnemySpawner>().removeEnemy(GetComponent<Enemy>().getID());
        }
        else
        {
            var path = FindPath();
            if (path.Count >= 2)
            {
                Vector3Int nextPos = path[1];
                animate(nextPos);
                //make the enemy move to the next position smoothly
                transform.position = Vector3.MoveTowards(transform.position, nextPos, GetComponent<Enemy>().getSpeed() * Time.deltaTime);
            }
        }
    }

    private void animate(Vector3Int nextPos)
    {
        Vector3Int currentPos = new Vector3Int((int)Mathf.FloorToInt(transform.position.x), (int)Mathf.FloorToInt(transform.position.y), 0);
        Vector3Int direction = nextPos - currentPos;
        if (direction.x == 1)
        {
            GetComponent<Animator>().SetFloat("movement", 1);
        }
        else if (direction.x == -1)
        {
            GetComponent<Animator>().SetFloat("movement", 3);
        }
        else if (direction.y == 1)
        {
            GetComponent<Animator>().SetFloat("movement", 0);
        }
        else if (direction.y == -1)
        {
            GetComponent<Animator>().SetFloat("movement", 2);
        }
    }

    public List<Vector3Int> FindPath()
    {
        return aStarManager.FindPath(new Vector3Int((int)Mathf.FloorToInt(transform.position.x), (int)Mathf.FloorToInt(transform.position.y), 0), new Vector3Int((int)Mathf.FloorToInt(playerPosition.position.x), (int)Mathf.FloorToInt(playerPosition.position.y), 0));
    }
}
