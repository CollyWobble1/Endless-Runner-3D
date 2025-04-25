using UnityEngine;

public class CoinSpawner : MonoBehaviour
{
    [Header("Lanes")]
    [SerializeField] float[] lanes = { -2f, 0f, 2f };


    [Header("Coins")]
    public GameObject coinPrefabs;
    [SerializeField] float spawnRateCoin = 1f;
    [SerializeField] float spawnDelayCoin = 7.5f;


    [Header("Obstacles")]
    public GameObject[] obstaclePrefabs;
    public float spawnRateObs = 1f;
    [SerializeField] float spawnDelayObs = 10f;
    [SerializeField] float zObstaclesPos;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        InvokeRepeating("SpawnCoins", spawnDelayCoin, spawnRateCoin);

        InvokeRepeating("SpawnObstacles", spawnDelayObs, spawnRateObs);
    }

    // Update is called once per frame
    void Update()
    {

    }
    void SpawnCoins()
    {
        int randomIndex = Random.Range(0, lanes.Length + 1); // 0, 1, or 2
        float randomLane = lanes[randomIndex]; // -2, 0, or 2
        Instantiate(coinPrefabs, new Vector3(randomLane, 1f, transform.position.z), Quaternion.identity);
    }

    void SpawnObstacles()
    {
        int randomIndex = Random.Range(0, lanes.Length + 1); // 0, 1, or 2
        float randomLane = lanes[randomIndex]; // -2, 0, or 2
        int randomObstacles = Random.Range(0, obstaclePrefabs.Length);
        Instantiate(obstaclePrefabs[randomObstacles], new Vector3(randomLane, 0f, zObstaclesPos), Quaternion.identity);  
        

    }
}