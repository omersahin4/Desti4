using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Glass : MonoBehaviour
{
    public bool isCorrect = false;
    private GlassGroup glassGroup;

    public void OnMouseDown()
    {
        if(isCorrect == false)
        {
            GetComponent<SpriteRenderer>().color=Color.red;
        }
        else
        {
            GetComponent<SpriteRenderer>().color = Color.green;
        }
    }
}
