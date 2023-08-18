using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenuUI;
    private bool isPaused = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // veya baþka bir tuþa göre kontrol edebilirsiniz
        {
            if (isPaused)
                Resume();
            else
                Pause();
        }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; // Oyunun normal hýzda çalýþmasýný saðlar
        isPaused = false;
    }

    void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; // Oyunu duraklatýr
        isPaused = true;
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Zaman ölçeðini normal hýzda ayarlayýn
        SceneManager.LoadScene("MainMenu"); // Ana menü sahnesine dönüþ
    }
}
