using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FactorController : MonoBehaviour
{

    private int f_heartRate;
    private int f_bloodPressure;
    private int f_breath;

    public int F_heartRate
    {
        get { return f_heartRate; }
        set
        {
            if (value + f_heartRate >= 100) f_heartRate = 100;
            else if (value + f_heartRate < 0) f_heartRate = 0;
        }
    }
    public int F_bloodPressure
    {
        get { return f_bloodPressure; }
        set
        {
            if (value + f_bloodPressure >= 100) f_bloodPressure = 100;
            else if (value + f_bloodPressure < 0) f_bloodPressure = 0;
        }
    }
    public int F_breath
    {
        get { return f_breath; }
        set
        {
            if (value + f_breath >= 100) f_breath = 100;
            else if (value + f_breath < 0) f_breath = 0;
        }
    }

    public Canvas canvasObj;

    AniController ctrl_heartRate;
    AniController ctrl_bloodPressure;
    AniController ctrl_breath;
    AniController ctrl_patient;


    void Start()
    {
        InitAll();

    }

    void InitAll() {
        ctrl_heartRate =  canvasObj.transform.Find("Ani_HeartRate").GetComponent<AniController>();
        ctrl_bloodPressure = canvasObj.transform.Find("Ani_BloodMonitor").GetComponent<AniController>();
        ctrl_breath = canvasObj.transform.Find("Ani_Breath").GetComponent<AniController>();
        ctrl_patient = canvasObj.transform.Find("Ani_Patient").GetComponent<AniController>();

    }

    void Update()
    {

    }
}
