using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class movePlayer : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] float m_MoveDistance = 0.1f;
    [Header("keys")]
    [SerializeField] KeyCode m_Left = KeyCode.A;
    [SerializeField] KeyCode m_Go = KeyCode.W;
    [SerializeField] KeyCode m_Right = KeyCode.D;
    [SerializeField] KeyCode m_Back = KeyCode.S;

    void move()
    {
        Vector3 translate;
        translate = Vector3.zero;

        if (Input.GetKey(m_Left))
            translate.x =  -m_MoveDistance;
        if (Input.GetKey(m_Right))
            translate.x = m_MoveDistance;
        if (Input.GetKey(m_Go))
            translate.z = m_MoveDistance;
        if (Input.GetKey(m_Back))
            translate.z =  -m_MoveDistance;

        translate *= Time.deltaTime;

        transform.Translate(translate);
    }

    private void Update()
    {
        move();
    }
}