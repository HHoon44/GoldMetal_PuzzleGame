using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using TreeEditor;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class Dongle : MonoBehaviour
{
    public int level;

    public bool isDrag;

    private Rigidbody2D rigid;

    private void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (isDrag)
        {
            // ScreenToWorldPoint : ��ũ�� ��ǥ�� ����� ��ȯ
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float leftBorder = -4.2f + transform.localScale.x / 2f;
            float rightBorder = 4.2f - transform.localScale.x / 2f;

            // ���� ���� ��谪���� X�� �̵� ����
            if (mousePos.x < leftBorder)
            {
                mousePos.x = leftBorder;
            }
            else if (mousePos.x > rightBorder)
            {
                mousePos.x = rightBorder;
            }

            mousePos.y = 8;
            mousePos.z = 0;
            transform.position = Vector3.Lerp(transform.position, mousePos, 0.01f);
        }
    }

    public void Drag()
    {
        isDrag = true;
    }

    public void Drop()
    {
        isDrag = false;
        rigid.simulated = true;
    }
}
