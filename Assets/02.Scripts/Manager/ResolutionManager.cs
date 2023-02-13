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

        //Default �ػ� ����
        //float fixedAspectRatio = 9f / 16f;
        
        

        //���� �ػ��� ����
        //float currentAspectRatio = (float)Screen.width / (float)Screen.height;

        /*
        //���� �ػ� ���� ������ �� �� ���
        if (currentAspectRatio > fixedAspectRatio) thisCanvas.matchWidthOrHeight = 0.5f;//ĵ������ Match ������
        //���� �ػ��� ���� ������ �� �� ���
        else if (currentAspectRatio < fixedAspectRatio) thisCanvas.matchWidthOrHeight = 0;
        */
    }

    //void OnPreCull() => GL.Clear(true, true, Color.black);
}
