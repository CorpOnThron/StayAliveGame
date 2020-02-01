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

    void Start()
    {
        slider_heartRate = main_Canvas.transform.Find("Slider_heartRate").GetComponent<Slider>();
        slider_bloodPressure = main_Canvas.transform.Find("Slider_bloodPressure").GetComponent<Slider>();
        slider_temperature = main_Canvas.transform.Find("Slider_temperature").GetComponent<Slider>();
        SetupTimers();
    }

    void SetupTimers()
    {
        timer_heartRate = new Timer(pulseRate, uint.MaxValue, () =>
        {
            iTween.PunchScale(slider_heartRate.handleRect.gameObject,iTween.Hash("x",2.6f,"y",2.6f,"easeType",iTween.EaseType.easeInOutBack,"time",0.5f));
           
        });
        TimersManager.AddTimers(this,new List<Timer>{timer_heartRate});
    }

    void UpdateTimer() {
        timer_heartRate.UpdateTimer();
    }

    void Update()
    {

    }
}
