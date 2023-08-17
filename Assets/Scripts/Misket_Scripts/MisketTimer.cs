using UnityEngine;

public class MisketTimer : MonoBehaviour
{
    public float timeLimit = 40.0f; // Saniye cinsinden zaman sýnýrý
    private float currentTime = 0.0f;
    private bool isTimerRunning = true;

    private int atisHakki = 6; // Atýþ hakký
    private int currentScore = 0;
    private int winScore = 180; // Kazanma puaný

    private void Update()
    {
        if (isTimerRunning)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= timeLimit)
            {
                isTimerRunning = false;
                Debug.Log("Oyun süresi doldu!");
                // Kaybetme iþlemleri burada yapýlabilir
                CheckGameEnd();
            }
        }
    }

    public void AtisYapildi()
    {
        atisHakki--;

        if (atisHakki <= 0)
        {
            Debug.Log("Atýþ hakkýnýz bitti!");
            isTimerRunning = false;
            CheckGameEnd();
        }
    }

    public void PuanEkle(int puan)
    {
        currentScore += puan;
        Debug.Log("Puan: " + currentScore + " - Atýþ Hakký: " + atisHakki);
        CheckGameEnd();
    }

    private void CheckGameEnd()
    {
        if (currentScore >= winScore)
        {
            Debug.Log("Oyun kazanýldý!");
            // Kazanma iþlemleri burada yapýlabilir
        }
        else if (!isTimerRunning || atisHakki <= 0)
        {
            Debug.Log("Oyun kaybedildi!");
            // Kaybetme iþlemleri burada yapýlabilir
        }
    }
}