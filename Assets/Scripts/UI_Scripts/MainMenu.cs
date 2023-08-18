using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject settingsPanel;
    public Slider volumeSlider;
    public AudioSource musicAudioSource;

    private void Start()
    {
        // Baþlangýçta kaydedilen ses seviyesini yükler (varsayýlan olarak 0.5)
        volumeSlider.value = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        musicAudioSource.volume = volumeSlider.value;
    }

    public void OpenSettings()
    {
        settingsPanel.SetActive(true);
    }

    public void CloseSettings()
    {
        settingsPanel.SetActive(false);
    }

    public void OnVolumeChanged()
    {
        musicAudioSource.volume = volumeSlider.value;
        PlayerPrefs.SetFloat("MusicVolume", volumeSlider.value);
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("GameScene");
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
