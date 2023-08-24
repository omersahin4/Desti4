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
    public int targetScore = 2;
    public int maxThrows = 3;
    public float gameDuration = 10f;
    public MisketBall misketBall;
    public GameObject retryButton;
    public GameObject gameOverCanvas;
    public GameObject winGameCanvas;
    public GameObject levelUpButton;

    private int score = 0;
    private int throwsLeft = 3;
    private int targetsHit = 0;
    private bool gameOver = false;

    private void Start()
    {
        messageText.gameObject.SetActive(false);
        retryButton.SetActive(false);
        winGameCanvas.SetActive(false);
        levelUpButton.SetActive(false);
        gameOverCanvas.SetActive(false);

        StartCoroutine(GameTimer());
        SpawnBall();
    }

    private void Update()
    {
        if (targetsHit == 2)
        {
            WinGame();
        }
        if (!gameOver && throwsLeft > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                misketBall.Throw();
                throwsLeft--;

                if (throwsLeft == 0)
                {
                    if (targetsHit >= targetScore)
                    {
                        Debug.Log("kazandýn");
                        WinGame();
                    }
                    else
                    {
                        LoseGame();
                    }
                }
            }
        }
    }

    private void SpawnBall()
    {
        GameObject newBall = Instantiate(ballPrefab, ballSpawnPoint.position, Quaternion.identity);
        MisketBall misketBallComponent = newBall.GetComponent<MisketBall>();
        misketBallComponent.SetGameController(this);
    }

    public void AddScore(int points)
    {
        score += points;
        scoreText.text = "Score: " + score.ToString();
        targetsHit++;

        if (targetsHit >= targetScore)
        {
            WinGame();
        }
        else
        {
            // Atýþ hakkýný sýfýrla
            
            messageText.text = "Throws Left: " + throwsLeft.ToString();
        }
    }

    private void WinGame()
    {
       
        gameOver = true;
        messageText.gameObject.SetActive(true);
        messageText.text = "You Win!";
        winGameCanvas.SetActive(true);
        levelUpButton.SetActive(true);
    }

    private void LoseGame()
    {
        Debug.Log("kaybettin");
        gameOver = true;
        messageText.gameObject.SetActive(true);
        messageText.text = "Game Over";
        gameOverCanvas.SetActive(true);
        retryButton.SetActive(true);
    }

    private IEnumerator GameTimer()
    {
        yield return new WaitForSeconds(gameDuration);
        if (!gameOver)
        {
            LoseGame();
        }
    }
}
