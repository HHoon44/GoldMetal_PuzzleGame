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

        // 코루틴 제어를 시작하기 위한 함수
        StartCoroutine(WaitNext());
    }

    IEnumerator WaitNext()
    {
        while (lastDongle != null)
        {
            yield return null;
        }

        // 2.5초 쉬고 아래 로직 실행
        // yield 없이 코루틴을 돌리면 무한루프에 빠짐
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