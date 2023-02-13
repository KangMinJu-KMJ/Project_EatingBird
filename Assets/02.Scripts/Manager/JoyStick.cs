using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private RectTransform stick;//스틱부분의 Rect
    private RectTransform backRect;//Pad의 배경이 되는 이미지의 Rect
    private Canvas mainCan;

    [SerializeField, Range(10, 150)]
    private float leverRange;

    private Vector2 inputDirection;
    private bool isInput;
    private Vector2 initPos = Vector2.zero;// 스크린좌표가 담길 startPos

    private PlayerMovement playerMovement;//플레이어한테 좌표전달해줘야함
    //private Camera uiCam;//UI를 보여주는 카메라

    void Start()
    {
        Initialize();
        
    }


    void FixedUpdate()
    {
        if(isInput)
        {
            InputControl();
        }
    }


    void Initialize()
    {
        mainCan = GameObject.Find("UI_Canvas").GetComponent<Canvas>();
        stick = GameObject.Find("Joystick").transform.GetChild(0).GetComponent<RectTransform>();
        backRect = GetComponent<RectTransform>();
        isInput = false;
        //uiCam = GameObject.Find("UI_Camera").GetComponent<Camera>();
        //uiCam = Camera.main;
       
        playerMovement = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }

    private void InputControl()
    {
        playerMovement.OnStickChanged(inputDirection);
    }


    public void OnDrag(PointerEventData eventData)//드래그하는동안 패드 움직임 + 움직임을 플레이어에게 전달
    {
        var scaledAnchoredPosition = backRect.anchoredPosition * mainCan.transform.localScale.x;
        //캔버스스케일러의 UI Scale Mode가 Scale With Screen Size기에 좌표를 재조정 해 주는 과정.
        var inputPos = eventData.position - scaledAnchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        //inputPos의 길이가 leverRange보다 커져버리면, inputPos를 정규화 한 뒤 leverRange를 곱해 그 안에 가둔다.
        stick.anchoredPosition = inputVector;//여기까지는 거리를 구했음.
        inputDirection = inputVector / leverRange;//inputVector를 그대로 쓰면 값이 너무 커져서 정규화함.
        //이 inputDirection을 player에게 전달.

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        isInput = true;
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isInput = false;
        stick.anchoredPosition = initPos;
        playerMovement.OnStickChanged(Vector2.zero);
    }


}