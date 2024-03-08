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
    [SerializeField]
    private float heightOffset = 10.0f;

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
        var lowestPoint = transform.position.y - heightOffset;
        var highestPoint = transform.position.y + heightOffset;
        
        
        Instantiate(pipePrefab, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), Quaternion.identity);
    }
}
