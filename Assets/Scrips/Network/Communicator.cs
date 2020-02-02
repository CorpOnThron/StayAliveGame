using Photon.Pun;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Communicator : MonoBehaviourPun
{
    public int healthInput;
    public int temperatureInput;
    public int breathInput;
    

    public void sendHealth()
    {
        try
        {
            //int rate = healthInput;
            PhotonView photonView = GetComponent<PhotonView>();
            photonView.RPC("GetHealth", RpcTarget.All, healthInput);
        }
        catch (Exception e)
        {
            Debug.Log("Something went wrong: " + e.Message);
        }
    }

    public void sendTemperature()
    {
        try { 
            //int rate = temperatureInput;
            PhotonView photonView = GetComponent<PhotonView>();
            photonView.RPC("GetTemperature", RpcTarget.All, temperatureInput);
        }
        catch (Exception e)
        {
            Debug.Log("Something went wrong: " + e.Message);
        }
    }

    public void sendBreath()
    {
        try { 
           // int rate = breathInput;
            PhotonView photonView = GetComponent<PhotonView>();
            photonView.RPC("GetBreath", RpcTarget.All, breathInput);
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
            int healthRate = healthInput;
            int temperatureRate = temperatureInput;
            int breathRate = breathInput;

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
