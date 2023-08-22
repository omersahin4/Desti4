using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class camretrybutton : MonoBehaviour
{
  public void retrybuttonclick()
    {
        Debug.Log("retry");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
