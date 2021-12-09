using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class DayNightCycle : MonoBehaviour
{
    private Canvas m_Canvas;
    public GameObject nightImage;
    public GameObject dayImage;
    private void Awake()
    {
        m_Canvas = GetComponent<Canvas>();
        if (m_Canvas == null)
        {
            //create a new canvas and populate appropriately
        }

    }

    /*private void Start()
    {
        if (dayImage == null || nightImage == null)
        {
            dayImage = GameObject.FindWithTag("DayBG");
            nightImage = GameObject.FindWithTag("NightBG");
        }
    }*/
    
    public void OnDayNightButton()
    {
        if (dayImage.activeSelf)
        {
            dayImage.SetActive(false);
            nightImage.SetActive(true);
            Debug.Log("Nighttime!");
        }

        else if (nightImage.activeSelf)
        {
            dayImage.SetActive(true);
            nightImage.SetActive(false);
            Debug.Log("Daytime!");
        }
        else
        {
            Debug.Log("What fucking time is it?!?!???? I'm dying HEEEEEELLLLPPP, this is the end, ohfuck ofuck oh fuck ufcuk!!");
        }
        

    }
}
