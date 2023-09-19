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
            // ScreenToWorldPoint : 스크린 좌표를 월드로 변환
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            float leftBorder = -4.2f + transform.localScale.x / 2f;
            float rightBorder = 4.2f - transform.localScale.x / 2f;

            // 좌측 우측 경계값으로 X축 이동 제한
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
