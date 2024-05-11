using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class Food : MonoBehaviour
{
    public float gamePoint;
    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.Instance.AddGamePoint(gamePoint);
            FoodManager.Instance.generateFood(transform.position);
            Destroy(gameObject);
        }
    }
    
}
