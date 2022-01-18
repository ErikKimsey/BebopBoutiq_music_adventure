using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurntableManager : MonoBehaviour
{

    private TurntableUI m_UI;

    private float m_BeatInterval, m_BeatTimer, m_BeatIntervD8, m_BeatTimerD8;
    private bool m_BeatFull, m_BeatD8;
    private int m_BeatCountFull, m_BeatCountD8;
    private Ray m_Ray;
    private RaycastHit m_Hit;

    private bool m_IsPLaying;

    // mouse
    private Vector3 m_MousePos;

    public float m_BPM;
    private AudioSource m_AudioSource;


    void Start()
    {
        m_AudioSource = GetComponent<AudioSource>();
        m_UI = GetComponent<TurntableUI>();

        if (m_AudioSource.clip)
        {
            m_IsPLaying = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        BeatDetection();

        if (Input.GetMouseButtonDown(0))
        {
            m_Ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(m_Ray, out m_Hit))
            {
                
                Debug.Log("HIT");
                Debug.Log(m_Hit.collider.tag);
                if (m_Hit.collider.tag == "playback_btn")
                {
                    if (m_AudioSource.isPlaying == false)
                    {
                        m_AudioSource.Play();
                        m_UI.StartStopRotation();
                    }
                    else
                    {
                        m_AudioSource.Stop();
                        m_UI.StartStopRotation();
                    }
                }

                if (m_Hit.collider.tag == "record" )
                {
                    Debug.Log(Input.GetMouseButton(0) );
                    if(m_AudioSource.isPlaying && Input.GetMouseButton(0) == true)
                    {
                        m_AudioSource.Pause();
                        m_UI.StartStopRotation();

                    }
                    else if(Input.GetMouseButton(0) == false)
                    {
                        m_AudioSource.Play();
                        m_UI.StartStopRotation();
                    }
                }
            }
        }

    }

    void BeatDetection()
    {
        // beat count
        m_BeatFull = false;
        m_BeatInterval = 60 / m_BPM;
        m_BeatTimer += Time.deltaTime;
        if (m_BeatTimer >= m_BeatInterval)
        {
            m_BeatTimer -= m_BeatInterval;
            m_BeatFull = true;
            m_BeatCountFull++;
        }

        m_BeatD8 = false;
        m_BeatIntervD8 = m_BeatInterval / 8;
        m_BeatTimerD8 += Time.deltaTime;
        if (m_BeatTimerD8 >= m_BeatIntervD8)
        {
            m_BeatTimerD8 -= m_BeatIntervD8;
            m_BeatD8 = true;
            m_BeatCountD8++;
        }
    }
}