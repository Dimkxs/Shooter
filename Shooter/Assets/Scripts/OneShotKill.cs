using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotKill : MonoBehaviour
{
    public GameObject bulletPrefab; // ������ ����
    public float bulletSpeed = 10f; // �������� ����
    public int damage = 100; // ���� �� ����
    public Transform gunTip; // ����� ������ ������
    public LineRenderer aimLine; // ����� �������

    private bool hasShot = false; // ����, ����������� �� ��, ��� ��� ��� ������ �������

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasShot)
        {
            Shoot();
        }

        // ���������� ������
        RaycastHit hit;
        if (Physics.Raycast(gunTip.position, gunTip.forward, out hit, 100f))
        {
            aimLine.SetPosition(0, gunTip.position);
            aimLine.SetPosition(1, hit.point);
        }
        else
        {
            aimLine.SetPosition(0, gunTip.position);
            aimLine.SetPosition(1, gunTip.position + gunTip.forward * 100f);
        }
    }

    void Shoot()
    {
        hasShot = true;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                hasShot = false; // ���������� ����, ����� ����� ���� ������� ��������� �������
            }
        }
    }
}

