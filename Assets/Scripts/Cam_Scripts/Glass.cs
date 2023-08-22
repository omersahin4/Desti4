using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public bool isCorrect = false;
    private GlassGroup glassGroup;

    private void Awake()
    {
        glassGroup = GetComponentInParent<GlassGroup>();
    }
    public void OnMouseDown()
    {
        if (glassGroup.index == CamOyunuController.instance.currentGameIndex)
        {
            if (isCorrect == false)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
                CamOyunuController.instance.LoseLife();
            }
            else
            {
                GetComponent<SpriteRenderer>().color = Color.green;
                CamOyunuController.instance.currentGameIndex++;

            }
        }
    }
}
