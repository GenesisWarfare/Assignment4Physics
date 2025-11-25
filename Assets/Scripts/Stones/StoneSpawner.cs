using System.Collections.Generic;
using UnityEngine;

public class StoneSpawner : MonoBehaviour
{
    public GameObject stonePrefab;
    public int maxStones = 3;
    public float spawnRate = 2f;
    public float minSpeed = 2f;
    public float maxSpeed = 5f;

    public float groundY = -4f;

    private Camera cam;
    private Vector2 screenBounds;
    private Queue<GameObject> stones = new Queue<GameObject>();

    void Start()
    {
        cam = Camera.main;
        screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));
        InvokeRepeating(nameof(SpawnStone), 0f, spawnRate);
    }

    void SpawnStone()
    {
        if (stones.Count >= maxStones)
        {
            GameObject oldest = stones.Dequeue();
            Destroy(oldest);
        }

        float x = Random.value < 0.5f ? -screenBounds.x - 1f : screenBounds.x + 1f;
        Vector3 spawnPos = new Vector3(x, groundY, -1f);

        GameObject stone = Instantiate(stonePrefab, spawnPos, Quaternion.identity);

        Vector2 direction = x < 0 ? Vector2.right : Vector2.left;
        float speed = Random.Range(minSpeed, maxSpeed);

        StoneMovement movement = stone.AddComponent<StoneMovement>();
        movement.direction = direction;
        movement.speed = speed;

        if (!stone.GetComponent<Collider2D>())
        {
            CircleCollider2D col = stone.AddComponent<CircleCollider2D>();
            col.isTrigger = true;
        }

        stone.tag = "Stone";
        stones.Enqueue(stone);
    }
}
