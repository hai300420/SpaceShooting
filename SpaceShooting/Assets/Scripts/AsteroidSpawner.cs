using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject AsteroidGO;
    [SerializeField]
    float maxSpawnRatesInSeconds = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScheduleAsteroidsSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SpawnAsteroids()
    {
        Vector2 min = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        Vector2 max = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));

        GameObject asteroid = (GameObject)Instantiate(AsteroidGO);
        asteroid.transform.position = new Vector2(Random.Range(min.x, max.x), max.y);

        ScheduleNextAsteroidSpawn();
    }

    private void ScheduleNextAsteroidSpawn()
    {
        float spawnInSeconds;
        if (maxSpawnRatesInSeconds > 1f)
        {
            spawnInSeconds = Random.Range(1f, maxSpawnRatesInSeconds);
        }
        else
        {
            spawnInSeconds = 1f;
        }

        Invoke("SpawnAsteroids", spawnInSeconds);
    }

    private void IncreaseSpawnSpeed()
    {
        if (maxSpawnRatesInSeconds > 1f)
        {
            maxSpawnRatesInSeconds--;
        }
        if (maxSpawnRatesInSeconds == 1f)
        {
            CancelInvoke("IncreaseSpawnSpeed");
        }
    }
    public void ScheduleAsteroidsSpawner()
    {
        Invoke("SpawnAsteroids", maxSpawnRatesInSeconds);

        InvokeRepeating("IncreaseSpawnSpeed", 0f, 30f);
    }

}
