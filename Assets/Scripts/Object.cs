using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public bool interactable;
    public Sprite original, change;
    public string clicktext_interactable_true, clicktext_interactable_false;

    public bool isActivated;
    TabManager tm;

    public int objectNum;
    public bool anotherText = false;

    public MainSM mainSM;

    private void Start()
    {
        tm = GameObject.Find("TabManager").GetComponent<TabManager>();
        Debug.Log(this.name);
    }

    private void OnMouseDown()
    {
        Debug.Log("Onmousedown" + this.name);
        if(mainSM.isON == true)
        {
            if (interactable)
            {
                this.GetComponent<SpriteRenderer>().sprite = change;
                if (!anotherText)
                    StartCoroutine(tm.typeText(clicktext_interactable_true));
            }
            else
            {
                if (!anotherText)
                    StartCoroutine(tm.typeText(clicktext_interactable_false));
            }
        }
    }

}
