using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Communicator : MonoBehaviourPun
{
    public InputField healthInput;
    public InputField temperatureInput;
    public InputField breathInput;
    

    public void sendHealth()
    {
        try
        {
            int rate = int.Parse(healthInput.text);
            PhotonView photonView = GetComponent<PhotonView>();
            photonView.RPC("GetHealth", RpcTarget.All, rate);
        }
        catch (Exception e)
        {
            Debug.Log("Something went wrong: " + e.Message);
        }
    }

    public void sendTemperature()
    {
        try { 
            int rate = int.Parse(temperatureInput.text);
            PhotonView photonView = GetComponent<PhotonView>();
            photonView.RPC("GetTemperature", RpcTarget.All, rate);
        }
        catch (Exception e)
        {
            Debug.Log("Something went wrong: " + e.Message);
        }
    }

    public void sendBreath()
    {
        try { 
            int rate = int.Parse(breathInput.text);
            PhotonView photonView = GetComponent<PhotonView>();
            photonView.RPC("GetBreath", RpcTarget.All, rate);
        }
        catch(Exception e)
        {
            Debug.Log("Something went wrong: " + e.Message);
        }
    }

    public void sendParameters()
    {
        try
        {
            int healthRate = int.Parse(healthInput.text);
            int temperatureRate = int.Parse(temperatureInput.text);
            int breathRate = int.Parse(breathInput.text);

            PhotonView photonView = GetComponent<PhotonView>();
            photonView.RPC("GetParameters", RpcTarget.All, healthRate, temperatureRate, breathRate);
        }
        catch(Exception e)
        {
            Debug.Log("Something went wrong: " + e.Message);
        }
    }

    [PunRPC]
    void GetHealth(int rate)
    {
        Debug.Log("Health: " + rate);
    }

    [PunRPC]
    void GetTemperature(int rate)
    {
        Debug.Log("Temperature: " + rate);
    }

    [PunRPC]
    void GetBreath(int rate)
    {
        Debug.Log("Breath: " + rate);
    }

    [PunRPC]
    void GetParameters(int healthRate, int temperatureRate, int breathRate)
    {
        Debug.Log($"Health: {healthRate} || Temperature: {temperatureRate} || Breath: {breathRate}");
    }
}
