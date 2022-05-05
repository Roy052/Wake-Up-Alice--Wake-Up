using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingLight : MonoBehaviour
{
    private Vector2 mousePosition;
    public bool isON = false;
    void Update()
    {
        if(isON == true)
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            transform.position = new Vector2(mousePosition.x, mousePosition.y);
        }
    }
    public void OnLight()
    {
        isON = true;
    }
}
