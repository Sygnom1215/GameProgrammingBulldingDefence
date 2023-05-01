using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Scripting.APIUpdating;

public class Cat : MonoBehaviour
{
    public GameObject buil;

    GameObject[] gos;
    GameObject closest = null;

    Transform closestTrans;
    Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();

    }

    private void Start()
    {

    }

    void Update()
    {
        FindClosestEnemy();

        Move();
    }

    private void Move()
    {
        if (closest != null)
        {
            Vector3 moveDir = (closest.transform.position - transform.position).normalized;
            float moveSpeed = 10f;

            rigid.velocity = moveDir * moveSpeed;
        }
        else
        {
            rigid.velocity = Vector2.zero;
        }
    }

    GameObject FindClosestEnemy()
    {
        gos = GameObject.FindGameObjectsWithTag("Enemy");
        float distance = Mathf.Infinity;
        Vector3 position = transform.position;
        foreach (GameObject go in gos)
        {
            Vector3 diff = go.transform.position - position;
            float curDistance = diff.sqrMagnitude;
            if (curDistance < distance)
            {
                closest = go;
                distance = curDistance;
            }
        }
        return closest;
    }
}

