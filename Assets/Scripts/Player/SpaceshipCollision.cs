using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SpaceshipCollision : MonoBehaviour
{
    public int lives = 3;
    public TMP_Text livesText;

    private void Awake()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb == null)
        {
            rb = gameObject.AddComponent<Rigidbody2D>();
            rb.isKinematic = true;
        }
    }

    private void Start()
    {
        UpdateLivesUI();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Asteroid") || other.CompareTag("Stone"))
        {
            lives--;
            UpdateLivesUI();

            Destroy(other.gameObject);

            if (lives <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }

    private void UpdateLivesUI()
    {
        if (livesText != null)
            livesText.text = "Lives: " + lives;
    }
}
