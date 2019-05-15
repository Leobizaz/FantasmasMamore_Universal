using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QualityControl : MonoBehaviour
{

    [SerializeField]


    public Dropdown DropdownQuality;
    public Dropdown DropdownResolution;
    public Toggle FullScreen;



    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
       if (DropdownQuality.value == 0)
       {
           SetVeryLow();
       }
        if (DropdownQuality.value == 1)
       {
           SetLow();
       }
         if (DropdownQuality.value == 2)
       {
           SetMedium();
       }
       if (DropdownQuality.value == 3)
       {
           SetHigh();
       }
         if (DropdownQuality.value == 4)
       {
       
           SetVeryHigh();
       }

      if (DropdownQuality.value == 5)
       {
           SetUltra();
       }



        if (DropdownResolution.value == 0)
        {
            Resolution1024();
        }
        if (DropdownResolution.value == 1)
        {
            SetLow();
        }
        if (DropdownResolution.value == 2)
        {
            Resolution1280();
        }
        if (DropdownResolution.value == 3)
        {
            Resolution1280x();
        }
        if (DropdownResolution.value == 4)
        {

            Resolution1600();
        }

        if (DropdownResolution.value == 5)
        {
            Resolution1920();
        }


        if (FullScreen.isOn == true)
        {
            Screen.fullScreen = true;
        }
        if (FullScreen.isOn == false)
        {
            Screen.fullScreen = false;
        }
    }

    public void SetVeryLow()
    {
     
        QualitySettings.SetQualityLevel(0);
    }
    public void SetLow()
    {
        QualitySettings.SetQualityLevel(1);
    }
    public void SetMedium()
    {
        QualitySettings.SetQualityLevel(2);
    }
    public void SetHigh()
    {
        QualitySettings.SetQualityLevel(3);
    }
    public void SetVeryHigh()
    {
        QualitySettings.SetQualityLevel(4);
    }

    public void SetUltra()
    {
        QualitySettings.SetQualityLevel(5);
    }


    public void Resolution1024()
    {
        Screen.SetResolution(1024, 768, Screen.fullScreen);
    }
    public void Resolution1280()
    {
        Screen.SetResolution(1280, 720, Screen.fullScreen);
    }
    public void Resolution1280x()
    {
        Screen.SetResolution(1280, 1024, Screen.fullScreen);
    }
    public void Resolution1600()
    {
        Screen.SetResolution(1600, 900, Screen.fullScreen);
    }
    public void Resolution1920()
    {
        Screen.SetResolution(1920, 1080, Screen.fullScreen);
    }
}

