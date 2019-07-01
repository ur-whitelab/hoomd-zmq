﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SimInterface : MonoBehaviour
{

    public Text TemperatureText;
    public Text DensityText;
    public Text PressureText;

    private float setTemperature = 0.15f;
    private float setPressure = 0.0f;
    private float scale = 1.0f;

    private vrCommClient cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GameObject.Find("CommClient").GetComponent<vrCommClient>();
        cc.OnSimulationUpdate += updateInterface;
    }

    //[temp, dens, press]
    private void updateInterface(Dictionary<string, string> data)
    {
        if (data.ContainsKey("temperature"))
        {
            TemperatureText.text = "Temperature: " + Math.Round(float.Parse(data["temperature"]), 3) + "(" + Math.Round(setTemperature, 2) + ")";
        }
        else
        {
            TemperatureText.text = "Temperature: " + "(" + Math.Round(setTemperature, 2) + ")";
        }

        if (data.ContainsKey("density"))
        {
            DensityText.text = "Density: " + Math.Round(float.Parse(data["density"]), 3);
        }

        if (data.ContainsKey("pressure"))
        {
            PressureText.text = "Pressure: " + Math.Round(float.Parse(data["pressure"]), 3) + "(" + Math.Round(setPressure, 2) + ")";
        } else
        {
            PressureText.text = "Pressure: " + Math.Round(setPressure, 2);
        }

        // now set data
        var newdata = new Dictionary<string, string>();
        newdata["temperature"] = "" + setTemperature;
        newdata["pressure"] = "" + setPressure;
        newdata["box"] = "" + scale;
        scale = 1f;
        cc.SetMessage(newdata);
    }

    void Update()
    { 
        if (Input.GetKeyDown(KeyCode.T))
        {
            setTemperature += 0.01f;
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            setTemperature -= 0.01f;
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            setPressure += 0.001f;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            setPressure -= 0.001f;
        }

        if (Input.GetKeyDown(KeyCode.S))
        {
            scale = 1.05f;
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            scale = 0.92f;
        }
    }


}
