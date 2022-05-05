using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
   
    int gameState = 0; // 0 : Menu, 1 : MapSelect, 2 : MidScene, 3 : MainScene,
                       // 4 : ObjectScene, 5 : GameOverScene, 6 : EndScene
    public GameObject[] sceneManagers;
    public GameObject[] objectSceneManagers;
    int stageNum = 1, mapNum = 0, objectMapNum = 0;
    int[] stage_map_num = { 2, 3, 4 };
    int[] stage_object_map_num = { 1, 4, 0 };
    float time = 0;
    bool onetime = true;
    GameObject movingLight;
    AudioSource audioSource;
    public AudioClip[] audioClips;
    public AudioClip[] screams;

    //ItemPage
    public GameObject[] itemSM;
    public bool sceneLoaded;

    //추가 생성 방지
    private static GameManager gameManagerInstance;
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (gameManagerInstance == null)
        {
            gameManagerInstance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        audioSource = this.gameObject.GetComponent<AudioSource>();
        sceneLoaded = false;
    }
    private void FixedUpdate()
    {
        
        time += Time.fixedDeltaTime;

        if(onetime && gameState == 3)
        {
            if (sceneManagers != null && sceneManagers.Length != stage_map_num[stageNum])
                sceneManagers = GameObject.FindGameObjectsWithTag("SM");

            if (objectSceneManagers != null && objectSceneManagers.Length != stage_object_map_num[stageNum])
                objectSceneManagers = GameObject.FindGameObjectsWithTag("ObjectSM");

            if (itemSM != null && (itemSM.Length != 1 || itemSM[0] == null))
                itemSM = GameObject.FindGameObjectsWithTag("ItemSM");


            if (sceneLoaded == true && onetime)
            {
                onetime = false;
                Debug.Log("onetime");
                mapNum = 0;
                sceneManagers[0].GetComponent<MainSM>().ONthisScene();
            }

            //Load Check
            if (sceneLoaded != true && sceneManagers != null && sceneManagers.Length == stage_map_num[stageNum]
                && objectSceneManagers != null && objectSceneManagers.Length == stage_object_map_num[stageNum]
                && itemSM != null && itemSM.Length == 1)
            {
                int i;
                bool check = false;
                for (i = 0; i < sceneManagers.Length; i++)
                {
                    if (sceneManagers[i] == null 
                        || sceneManagers[i].GetComponent<MainSM>().LoadCheck() == false) check = true;
                }
                    
                for (i = 0; i < objectSceneManagers.Length; i++)
                    if (objectSceneManagers[i] == null 
                        || objectSceneManagers[i].GetComponent<MainSM>().LoadCheck() == false) check = true;
                for (i = 0; i < itemSM.Length; i++)
                    if (itemSM[i] == null) check = true;

                if (check == false) sceneLoaded = true;
            }

        }
        
    }

    //Scene 이동
    public void MenuToMidScene()
    {
        gameState = 2;
        stageNum = 0;
        mapNum = 0;
        
        MidToMainScene();
        SceneManager.LoadScene("MidScene" + stageNum, LoadSceneMode.Additive);
    }
    public void MenuToMapSelectScene()
    {
        gameState = 1;
        SceneManager.LoadScene("MapSelect");
    }
    public void MapSelectToMidScene(int stageNum)
    {
        gameState = 2;
        this.stageNum = stageNum;
        SceneManager.LoadScene("MidScene" + stageNum);
    }
    public void MidToMainScene()
    {
        StopMusic();
        gameState = 3;
        onetime = true;
        sceneLoaded = false;
        sceneManagers = null;
        objectSceneManagers = null;
        itemSM = null;

        SceneManager.LoadScene("Tab");
        for (int i = 0; i < stage_map_num[stageNum]; i++)
        {
            Debug.Log("Map Loaded" + stageNum.ToString() + i);
            SceneManager.LoadScene(stageNum.ToString() + i, LoadSceneMode.Additive);
        }  

        if(stageNum == 0)
        {
            SceneManager.LoadScene("Drawer", LoadSceneMode.Additive);
        }
        else
        {
            SceneManager.LoadScene("Case", LoadSceneMode.Additive);
            SceneManager.LoadScene("Table", LoadSceneMode.Additive);
            SceneManager.LoadScene("Clock", LoadSceneMode.Additive);
            SceneManager.LoadScene("Postbox", LoadSceneMode.Additive);
        }

        SceneManager.LoadScene("Item" + stageNum, LoadSceneMode.Additive);

        sceneManagers = GameObject.FindGameObjectsWithTag("SM");
        objectSceneManagers = GameObject.FindGameObjectsWithTag("ObjectSM");
        itemSM = GameObject.FindGameObjectsWithTag("ItemSM");
    }

    public void MidSceneDisable()
    {
        SceneManager.UnloadSceneAsync("MidScene" + stageNum);
    }

    public void MainToMidScene()
    {
        stageNum++;
        gameState = 2;
        MidToMainScene();
        SceneManager.LoadScene("MidScene" + stageNum, LoadSceneMode.Additive);
    }

    public void InToItemScene(string itemName)
    {
        itemSM[0].GetComponent<ItemSM>().ONthisScene(itemName);
    }

    public void OffItemScene()
    {
        itemSM[0].GetComponent<ItemSM>().OFFthisScene();
    }

    public void InToObjectScene(int objectNum)
    {
        objectMapNum = objectNum;
        sceneManagers[mapNum].GetComponent<MainSM>().OFFthisScene();
        objectSceneManagers[objectNum].GetComponent<MainSM>().ONthisScene();

    }

    //Main Game내에서 화살표를 통한 Scene 변경 
    public void ToLeftScene()
    {
        Debug.Log("mapNum = " + mapNum);
        sceneManagers[mapNum].GetComponent<MainSM>().OFFthisScene();
        if (mapNum == 0) sceneManagers[stage_map_num[stageNum] - 1].GetComponent<MainSM>().ONthisScene();
        else sceneManagers[mapNum - 1].GetComponent<MainSM>().ONthisScene();
        if (mapNum == 0) mapNum = stage_map_num[stageNum] - 1;
        else mapNum--;
    }
    public void ToRightScene()
    {
        sceneManagers[mapNum].GetComponent<MainSM>().OFFthisScene();
        sceneManagers[(mapNum + 1) % stage_map_num[stageNum]].GetComponent<MainSM>().ONthisScene();
        mapNum = (mapNum + 1) % stage_map_num[stageNum];
    }
    
    public void ToBehindScene()
    {
        objectSceneManagers[objectMapNum].GetComponent<MainSM>().OFFthisScene();
        sceneManagers[mapNum].GetComponent<MainSM>().ONthisScene();
        objectMapNum = -1;
    }

    //게임 끝과 관련
    public void GameOver(int bywhat) //0 : Boom, 1 : Big, 2 : missing
    {
        SceneManager.LoadScene("GameOver" + bywhat);
    }

    public void GameClear(int endingNum)
    {
        SceneManager.LoadScene("GameEnd" + endingNum);
    }

    public void EndToMenuScene()
    {
        SceneManager.LoadScene("Menu");
    }

    public void FoundLight()
    {
        movingLight = GameObject.Find("MovingLight");
        movingLight.GetComponent<MovingLight>().OnLight();
    }

    //Sound 관련
    public void StartMusic(int num)
    {
        audioSource.clip = audioClips[num];
        audioSource.Play();
    }
    public void Scream()
    {
        audioSource.clip = screams[Random.Range(0, screams.Length-1)];
        audioSource.Play();
    }

    public void StopMusic()
    {
        audioSource.Stop();
    }

    public int GetStageNum()
    {
        return stageNum;
    }
}
