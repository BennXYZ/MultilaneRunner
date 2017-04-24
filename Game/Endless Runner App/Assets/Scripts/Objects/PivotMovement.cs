﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PivotMovement : MonoBehaviour
{

    [SerializeField]
    GameObject[] Pivots;

    [SerializeField]
    float speed;

    [SerializeField]
    bool backtrackMovement;
    bool backtracking;

    Rigidbody2D rigid;

    int nextPivot;

    // Use this for initialization
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        nextPivot = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (rigid.velocity.magnitude >= Vector2.Distance(transform.position, Pivots[nextPivot].transform.position) * speed)
            rigid.velocity = (Pivots[nextPivot].transform.position - transform.position) * speed;
        else
            rigid.AddForce((Pivots[nextPivot].transform.position - transform.position).normalized * speed);

        if (Pivots.Length > 1)
            if (rigid.velocity.magnitude < 0.1f && Vector2.Distance(transform.position, Pivots[nextPivot].transform.position) < 0.5f)
            {
                rigid.velocity = Vector2.zero;
                ChangePivot();
            }
    }

    private void ChangePivot()
    {
        if (!backtrackMovement)
        {
            if (nextPivot + 1 >= Pivots.Length)
                nextPivot = 0;
            else
                nextPivot++;
        }
        else
        {
            if (backtracking)
            {
                if (nextPivot - 1 < 0)
                {
                    backtracking = false;
                    nextPivot++;
                }
                else
                    nextPivot--;
            }
            else
            {
                if (nextPivot + 1 == Pivots.Length)
                {
                    backtracking = true;
                    nextPivot--;
                }
                else
                    nextPivot++;
            }
        }
    }
}

