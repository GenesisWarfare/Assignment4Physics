using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject asteroidPrefab;
    public int maxAsteroids = 10;
    public float spawnRate = 1f;
    public float minSpeed = 2f;
    public float maxSpeed = 5f;

    private Camera cam;
    private Vector2 screenBounds;
    private Queue<GameObject> asteroids = new Queue<GameObject>();

    void Start()
    {
        cam = Camera.main;
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
        InvokeRepeating(nameof(SpawnAsteroid), 0f, spawnRate);
    }

    void SpawnAsteroid()
    {
        if (asteroids.Count >= maxAsteroids)
        {
            GameObject oldest = asteroids.Dequeue();
            Destroy(oldest);
        }

        Vector3 spawnPos = GetOutsideScreenPosition();
        GameObject asteroid = Instantiate(asteroidPrefab, spawnPos, Quaternion.identity);

        Vector2 direction = (Vector2.zero - (Vector2)spawnPos).normalized;
        direction += new Vector2(Random.Range(-0.3f, 0.3f), Random.Range(-0.3f, 0.3f));
        direction.Normalize();

        float speed = Random.Range(minSpeed, maxSpeed);

        AsteroidMovement movement = asteroid.AddComponent<AsteroidMovement>();
        movement.direction = direction;
        movement.speed = speed;

        if (!asteroid.GetComponent<Collider2D>())
        {
            CircleCollider2D col = asteroid.AddComponent<CircleCollider2D>();
            col.isTrigger = true;
        }

        asteroid.tag = "Asteroid";
        asteroids.Enqueue(asteroid);
    }

    Vector3 GetOutsideScreenPosition()
    {
        float x, y;
        int edge = Random.Range(0, 4);

        switch (edge)
        {
            case 0:
                x = -screenBounds.x - 1f;
                y = Random.Range(-screenBounds.y, screenBounds.y);
                break;
            case 1:
                x = screenBounds.x + 1f;
                y = Random.Range(-screenBounds.y, screenBounds.y);
                break;
            case 2:
                x = Random.Range(-screenBounds.x, screenBounds.x);
                y = screenBounds.y + 1f;
                break;
            default:
                x = Random.Range(-screenBounds.x, screenBounds.x);
                y = -screenBounds.y - 1f;
                break;
        }
        return new Vector3(x, y, -1f);
    }
}
