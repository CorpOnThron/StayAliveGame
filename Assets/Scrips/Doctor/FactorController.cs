﻿using System.Collections;
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
            if (value >= 100) f_heartRate = 100;
            else if (value <= 0) f_heartRate = 0;
            else f_heartRate = value;
        }
    }
    public int F_bloodPressure
    {
        get { return f_bloodPressure; }
        set
        {
            if (value >= 100) f_bloodPressure = 100;
            else if (value <= 0) f_bloodPressure = 0;
            else f_bloodPressure = value;
        }
    }
    public int F_breath
    {
        get { return f_breath; }
        set
        {
            if (value>= 100) f_breath = 100;
            else if (value  <= 0) f_breath = 0;
            else f_breath = value;
        }
    }

    public Canvas canvasObj;

    AniController ctrl_heartRate;
    AniController ctrl_bloodPressure;
    AniController ctrl_breath;
    AniController ctrl_patient;

    void Awake() {
    }

    void Start()
    {
        InitAll();
    }

    void InitAll() {
        f_heartRate=50;
        f_bloodPressure=50;
        f_breath =50;

        ctrl_heartRate =  canvasObj.transform.Find("Ani_HeartRate").GetComponent<AniController>();
        ctrl_bloodPressure = canvasObj.transform.Find("Ani_BloodMonitor").GetComponent<AniController>();
        ctrl_breath = canvasObj.transform.Find("Ani_Breath").GetComponent<AniController>();
        ctrl_patient = canvasObj.transform.Find("Ani_Patient").GetComponent<AniController>();

        ctrl_heartRate.SetFactors(F_heartRate);
        ctrl_bloodPressure.SetFactors(F_bloodPressure);
        ctrl_breath.SetFactors(F_breath);
    }

    public void GetMedicine(Vector3Int pEffects) {
        F_heartRate += pEffects.x;
        F_bloodPressure += pEffects.y;
        F_breath += pEffects.z;

        ctrl_heartRate.SetFactors(F_heartRate);
        ctrl_bloodPressure.SetFactors(F_bloodPressure);
        ctrl_breath.SetFactors(F_breath);
        ctrl_patient.SetFactors(F_breath);

        if (F_breath == 0 || F_bloodPressure == 0 || F_heartRate == 0) {
            Debug.Log("this patient dead");
        }
    }


    void Update()
    {

    }
}
