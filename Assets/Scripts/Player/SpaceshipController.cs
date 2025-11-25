using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipController : MonoBehaviour
{
    public float forceAmount = 2f;
    public float maxSpeed = 12f;
    public float rotationSpeed = 150f;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        var kb = Keyboard.current;

        float rad = rb.rotation * Mathf.Deg2Rad;

        Vector2 right = new Vector2(Mathf.Cos(rad), Mathf.Sin(rad));
        Vector2 forward   = new Vector2(-Mathf.Sin(rad), Mathf.Cos(rad));

        Vector2 force = Vector2.zero;

        if (kb.upArrowKey.isPressed)       force += forward;
        if (kb.downArrowKey.isPressed)     force -= forward;
        if (kb.rightArrowKey.isPressed)    force += right;
        if (kb.leftArrowKey.isPressed)     force -= right;

        rb.AddForce(force * forceAmount);

        if (rb.linearVelocity.magnitude > maxSpeed)
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
    }
}
