using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemButton : MonoBehaviour
{
    int buttonNum;
    bool selected = false;
    SpriteRenderer spriteRenderer;
    TabManager tabManager;
    public Sprite selectedSprite, notSelectedSprite;

    private void Start()
    {
        tabManager = GameObject.Find("TabManager").GetComponent<TabManager>();
        spriteRenderer = this.GetComponent<SpriteRenderer>();
        buttonNum = this.name[6] - '0';
    }


    public void itemButtonSelected()
    {
        if (selected)
        {
            selected = false;
            spriteRenderer.sprite = notSelectedSprite;
        }
        else
        {
            selected = true;
            spriteRenderer.sprite = selectedSprite;
        }
    }
}
