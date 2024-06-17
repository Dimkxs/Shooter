using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneShotKill : MonoBehaviour
{
    public GameObject bulletPrefab; // префаб пули
    public float bulletSpeed = 10f; // скорость пули
    public int damage = 100; // урон от пули
    public Transform gunTip; // конец ствола оружия
    public LineRenderer aimLine; // линия прицела

    private bool hasShot = false; // флаг, указывающий на то, что уже был сделан выстрел

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !hasShot)
        {
            Shoot();
        }

        // отображаем прицел
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
                hasShot = false; // сбрасываем флаг, чтобы можно было сделать следующий выстрел
            }
        }
    }
}

