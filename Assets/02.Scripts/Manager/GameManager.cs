using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public bool isGameStart;

    private GameObject _optionImage = null;
    private GameObject _sfxCheckImage = null;
    private GameObject _bgmCheckImage = null;

    private GameObject optionImage { get { if (_optionImage == null) _optionImage =
                      GameObject.Find("UI_Canvas").transform.Find("Option_Image").gameObject; return _optionImage; } }
    private GameObject sfxCheckImage { get { if (_sfxCheckImage == null) _sfxCheckImage =
                      GameObject.Find("UI_Canvas").transform.Find("Option_Image")
                      .transform.GetChild(1).transform.GetChild(0).gameObject; return _sfxCheckImage; } }
    private GameObject bgmCheckImage { get { if (_bgmCheckImage == null) _bgmCheckImage =
                      GameObject.Find("UI_Canvas").transform.Find("Option_Image")
                    .transform.GetChild(2).transform.GetChild(0).gameObject; return _bgmCheckImage;
        }
    }

    void Start()
    {
        Initialize();
    }


    void FixedUpdate()
    {

    }

    public void Initialize()
    {
        isGameStart = true;
    }

    public void MovePlayScene()//Start Scene에서 Start 버튼 클릭
    {
        SceneManager.LoadScene("Play_Scene");
    }

    public void MoveStartScene()//Play Scene에서 다시하기 버튼 클릭
    {
        SceneManager.LoadScene("Start_Scene");
    }

    public void ExitGame()// Start Scene에서 Exit 버튼 클릭
    {
        Application.Quit();
    }

    public void OptionMenuOn()// 옵션 UI 활성화
    {
        optionImage.SetActive(true);
    }

    public void OptionMenuOff()// 옵션 UI 비활성화
    {
        optionImage.SetActive(false);
    }


}
