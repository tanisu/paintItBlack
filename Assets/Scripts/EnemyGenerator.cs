using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    void Start()
    {
        Instantiate(enemy, Vector2.zero, Quaternion.identity, transform);
    }

}
