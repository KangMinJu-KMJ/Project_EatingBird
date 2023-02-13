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

    public void MovePlayScene()//Start Scene���� Start ��ư Ŭ��
    {
        SceneManager.LoadScene("Play_Scene");
    }

    public void MoveStartScene()//Play Scene���� �ٽ��ϱ� ��ư Ŭ��
    {
        SceneManager.LoadScene("Start_Scene");
    }

    public void ExitGame()// Start Scene���� Exit ��ư Ŭ��
    {
        Application.Quit();
    }

    public void OptionMenuOn()// �ɼ� UI Ȱ��ȭ
    {
        optionImage.SetActive(true);
    }

    public void OptionMenuOff()// �ɼ� UI ��Ȱ��ȭ
    {
        optionImage.SetActive(false);
    }


}
