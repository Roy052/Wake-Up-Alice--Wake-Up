# Wake Up Alice, Wake Up
<div>
    <h2> 게임 정보 </h2>
    <img src = "https://img.itch.zone/aW1nLzg2NDE1NDYucG5n/347x500/7%2BAG26.png"><br>
    <img src="https://img.shields.io/badge/Unity-yellow?style=flat-square&logo=Unity&logoColor=FFFFFF"/>
    <img src="https://img.shields.io/badge/Horror-black"/>
    <img src="https://img.shields.io/badge/Puzzle-purple"/>
    <h4> 개발 일자 : 2022.04 <br><br>
    플레이 : https://goodstarter.itch.io/wake-up-alice-wake-up
    
  </div>
  <div>
    <h2> 게임 설명 </h2>
    <h3> 스토리 </h3>
     당신은 런던에 사는 앨리스이다.<br><br>
     깊은 밤, 창밖에서 누군가 앨리스의 이름을 부른다.<br><br>
     "Wake Up Alice, Wake Up"<br><br>
     토끼를 따라가 문제를 해결해야한다.
    <h3> 게임 플레이 </h3>
     포인트 앤 클릭 형식으로 이루어진 방탈출 게잉미다.<br><br>
     하단에 있는 Information/Eat Button를 통해 아이템을 살펴보거나 사용할 수 있다.<br><br>
     랜턴을 이용하여 방 안을 밝힐 수 있다. 
     <h3> 추가 내용 </h3>
     itch.io에서 열린 'Themed Horror Game Jam #5' 출품작이다.
  </div>
  <div>
    <h2> 게임 스크린샷 </h2>
      <table>
        <td><img src = "https://img.itch.zone/aW1hZ2UvMTQ4MTg0NS84ODQ0MzAzLnBuZw==/347x500/kOJfKI.png"></td>
        <td><img src = "https://img.itch.zone/aW1hZ2UvMTQ4MTg0NS84ODQ0MzA1LnBuZw==/347x500/AVV0sq.png"></td>
        <td><img src = "https://img.itch.zone/aW1hZ2UvMTQ4MTg0NS84ODQ0MzA0LnBuZw==/347x500/E2YKJS.png"></td>
      </table>
  </div>
    <div>
    <h2> 게임 플레이 영상 </h2>
    https://youtu.be/XSUDbSZ6rL4
  </div>
  <div>
    <h2> 배운 점 </h2>
      여러 씬을 한 화면에 담는 방식으로 제작했다.<br><br>
      그러다보니 최적화 이슈가 생겼다.<br><br>
      이 문제를 해결하기 위해 씬 사이에 애니메이션을 추가하고, 로드되었는지를 체크하는 함수를 추가했다.<br><br>
      또한, 여러 씬 사이에 오브젝트 순서와 스프라이트 순서를 제대로 그리고 제대로 작동해야 했다.<br><br>
      그래서 SpriteRenderrer and Physics에 대해 많이 배웠다.(Layer order and position)
  </div>
  <div>
    <h2> 수정할 점 </h2>
      컨텐츠 추가<br><br>
      조금 더 최적화 문제 해결
   <h2> Design Picture </h2>
   <table>
        <td><img src = "https://postfiles.pstatic.net/MjAyMjA0MTFfNTQg/MDAxNjQ5Njc5Mjc1MDYy.scIPPxZrUqD1IwGQFHNcEtM9pEki5LHxQOetbUeqlBAg.Dg9OApan3D7fS2uSO9xaqKeO8u0Z2rmKBYN3aBrUli8g.JPEG.tdj04131/20220411_211214.jpg?type=w773" height = 500></td>
        <td><img src = "https://postfiles.pstatic.net/MjAyMjA0MTFfMTIw/MDAxNjQ5Njc5Mjc1MDcz._pDf8x_2chUlTG4DIL4ggrqmolpUDaBMtGTZZ8cpPWEg.OxH-9lk8Gp59WZBNQycTtogBG6CRhB-cDZN-euzxksAg.JPEG.tdj04131/20220411_211237.jpg?type=w773" height = 500></td>
     <td><img src = "https://postfiles.pstatic.net/MjAyMjA0MTFfMTAz/MDAxNjQ5Njc5Mjc1NTYy.UOR3270-KfcJpc8XXaRSu3jCmNtEOoJMgTWfX9x1t-8g.LB2kQYzJfR4kNbOgUfElVM_nKw6_0aicBIONa5_j6n8g.JPEG.tdj04131/20220411_211253.jpg?type=w773" height = 500></td>
      </table>
  </div>
<div>
       <h2> 주요 코드 </h2>
       <h4> GameManager 로드 확인 코드 </h4>
    </div>

```csharp
    
//실행 확인 및 씬 확인
if(onetime && gameState == 3)
{
    //각 씬 스크립트 로드
    if (sceneManagers != null && sceneManagers.Length != stage_map_num[stageNum])
        sceneManagers = GameObject.FindGameObjectsWithTag("SM");

    if (objectSceneManagers != null && objectSceneManagers.Length != stage_object_map_num[stageNum])
        objectSceneManagers = GameObject.FindGameObjectsWithTag("ObjectSM");

    if (itemSM != null && (itemSM.Length != 1 || itemSM[0] == null))
        itemSM = GameObject.FindGameObjectsWithTag("ItemSM");
    
    //게임 시작
    if (sceneLoaded == true && onetime)
    {
        onetime = false;
        Debug.Log("onetime");
        mapNum = 0;
        sceneManagers[0].GetComponent<MainSM>().ONthisScene();
    }

    //로드 확인
    if (sceneLoaded != true && sceneManagers != null && sceneManagers.Length == stage_map_num[stageNum]
        && objectSceneManagers != null && objectSceneManagers.Length == stage_object_map_num[stageNum]
        && itemSM != null && itemSM.Length == 1)
    {
        int i;
        bool check = false;
    
        //게임이 진행되는 메인 씬에 있는 오브젝트가 로드 되었는가?
        for (i = 0; i < sceneManagers.Length; i++)
            if (sceneManagers[i] == null 
                || sceneManagers[i].GetComponent<MainSM>().LoadCheck() == false) check = true;
        
        //획득한 아이템을 두는 오브젝트 씬에 있는 오브젝트가 로드 되었는가?
        for (i = 0; i < objectSceneManagers.Length; i++)
            if (objectSceneManagers[i] == null 
                || objectSceneManagers[i].GetComponent<MainSM>().LoadCheck() == false) check = true;
        
        //아이템 정보를 보여주는 스크립트가 로드 되었는가?
        for (i = 0; i < itemSM.Length; i++)
            if (itemSM[i] == null) check = true;
                                      
    if (check == false) sceneLoaded = true;
    }

}
```
