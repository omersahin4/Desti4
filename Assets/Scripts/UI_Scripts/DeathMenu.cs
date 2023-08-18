using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathMenu : MonoBehaviour
{
    public GameObject deathMenuUI;

    public void ShowDeathMenu()
    {
        deathMenuUI.SetActive(true);
        Time.timeScale = 0f; // Oyunu duraklatýr
    }

    public void HideDeathMenu()
    {
        deathMenuUI.SetActive(false);
        Time.timeScale = 1f; // Oyunu devam ettirir
    }

    public void Retry()
    {
        HideDeathMenu();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Öldüðünüz sahneyi yeniden yükler
    }

    public void ReturnToMainMenu()
    {
        Time.timeScale = 1f; // Zaman ölçeðini normal hýzda ayarlar
        SceneManager.LoadScene("MainMenu"); // Ana menü sahnesine dönüþ
    }

    public void QuitGame()
    {
        Debug.Log("Oyun kapatýldý.");

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
