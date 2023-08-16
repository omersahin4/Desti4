using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassGroup : MonoBehaviour
{
    public bool success = false;
    public List<Glass> glassGroup;

    /* [System.Serializable]
     public struct Group
     {
         public Glass glass;
         public bool isCorrect;
     }*/
    void Start()
    {
        glassGroup = new List<Glass>();
        Glass[] glassList = GetComponentsInChildren<Glass>();
        foreach (var item in glassList)
        {
            glassGroup.Add(item);
        }
    }
    public void Set()
    {
        bool isBreakable = Random.Range(0f, 1f) < 0.5f;
        glassGroup[0].isCorrect = isBreakable;
        glassGroup[1].isCorrect = !isBreakable;

        /* foreach (var glass in glassGroup)
         {
       //      glass.glassGroup = this;
         }*/
        //group listesi içinde gezicek ve random þekilde birtanesini true bir tanesini false yapýcak
        //Yada manuel oalrak elle girersiniz
    }

}
