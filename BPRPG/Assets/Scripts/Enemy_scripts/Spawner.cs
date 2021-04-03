using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    private Player player;
    [SerializeField]
    [Tooltip("Maximum # of enemies spawned by spawner")]
    private int maxEnemies;
    private int currEnemies;
    [SerializeField]
    [Tooltip("How long between enemy spawns (useless if maxEnemy = 1")]
    private float spawnCD;
    private float spawnTimer;
    [SerializeField]
    [Tooltip("The script of the type of enemy you want to spawn")]
    private Enemy enemyF;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spawnTimer = spawnCD;
        currEnemies = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnTimer > 0)
        {
            spawnTimer -= Time.deltaTime;
        } else if (currEnemies < maxEnemies) 
        {
            spawn();
        }
    }

    public void despawned()
    {
        currEnemies--;
    }

    void spawn()
    {
        Instantiate(enemyF, this.transform.position + new Vector3(2, 0, 0), 
            this.transform.rotation).setSpawner(this);
        currEnemies++;
        spawnTimer = spawnCD;
    }
}
