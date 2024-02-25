using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawn : MonoBehaviour
{
    [SerializeField] 
    private Object pipePrefab;
    
    [SerializeField]
    private float spawnTime = 2.0f;
    [SerializeField]
    private float spawnDelay = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        SpawnPipe();
    }

    // Update is called once per frame
    void Update()
    {
        spawnDelay -= Time.deltaTime;
        if (spawnDelay <= 0)
        {
            SpawnPipe();
            spawnDelay = spawnTime;
        }
    }

    private void SpawnPipe()
    {
        Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(-2, 2)), Quaternion.identity);
    }
}
