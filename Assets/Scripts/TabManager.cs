using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabManager : MonoBehaviour
{
    GameManager gm;
    GameObject[] itemButtons, itemList;
    GameObject infoButton;
    float[,] itemPosition;
    int selectedButtonNum = -1;


    public Text desc_text, desc_text_shadow;
    public bool textbreak = false;

    public bool eatSmall;
    public bool openTime;
    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        itemButtons = GameObject.FindGameObjectsWithTag("ItemButton");
        infoButton = GameObject.Find("InfoButton");
        itemPosition = new float[10, 2];
        itemList = new GameObject[10];

        for(int i = 0; i < 10; i++)
        {
            itemPosition[i, 0] = itemButtons[i].transform.position.x;
            itemPosition[i, 1] = itemButtons[i].transform.position.y;
        }
    }

    public string currentItem()
    {
        if (selectedButtonNum == -1) return "";
        else return itemList[selectedButtonNum].name;
    }

    public int currentItemNum()
    {
        return selectedButtonNum;
    }

    public bool isItemExist(string name)
    {
        for (int i = 0; i < itemList.Length; i++)
            if (itemList[i] != null && itemList[i].name == name) return true;

        return false;
    }

    public void inTabItemPushed(int buttonNum)
    {
        Debug.Log("currentNum : " + buttonNum);

        //눌렀던거 누름
        if (selectedButtonNum == buttonNum)
            selectedButtonNum = -1;
        else
        {
            //처음 누름
            if (selectedButtonNum != -1)
                itemButtons[selectedButtonNum].GetComponent<ItemButton>().itemButtonSelected();
            selectedButtonNum = buttonNum;
            StartCoroutine(typeText(itemList[buttonNum].name));
        }
            

        itemButtons[buttonNum].GetComponent<ItemButton>().itemButtonSelected();
    }

    public void InfoButtonPushed()
    {
        if(selectedButtonNum != -1)
        {
            gm.InToItemScene(itemList[selectedButtonNum].name);
        }
    }

    public int ItemAdded(string name)
    {
        GameObject temp = GameObject.Find(name);
        int i;
        for (i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] == null)
            {
                itemList[i] = temp;
                temp.transform.position = new Vector3(itemPosition[i, 0], itemPosition[i, 1], -2);
                if (temp.name == "Key_0")
                    temp.transform.localScale = new Vector3(0.6f, 0.6f, 1);
                if (temp.name == "Letter_0")
                    temp.transform.localScale = new Vector3(1, 1, 1);
                temp.GetComponent<SpriteRenderer>().sortingLayerName = "Item";
                Debug.Log(new Vector2(itemPosition[i, 0], itemPosition[i, 1]));
                break;
            }
        }
        return i;
    }

    public void ItemDelete(int itemNum)
    {
        itemList[itemNum].SetActive(false);
        itemList[itemNum] = null;
    }

    public IEnumerator typeText(string texts)
    {
        Debug.Log("TypeText" + texts);
        desc_text.text = "";
        desc_text_shadow.text = "";

        textbreak = true;
        yield return new WaitForSeconds(0.1f);
        textbreak = false;

        for (int i = 0; i < texts.Length; i++)
        {
            desc_text.text = desc_text.text + texts[i];
            desc_text_shadow.text = desc_text_shadow.text + texts[i];
            yield return new WaitForSeconds(0.05f);
            if (textbreak == true) break;
        }
    }

    public void FoundLight()
    {
        gm.FoundLight();
    }

    public void StartMusic(int num)
    {
        gm.StartMusic(num);
    }
}
