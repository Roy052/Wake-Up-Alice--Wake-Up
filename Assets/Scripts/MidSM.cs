using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidSM : MonoBehaviour
{
    public GameObject[] cut;
    GameManager gm;

    private void Start()
    {
        gm = GameObject.Find("GameManager").GetComponent<GameManager>();
        for (int i = 0; i < cut.Length; i++)
            cut[i].SetActive(false);

        StartCoroutine(CutScene());
    }

    IEnumerator CutScene()
    {
        yield return new WaitForSeconds(1);
        for (int i = 0; i < cut.Length; i++)
        {
            cut[i].SetActive(true);
            yield return new WaitForSeconds(2);
        }

        if (cut.Length == 5)
            gm.EndToMenuScene();
        else
        {
            while (true)
            {
                if (gm.sceneLoaded == true)
                {
                    //if (gm.GetStageNum() == 1)
                     //   yield return new WaitForSeconds(2f);
                   // else
                        yield return new WaitForSeconds(1f);
                    gm.MidSceneDisable();
                    break;
                }
                else
                    yield return new WaitForSeconds(0.1f);
            }

        }
            
    }
}
