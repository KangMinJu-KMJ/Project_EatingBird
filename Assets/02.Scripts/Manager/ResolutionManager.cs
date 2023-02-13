using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ResolutionManager : Singleton<ResolutionManager>
{
    //[SerializeField]
    //CanvasScaler thisCanvas;

    int SetWidth = 16;
    int SetHeight = 9;

    void Start()
    {
        Screen.SetResolution(Screen.width, Screen.width * SetWidth / SetHeight, true);

        //Default 해상도 비율
        //float fixedAspectRatio = 9f / 16f;
        
        

        //현재 해상도의 비율
        //float currentAspectRatio = (float)Screen.width / (float)Screen.height;

        /*
        //현재 해상도 가로 비율이 더 길 경우
        if (currentAspectRatio > fixedAspectRatio) thisCanvas.matchWidthOrHeight = 0.5f;//캔버스의 Match 조절함
        //현재 해상도의 세로 비율이 더 길 경우
        else if (currentAspectRatio < fixedAspectRatio) thisCanvas.matchWidthOrHeight = 0;
        */
    }

    //void OnPreCull() => GL.Clear(true, true, Color.black);
}
