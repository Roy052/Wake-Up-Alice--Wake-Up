using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndSM : MonoBehaviour
{
    GameManager gm;
    public string[] inputTexts;
    public Text explainText;
    public Text shadowText;
    public GameObject background;
    public Sprite[] spriteList;
    public int[] spriteTime;
    int spriteNum = 0;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(TypeText());
    }

    IEnumerator TypeText()
    {
        if(inputTexts != null)
            for(int i = 0; i < inputTexts.Length; i++)
            {
                explainText.text = "";
                shadowText.text = "";
                if(spriteList != null && spriteList.Length > spriteNum && i == spriteTime[spriteNum])
                {
                    background.GetComponent<SpriteRenderer>().sprite = spriteList[spriteNum];
                    spriteNum++;
                }

                for(int j = 0; j < inputTexts[i].Length; j++)
                {
                    explainText.text = explainText.text + inputTexts[i][j];
                    shadowText.text = shadowText.text + inputTexts[i][j];
                    yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(1);
            }

        gm.EndToMenuScene();
    }
}
