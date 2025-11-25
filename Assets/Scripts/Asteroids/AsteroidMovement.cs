using UnityEngine;

public class AsteroidMovement : MonoBehaviour
{
    public Vector2 direction;
    public float speed;

    void Update()
    {
        transform.position += (Vector3)(direction * speed * Time.deltaTime);
    }
}
