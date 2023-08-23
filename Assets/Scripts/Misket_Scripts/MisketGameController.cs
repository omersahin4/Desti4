using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class MisketGameController : MonoBehaviour
{
    public Transform ballSpawnPoint;
    public GameObject ballPrefab;
    public Text scoreText;
    public Text messageText;
    public float maxBallSpeed = 10f;
    public int targetScore = 6;
    public float gameDuration = 10f;
    public MisketBall misketBall;
    public GameObject retrybutton;
    public GameObject gameovercanvas;
    public GameObject wingamecanvas;
    public GameObject levelupbutton;

    private int score = 0;
    private bool gameOver = false;
    private bool secondThrow = false;

    private void Start()
    {
        messageText.gameObject.SetActive(false);
        StartCoroutine(GameTimer());
        SpawnBall();
    }

    private void Update()
    {
        if (!gameOver)
        {
            if (Input.GetMouseButtonDown(0))
            {
                misketBall.Throw();
            }
        }
    }

    private void SpawnBall()
    {
        Debug.Log("test");
        GameObject newBall = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
        MisketBall misketBallComponent = newBall.GetComponent<MisketBall>();
        misketBallComponent.SetGameController(this);
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();

        if (score >= targetScore)
        {
            WinGame();
        }
        else if (secondThrow)
        {
            LoseGame();
        }
        else
        {
            secondThrow = true;
            messageText.text = "Second Throw";
        }
    }

    private void WinGame()
    {
        gameOver = true;
        messageText.gameObject.SetActive(true);
        messageText.text = "You Win!";
        Debug.Log("wingame");
        gameovercanvas.SetActive(true);
        retrybutton.gameObject.SetActive(true); 
    }

    private void LoseGame()
    {
        gameOver = true;
        messageText.gameObject.SetActive(true);
        messageText.text = "Game Over";
        Debug.Log("losegame");
        wingamecanvas.SetActive(true);
        levelupbutton.SetActive(true);
    }

    private IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(gameDuration);
        if (!gameOver)
        {
            Debug.Log("Süre bitti");
          
            LoseGame();
        }
    }
}
