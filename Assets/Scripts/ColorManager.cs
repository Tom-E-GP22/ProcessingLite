using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ColorManager : MonoBehaviour
{
    private GameObject m_pickerSystem;
    private ToggleGroup m_color;
    private Toggle m_rainbow;
    private Toggle m_RGB;

    private Image m_preview;


    void Start()
    {
        m_color = GameObject.Find("ToggleGroup").GetComponent<ToggleGroup>();
        m_rainbow = GameObject.Find("Rainbow").GetComponent<Toggle>();
        m_RGB = GameObject.Find("RGB Picker").GetComponent<Toggle>();

        m_preview = GameObject.Find("ColorPreview").GetComponent<Image>();

        m_pickerSystem = GameObject.Find("ColorPickSystem");

        m_rainbow.group = m_color;
        m_RGB.group = m_color;
    }

    void Update()
    {
        if(m_rainbow.isOn)
            Assignment.m_toggleRainbow = true;
        else
            Assignment.m_toggleRainbow = false;

        if(m_RGB.isOn)
        {
            m_pickerSystem.SetActive(true);
        }
        else
        {
        }
    }
}
