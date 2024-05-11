using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodManager : Singleton<FoodManager>
{
    
    public GameObject prefabApple;
    public GameObject prefabPear;
    public GameObject prefabOrange;
    public GameObject prefabEgg;
    public GameObject prefabCoin;
    public Vector3 rectangleLeftLowerCorner;
    public Vector3 rectangleRightUpperCorner;
    void Start()
    {

        GameObject[] prefabs = new GameObject[] { prefabApple, prefabPear, prefabOrange, prefabEgg, prefabCoin };
        // 随机选择一个预制体实例化
        int randomIndex = Random.Range(0, prefabs.Length); // 生成0或1的随机数
        GameObject selectedPrefab = prefabs[randomIndex];
        Instantiate(selectedPrefab, new Vector3(-16,1,1), Quaternion.identity);
    }

    public void generateFood(Vector3 originPoint)
    {
        GameObject[] prefabs = new GameObject[] { prefabApple, prefabPear, prefabOrange, prefabEgg, prefabCoin };
        // 随机选择一个预制体实例化
        int randomIndex = Random.Range(0, prefabs.Length); // 生成0或1的随机数
        GameObject selectedPrefab = prefabs[randomIndex];
        //矩形范围内且不同于原点
        Instantiate(selectedPrefab, GetRandomPosition(rectangleLeftLowerCorner,rectangleRightUpperCorner,originPoint), Quaternion.identity);
    }
    
    //随机生成矩形坐标内整数点 且该点不存在tag为player的对象
    public Vector3 GetRandomPosition(Vector3 rectangleLeftLowerCorner, Vector3 rectangleRightUpperCorner,Vector3 originPoint)
    {
        Vector3 targetPoint=Vector3.zero;
        bool jud = false;
        if (!jud)
        {
            int randX = Random.Range(Mathf.FloorToInt(rectangleLeftLowerCorner.x) ,
                Mathf.FloorToInt(rectangleRightUpperCorner.x) );
            int randZ = Random.Range(Mathf.FloorToInt(rectangleLeftLowerCorner.z) ,
                Mathf.FloorToInt(rectangleRightUpperCorner.z) );

            targetPoint = new Vector3(randX, rectangleLeftLowerCorner.y, randZ);
            if (Physics.CheckSphere(targetPoint, 1f, 1 << LayerMask.NameToLayer("Player")))
            {
                jud = false;
            }
            else
            {
                jud = true;
            }
        }
        return targetPoint;
    }
    
}
