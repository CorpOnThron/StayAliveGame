using System.Collections;
using System.Collections.Generic;
using Timers;
using UnityEngine;
using UnityEngine.UI;

public class MainController : MonoBehaviour
{

    Timer timer_heartRate;
    Timer timer_bloodPressure;
    Timer timer_temperature;
    public Canvas main_Canvas;

    Slider slider_heartRate;
    Slider slider_bloodPressure;
    Slider slider_temperature;

    public float pulseRate = 0.5f;
    public float beatRate = 0.5f;
    public Image heart;
    public const float C_normalTemperature = 36.5f;
    public const float C_normalTempSlider = 0.715f;
    private float curTemperature;
    Text txt_tempC;
    Text txt_CD;



    void Start()
    {
        InitAll();
    }
    void InitAll() {
        curTemperature = C_normalTemperature;


        txt_tempC = main_Canvas.transform.Find("Txt_Temp_C").GetComponent<Text>();
        txt_CD = main_Canvas.transform.Find("Txt_Temp_CD").GetComponent<Text>();
        slider_temperature = main_Canvas.transform.Find("Slider_temperature").GetComponent<Slider>();

        SetupTimers();
    }

    void SetupTimers()
    {
        //heart rate timer
        timer_heartRate = new Timer(pulseRate, uint.MaxValue, Pulse);
        TimersManager.AddTimers(this,new List<Timer>{timer_heartRate});
    }

    #region heart rate
    void Pulse() {
        iTween.PunchScale(heart.gameObject, iTween.Hash("x", 1.05f, "y", 1.05f, "easeType", iTween.EaseType.easeInBack, "looptype",iTween.LoopType.loop, "time", beatRate));
    }

    public void PulseRateUp() {
        heart.transform.localScale = Vector3.one; 
        beatRate -= 0.1f;
       
    }
    public void PulseRateDown()
    {
        heart.transform.localScale = Vector3.one;
        beatRate += 0.1f;
    }
    #endregion

    #region temperature
    // temperature
    public void TempUp()
    {
        TemperatureBuffer(true,10);
    }
    public void TempDown()
    {
        TemperatureBuffer(false, 5);
    }
   
    void TemperatureBuffer(bool isPositive,uint pSec) {
        pSec *=10;
        float tLen = curTemperature - C_normalTemperature;
        float tStep = tLen / (float)pSec;
        float tSliderValueStep = (slider_temperature.value - C_normalTempSlider)/(float)pSec;
        float tSec = pSec;
        timer_temperature = new Timer(0.1f,pSec,()=> {

            slider_temperature.value = isPositive ? slider_temperature.value + tSliderValueStep : slider_temperature.value - tSliderValueStep;
            curTemperature += tStep;
            tSec -= 0.1f;
            txt_CD.text = tSec + "s";
            txt_tempC.text = curTemperature+ "°C";
        });
        TimersManager.AddTimers(this,new List<Timer> {timer_temperature });
    }
    public float GetTemperature() {
        return curTemperature;
    }
    #endregion


    void Update()
    {

    }
}
