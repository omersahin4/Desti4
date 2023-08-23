using UnityEngine;
using UnityEngine.SceneManagement;

public class levelupbutton : MonoBehaviour
{
    public void SwitchToNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = (currentSceneIndex + 1) % SceneManager.sceneCountInBuildSettings;
        SceneManager.LoadScene(nextSceneIndex);
    }
}