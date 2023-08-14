using System.Collections;
using UnityEngine;

public class DdakjiBotController : MonoBehaviour
{
    private bool isBotTurn = false;

    private void Start()
    {
        // Start the game with the player's turn
        isBotTurn = false;
    }

    private void Update()
    {
        if (isBotTurn)
        {
            // Implement bot's decision-making logic here
            // For this example, let's assume the bot waits for a random time and then shoots

            float randomWaitTime = Random.Range(1.0f, 3.0f);
            StartCoroutine(BotShootAfterDelay(randomWaitTime));
        }
    }

    private IEnumerator BotShootAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);

        // Call the shooting function of the DdakjiGame script
        DdakjiGame ddakjiGame = FindObjectOfType<DdakjiGame>();
        ddakjiGame.BotShoot();

        // Switch turns back to the player
        isBotTurn = false;
    }

    public void StartBotTurn()
    {
        isBotTurn = true;
    }
}