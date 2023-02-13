using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; //추 후 여러가지의 프리팹을 배열로 저장 할 예정

    private Queue<GameObject> _enemyObjectPool = null;
    private Queue<GameObject> enemyObjectPool;

    private List<Transform> spawnPoint;//지정된 스폰포인트의 위치 저장을 위한 리스트. 부모를 빼기위해 List로 만듦
    private int spawnPointCount = 5;

    private int spawnCount;

    [SerializeField, Range(10,15)]
    private int initCount = 10;
    private int _count;

    [SerializeField]
    private GameObject left_Colltion; //테스트용 변수

    void Start()
    {
        _count = initCount;
        Initialize(_count);
    }


    void FixedUpdate()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("Get Object Success");
            //GetObject();
        }
    }

    /// <summary>
    /// spawnPoint enemyObjectPool 초기화
    /// </summary>
    /// <param name="count"></param>
    private void Initialize(int count)
    {
        if (spawnPoint != null)
        {
            Debug.Log("spawnPoint is not empty.");
            return;
        }
        else if (spawnPoint == null)
        {
            Transform[] _spawnPoint = new Transform[spawnPointCount+1];
            _spawnPoint = GameObject.Find("SpawnPointGroup").GetComponentsInChildren<Transform>();

            spawnPoint.AddRange(_spawnPoint);
            spawnPoint.RemoveAt(0);

            Debug.Log("SpawnPoint Length : " + spawnPoint.Count);
        }

        if (enemyObjectPool.Count > 0)
        {
            Debug.Log("enemyObjectPool is not empty");
            return;
        }
        else if (enemyObjectPool.Count == 0)
        {
            for (int i = 0; i < count; i++)
            {
                enemyObjectPool.Enqueue(CreateEnemyObjectPool());
                //풀에 아무것도 들어있는 게 없다면 넣어주어라, 현재 상황에서는 10개의 오브젝트가 생성된 뒤 꺼져있어야 함.
            }
        }
    }

    private GameObject CreateEnemyObjectPool()//최초로 오브젝트 풀을 생성한 뒤 비활성화
                                                       //=> 10개의 슬롯을 미리 만든 뒤 비활성화 하는 게 맞지않나?
                                                       // 각 오브젝트 프리팹마다 정해진 갯수를 만든 뒤 반납하고 꺼내쓰는 형식이 될 것임
    {
        var obj = Instantiate(enemyPrefab, GameObject.Find("ObjectPoolingGroup").transform).GetComponent<NormalHandler>();
        obj.gameObject.SetActive(false);
        obj.transform.position = spawnPoint[1].transform.position;

        return obj.gameObject;
    }

    //public static GameObject GetObject()//오브젝트 요청
    //{
    //    if( > 0)//오브젝트가 하나라도 있으면 위치를 랜덤설정하고 가진것을 꺼내줌
    //    {
    //        var obj = enemyObjectPool.Dequeue();
    //        obj.transform.position = spawnPoint[Random.Range(0, 5)].transform.position;
    //        obj.SetActive(true);

    //        return obj;
    //    }
    //    else
    //    {
    //        var newObj = CreateEnemyObjectPool(); //이 부분 꼭 다시 확인 할 것
    //        newObj.SetActive(true);

    //        return newObj;
    //    }

    //}

    //private void OnTriggerEnter(Collider enemyCol)
    //{
    //    if(enemyCol.gameObject.CompareTag("Left_Collision"))
    //    {
    //        ReturnObject(enemyCol.gameObject);
    //    }
    //}

    //public static void ReturnObject(GameObject enemyObj)//오브젝트 반납
    //{
    //    enemyObj.SetActive(false);
    //    enemyObj.transform.SetParent(Instance.transform);
    //    Instance.enemyObjectPool.Enqueue(enemyObj);
    //}

    public static void ReturnAllObject()//게임 종료 이후 모두 반납
    {

    }

}
