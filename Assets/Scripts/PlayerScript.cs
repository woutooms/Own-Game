using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Playerscript : MonoBehaviour
{
    protected float yVelocity;
    protected float yVelocityOnJump = 5f;
    public float yGravity = -9.8f;
    protected Rigidbody2D rb2d;
    protected SpriteRenderer spriteRenderer;
    Camera cam;
    protected float yTopPosition;
    ColorComponent colComp;

    private int score = 0; 
    public TextMeshProUGUI scoreText; 

    private void Awake()
    {
        cam = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        colComp = GetComponent<ColorComponent>();
        transform.position = new Vector3(transform.position.x, 0, transform.position.z);
        cam.transform.position = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);
        yTopPosition = transform.position.y;

        UpdateScoreText();
    }



    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            yVelocity = yVelocityOnJump;
        }

        if (transform.position.y > yTopPosition)
        {
            yTopPosition = transform.position.y;
        }
    }

    private void FixedUpdate()
    {
        yVelocity += yGravity * Time.fixedDeltaTime;
        rb2d.linearVelocity = new Vector2(0f, yVelocity);
    }

    private void LateUpdate()
    {
        if (cam.transform.position.y < transform.position.y)
        {
            cam.transform.position = new Vector3(cam.transform.position.x, transform.position.y, cam.transform.position.z);
        }

        if (cam.transform.position.y > transform.position.y + 10)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        int currentScore = score; 
        int highScore = PlayerPrefs.GetInt("HighScore", 0); 

        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore); 
            PlayerPrefs.Save(); 
        }

        SceneManager.LoadScene("StartScene");
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        ColorChanger colorChanger = collision.gameObject.GetComponent<ColorChanger>();
        if (colorChanger != null)
        {
            ChangeColor(colorChanger.GetColor());
            Destroy(collision.gameObject); 
            score++; 
            UpdateScoreText(); 
        }
        else if (collision.gameObject.GetComponent<ColorComponent>() != null && collision.gameObject.GetComponent<ColorComponent>().color != colComp.color)
        {
            EndGame();
        }
    }

    private void ChangeColor(EColor newColor)
    {
        spriteRenderer.color = ColorHandler.GetColor(newColor);
        colComp.color = newColor;
    }

    private void UpdateScoreText()
    {
        if (scoreText != null)
        {
            scoreText.text = score.ToString(); 
        }
    }

}
