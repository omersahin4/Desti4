using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public int winScore = 180; // Kazanma puaný
    private int currentScore = 0;
    private int atisHakki = 6; // Atýþ hakký

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Misket"))
        {
            currentScore += 30; // Misket çembere temas ettiðinde 30 puan ekle
            atisHakki--;

            Debug.Log("Puan: " + currentScore + " - Atýþ Hakký: " + atisHakki);

            if (atisHakki <= 0 || currentScore >= winScore)
            {
                if (currentScore >= winScore)
                {
                    Debug.Log("Oyun kazanýldý!");
                    // Kazanma iþlemleri burada yapýlabilir
                }
                else
                {
                    Debug.Log("Oyun kaybedildi!");
                    // Kaybetme iþlemleri burada yapýlabilir
                }
            }

            // Misketi tekrar baþlangýç pozisyonuna yerleþtir
            collision.gameObject.GetComponent<MisketController>().ResetMisket();
        }
    }
}