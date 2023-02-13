using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private RectTransform stick;//��ƽ�κ��� Rect
    private RectTransform backRect;//Pad�� ����� �Ǵ� �̹����� Rect
    private Canvas mainCan;

    [SerializeField, Range(10, 150)]
    private float leverRange;

    private Vector2 inputDirection;
    private bool isInput;
    private Vector2 initPos = Vector2.zero;// ��ũ����ǥ�� ��� startPos

    private PlayerMovement playerMovement;//�÷��̾����� ��ǥ�����������
    //private Camera uiCam;//UI�� �����ִ� ī�޶�

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


    public void OnDrag(PointerEventData eventData)//�巡���ϴµ��� �е� ������ + �������� �÷��̾�� ����
    {
        var scaledAnchoredPosition = backRect.anchoredPosition * mainCan.transform.localScale.x;
        //ĵ���������Ϸ��� UI Scale Mode�� Scale With Screen Size�⿡ ��ǥ�� ������ �� �ִ� ����.
        var inputPos = eventData.position - scaledAnchoredPosition;
        var inputVector = inputPos.magnitude < leverRange ? inputPos : inputPos.normalized * leverRange;
        //inputPos�� ���̰� leverRange���� Ŀ��������, inputPos�� ����ȭ �� �� leverRange�� ���� �� �ȿ� ���д�.
        stick.anchoredPosition = inputVector;//��������� �Ÿ��� ������.
        inputDirection = inputVector / leverRange;//inputVector�� �״�� ���� ���� �ʹ� Ŀ���� ����ȭ��.
        //�� inputDirection�� player���� ����.

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