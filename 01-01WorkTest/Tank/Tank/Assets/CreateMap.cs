using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateMap : MonoBehaviour
{
    public GameObject[] item;//用来装饰初始化地图所需物体的数组

    //0 老家 1 墙 2.障碍 3.出生效果 4.河流 5.草 6.空气墙

    //产生随机位置
    private List<Vector3> itemPosition = new List<Vector3>();


    public void Awake()
    {
        //实例化老家
        CreateItem(item[0], new Vector3(0, -8, 0), Quaternion.identity);
        //用墙把老家 围起来
        CreateItem(item[1], new Vector3(-1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -8, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(-1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(1, -7, 0), Quaternion.identity);
        CreateItem(item[1], new Vector3(0, -7, 0), Quaternion.identity);
        //实例化外围墙
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, 9, 0), Quaternion.identity);
        }
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(i, -9, 0), Quaternion.identity);
        }
        for (int i = -9; i < 10; i++)
        {
            CreateItem(item[6], new Vector3(-11,i, 0), Quaternion.identity);
        }
        for (int i = -11; i < 12; i++)
        {
            CreateItem(item[6], new Vector3(11, i, 0), Quaternion.identity);
        }

        //实例化地图
        for (int i = 0; i < 40; i++)
        {
            CreateItem(item[1], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[2], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[4], CreateRandomPosition(), Quaternion.identity);
        }
        for (int i = 0; i < 20; i++)
        {
            CreateItem(item[5], CreateRandomPosition(), Quaternion.identity);
        }

        //实例化出生特效
        GameObject ogo = Instantiate(item[3],new Vector3(-2,-8,0),Quaternion.identity);
        ogo.GetComponent<Birth>().createPlayer = true;


        CreateItem(item[3], new Vector3(-10, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(0, 8, 0), Quaternion.identity);
        CreateItem(item[3], new Vector3(10, 8, 0), Quaternion.identity);
        InvokeRepeating("CreateEnemy",4,5);
    }

    private void CreateEnemy()
    {
        int num = Random.Range(0, 3);
        Vector3 enemyPos = new Vector3();
        if (num==0)
        {
            enemyPos = new Vector3(-10, 8, 0);
        }
        else if(num==1)
        {
            enemyPos = new Vector3(0, 8, 0);
        }
        else
        {
            enemyPos = new Vector3(10, 8, 0);
        }
        CreateItem(item[3], enemyPos, Quaternion.identity);
    }

    private void CreateItem(GameObject gameobj,Vector3 positon,Quaternion ratation)
    {
        GameObject itemGo = Instantiate(gameobj, positon,ratation);
        itemPosition.Add(positon);
        itemGo.transform.SetParent(gameObject.transform);
    }

    private Vector3 CreateRandomPosition()
    {
        //不生成x=-10 10 两列 y=-8 8 两行的位置
        while (true)
        {
            Vector3 createPositon = new Vector3(Random.Range(-9,10),Random.Range(-7,8),0);
            if (!itemPosition.Contains(createPositon))
            {               
                return createPositon;
            }
            
        }
    }

}
