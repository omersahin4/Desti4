using UnityEngine;

public class DdakjiGame : MonoBehaviour
{
    public Transform player1SpawnPoint;
    public Transform player2SpawnPoint;
    public Transform ddakjiSpawnPoint;
    public GameObject ddakjiPrefab;
    public GameObject player1;
    public GameObject player2;
    public DdakjiBotController botController;

    private GameObject currentDdakji;
    private bool isPlayer1Turn = true;
    private bool isBotTurn = false;

    private enum ShotResult { Bad, Good, Excellent }

    private void Start()
    {
        SpawnDdakji();
    }

    private void Update()
    {
        if (isPlayer1Turn)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                ShootDdakji(player1);
            }
        }
        else if (isBotTurn)
        {
            botController.StartBotTurn();
        }
    }

    public void BotShoot()
    {
        ShotResult botResult = (ShotResult)Random.Range(0, 3);

        // Implement code to handle the bot's shot result

        // Switch turns
        isBotTurn = false;
        isPlayer1Turn = true;

        SpawnDdakji();
    }

    private void ShootDdakji(GameObject player)
    {
        ShotResult result = CalculateShotResult();

        // Implement code to handle the shot result
        // You can use raycasting or other methods to determine the outcome
        // For this example, let's assume it's based on random chance

        // Switch turns
        isPlayer1Turn = !isPlayer1Turn;
        isBotTurn = true;

        SpawnDdakji();
    }

    private void SpawnDdakji()
    {
        if (currentDdakji != null)
        {
            Destroy(currentDdakji);
        }

        currentDdakji = Instantiate(ddakjiPrefab, ddakjiSpawnPoint.position, Quaternion.identity);
    }

    private ShotResult CalculateShotResult()
    {
        return (ShotResult)Random.Range(0, 3);
    }
}
