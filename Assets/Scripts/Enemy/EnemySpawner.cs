using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] public GameObject[] enemyPrefabs;

    [SerializeField] public loadTile map;

    public int maxEnemies = 10;
    
      private  int despawnDistance = 15;
    private List<GameObject> enemiesSpawned;

    // Start is called before the first frame update
    void Start()
    {
        enemiesSpawned = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        if (enemiesSpawned.Count < maxEnemies)
        {
            foreach (var enemy in enemyPrefabs)
            {
                if (Random.Range(0, 1000) < 1)
                {
                    StartCoroutine(SpawnEnemy(enemy));
                }
            }
        }
        else
        {
            new WaitForSeconds(15);
        }
    }

    public IEnumerator SpawnEnemy(GameObject enemyPrefab)
    {
        var position = getRandomPosition();
        GameObject enemy = randomizeEnemyStats(enemyPrefab);
        enemy.transform.SetParent(transform);
        enemiesSpawned.Add(enemy);
        yield return new WaitForSeconds(5);
    }

    private GameObject randomizeEnemyStats(GameObject enemyPrefab)
    {
        var enemy = Instantiate(enemyPrefab, getRandomPosition(), Quaternion.identity);
        enemy.GetComponent<Enemy>().setID(enemiesSpawned.Count);
        enemy.GetComponent<Enemy>().setHealth(Random.Range(50, 100));
        enemy.GetComponent<Enemy>().setDamage(Random.Range(10, 20));
        enemy.GetComponent<Enemy>().setSpeed(Random.Range(2, 6));
        enemy.GetComponent<Enemy>().setRange(Random.Range(1, 3));
        return enemy;
    }

    public Vector3 getRandomPosition()
    {
        Vector3 playerPosition = GameObject.Find("Player").transform.position;
        Vector3Int apprPlayerPosition = new Vector3Int((int)Mathf.FloorToInt(playerPosition.x), (int)Mathf.FloorToInt(playerPosition.y), 0);
        int x, y;
        do
        {
            x = Random.Range(apprPlayerPosition.x - despawnDistance > map.getBorderds()[0] ? apprPlayerPosition.x - despawnDistance : map.getBorderds()[0], apprPlayerPosition.x + despawnDistance < map.getBorderds()[2] ? apprPlayerPosition.x + despawnDistance : map.getBorderds()[2]);
            y = Random.Range(apprPlayerPosition.y - despawnDistance > map.getBorderds()[1] ? apprPlayerPosition.y - despawnDistance : map.getBorderds()[1], apprPlayerPosition.y + despawnDistance < map.getBorderds()[3] ? apprPlayerPosition.y + despawnDistance : map.getBorderds()[3]);
        } while (!map.checkValidTile(new Vector3Int(x, y, 0)));
        return new Vector3(x, y, 0);
    }

    public void removeEnemy(int ID)
    {
        GameObject enemy = enemiesSpawned.Find(e => e.GetComponent<Enemy>().getID() == ID);
        enemiesSpawned.Remove(enemy);
        Destroy(enemy);
    }

    public int getDespawnDistance()
    {
        return despawnDistance;
    }
}
