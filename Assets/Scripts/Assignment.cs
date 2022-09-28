using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Assignment : ProcessingLite.GP21
{
    float diameter = 0.1f;
    float spaceBetweenLines = 0.15f;
    private Image m_preview;

    public static bool m_toggleRainbow = true;
    public static float r;
    public static float g;
    public static float b;

    void Start()
    {
        m_preview = GameObject.Find("ColorPreview").GetComponent<Image>();
    }

    void Update()
    {

        if(m_toggleRainbow)
        {
            Rainbow();
            GameObject.Find("Red").GetComponent<Slider>().value = r;
            GameObject.Find("Green").GetComponent<Slider>().value = g;
            GameObject.Find("Blue").GetComponent<Slider>().value = b;
        }
        else
        {
        Debug.Log("???");
            r = GameObject.Find("Red").GetComponent<Slider>().value;
            g = GameObject.Find("Green").GetComponent<Slider>().value;
            b = GameObject.Find("Blue").GetComponent<Slider>().value;
        }

        diameter = GameObject.Find("Size").GetComponent<Slider>().value;

        m_preview.color = new Color(r/255,g/255,b/255);
        //Prepare our stroke settings
        Stroke((int)r, (int)g, (int)b, 255);
        StrokeWeight(0.5f);

        if(Input.GetButton("M1") && Input.mousePosition.x > Camera.main.pixelWidth/5)
        {
            Circle(MouseX,MouseY,diameter); //Draws a circle on screen.
            Fill((int)r,(int)g,(int)b);
        }
    }

    void Rainbow()
    {
        if(r!=255 && g!=255 && b!=255)
        {
            r++;
            g--;
            b--;
        }
        else if(r==255 && (g>0 && b>0) || g==255 && (b>0 && r>0))
        {
            g--;
            b--;
        }
        else if(r==255 && g<255 && b<=0)
        g++;
        else if(r>0 && g==255 && b<=0)
        r--;
        else if(r<=0 && g==255 && b<255)
        b++;
        else if(r<=0 && g>0 && b==255)
        g--;
        else if(r<255 && g<=0 && b==255)
        r++;
        else if(r==255 && g<=0 && b>0)
        b--;
    }
}
