using UnityEngine;

public class SpaceshipController : MonoBehaviour
{
    public float forceAmount = 200f;
    public float maxSpeed = 12f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        float rad = rb.rotation * Mathf.Deg2Rad;
        Vector2 right = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        Vector2 forward = new Vector2(-Mathf.Sin(rad), Mathf.Cos(rad));
        Vector2 force = Vector2.zero;

        if (Input.GetKey(KeyCode.UpArrow)) force += forward;
        if (Input.GetKey(KeyCode.DownArrow)) force -= forward;
        if (Input.GetKey(KeyCode.RightArrow)) force += right;
        if (Input.GetKey(KeyCode.LeftArrow)) force -= right;

        rb.AddForce(force * forceAmount);

        if (rb.velocity.magnitude > maxSpeed)
            rb.velocity = rb.velocity.normalized * maxSpeed;
    }
}
