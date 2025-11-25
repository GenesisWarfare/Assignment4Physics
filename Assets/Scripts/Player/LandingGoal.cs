using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LandingGoal : MonoBehaviour
{
    public TMP_Text statusText;
    public float requiredStayTime = 5f;

    private bool onGround = false;
    private float stayTimer = 0f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (onGround)
        {
            if (rb.velocity.magnitude < 0.1f)
            {
                stayTimer += Time.deltaTime;
                if (statusText != null)
                    statusText.text = "Landing: " + Mathf.Ceil(requiredStayTime - stayTimer);

                if (stayTimer >= requiredStayTime)
                {
                    WinGame();
                }
            }
            else
            {
                stayTimer = 0f;
                if (statusText != null)
                    statusText.text = "Landing failed!";
            }
        }
        else
        {
            stayTimer = 0f;
            if (statusText != null)
                statusText.text = "";
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGround = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            onGround = false;
            stayTimer = 0f;
            if (statusText != null)
                statusText.text = "";
        }
    }

    private void WinGame()
    {
        if (statusText != null)
            statusText.text = "You Win!";

        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        int totalScenes = SceneManager.sceneCountInBuildSettings;

        if (currentIndex + 1 < totalScenes)
        {
            SceneManager.LoadScene(currentIndex + 1);
        }
        else
        {
            SceneManager.LoadScene("menu");
        }
    }
}
