using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneMoveButton : MonoBehaviour
{
    GameManager gm;
    void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnMouseDown()
    {
        if(this.name == "Left")
        {
            gm.ToLeftScene();
        }
        else if(this.name == "Right")
        {
            gm.ToRightScene();
        }
        else
        {
            gm.ToBehindScene();
        }
    }
}
