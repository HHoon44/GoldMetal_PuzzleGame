using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Dongle lastDongle;
    public GameObject donglePrefab;
    public Transform dongleGroup;

    private void Start()
    {
        NextDongle();
    }

    private Dongle GetDongle()
    {
        GameObject instance = Instantiate(donglePrefab, dongleGroup);
        Dongle instanceDongle = instance.GetComponent<Dongle>();
        return instanceDongle;
    }

    private void NextDongle()
    {
        Dongle newDongle = GetDongle();
        lastDongle = newDongle;

        // �ڷ�ƾ ��� �����ϱ� ���� �Լ�
        StartCoroutine(WaitNext());
    }

    IEnumerator WaitNext()
    {
        while (lastDongle != null)
        {
            yield return null;
        }

        // 2.5�� ���� �Ʒ� ���� ����
        // yield ���� �ڷ�ƾ�� ������ ���ѷ����� ����
        yield return new WaitForSeconds(2.5f);

        NextDongle();
    }

    public void TouchDown()
    {
        if (lastDongle == null)
        {
            return;
        }

        lastDongle.Drag();
    }

    public void TouchUp()
    {
        if (lastDongle == null)
        {
            return;
        }

        lastDongle.Drop();
        lastDongle = null;
    }
}