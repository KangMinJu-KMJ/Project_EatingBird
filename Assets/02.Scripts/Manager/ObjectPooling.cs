using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    [SerializeField]
    private GameObject enemyPrefab; //�� �� ���������� �������� �迭�� ���� �� ����

    private Queue<GameObject> _enemyObjectPool = null;
    private Queue<GameObject> enemyObjectPool;

    private List<Transform> spawnPoint;//������ ��������Ʈ�� ��ġ ������ ���� ����Ʈ. �θ� �������� List�� ����
    private int spawnPointCount = 5;

    private int spawnCount;

    [SerializeField, Range(10,15)]
    private int initCount = 10;
    private int _count;

    [SerializeField]
    private GameObject left_Colltion; //�׽�Ʈ�� ����

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
    /// spawnPoint enemyObjectPool �ʱ�ȭ
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
                //Ǯ�� �ƹ��͵� ����ִ� �� ���ٸ� �־��־��, ���� ��Ȳ������ 10���� ������Ʈ�� ������ �� �����־�� ��.
            }
        }
    }

    private GameObject CreateEnemyObjectPool()//���ʷ� ������Ʈ Ǯ�� ������ �� ��Ȱ��ȭ
                                                       //=> 10���� ������ �̸� ���� �� ��Ȱ��ȭ �ϴ� �� �����ʳ�?
                                                       // �� ������Ʈ �����ո��� ������ ������ ���� �� �ݳ��ϰ� �������� ������ �� ����
    {
        var obj = Instantiate(enemyPrefab, GameObject.Find("ObjectPoolingGroup").transform).GetComponent<NormalHandler>();
        obj.gameObject.SetActive(false);
        obj.transform.position = spawnPoint[1].transform.position;

        return obj.gameObject;
    }

    //public static GameObject GetObject()//������Ʈ ��û
    //{
    //    if( > 0)//������Ʈ�� �ϳ��� ������ ��ġ�� ���������ϰ� �������� ������
    //    {
    //        var obj = enemyObjectPool.Dequeue();
    //        obj.transform.position = spawnPoint[Random.Range(0, 5)].transform.position;
    //        obj.SetActive(true);

    //        return obj;
    //    }
    //    else
    //    {
    //        var newObj = CreateEnemyObjectPool(); //�� �κ� �� �ٽ� Ȯ�� �� ��
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

    //public static void ReturnObject(GameObject enemyObj)//������Ʈ �ݳ�
    //{
    //    enemyObj.SetActive(false);
    //    enemyObj.transform.SetParent(Instance.transform);
    //    Instance.enemyObjectPool.Enqueue(enemyObj);
    //}

    public static void ReturnAllObject()//���� ���� ���� ��� �ݳ�
    {

    }

}
