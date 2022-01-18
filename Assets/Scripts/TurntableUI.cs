using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurntableUI : MonoBehaviour
{

    [SerializeField] private Transform m_Transform;
    [SerializeField] private float m_YRotRate;

    private bool m_IsRotating;
    void Start()
    {
        m_IsRotating = false;
    }

    public void StartStopRotation()
    {
        m_IsRotating = !m_IsRotating;
    }

    public void RotateDisc()
    {
        m_Transform.Rotate(0f, m_YRotRate * Time.deltaTime, 0f);
    }

    public void StopRotation()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(m_IsRotating == true) RotateDisc();
    }
}