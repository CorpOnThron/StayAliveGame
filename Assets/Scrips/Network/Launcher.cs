﻿using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Launcher : MonoBehaviourPunCallbacks
{
    public string gameVersion;

    [SerializeField]
    public GameObject controlPanel;

    [SerializeField]
    public GameObject progressLabel;

    private void Start()
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
    }

    private void Awake()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    
    public void Connect()
    {
        progressLabel.SetActive(true);
        controlPanel.SetActive(false);

        Debug.Log("Attempting Connect");

        if (PhotonNetwork.IsConnected)
        {
            PhotonNetwork.JoinRandomRoom();
            Debug.Log("Connected Network");
        }
        else
        {
            PhotonNetwork.ConnectUsingSettings();
            PhotonNetwork.GameVersion = gameVersion;
            Debug.Log("Using Settings Network");
        }
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Connected to master");
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        progressLabel.SetActive(false);
        controlPanel.SetActive(true);
        Debug.Log("Disconnected becasue " + cause);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log(returnCode + ": " + message);

        Debug.Log("Created GameRoom1");
        PhotonNetwork.CreateRoom("GameRoom1", new RoomOptions
        {
            IsOpen = true,
            MaxPlayers = 2
        });
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined a room");
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log(newPlayer.NickName + " joined the room!");
        controlPanel.SetActive(false);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        Debug.Log(otherPlayer.NickName + " Left the room!");
        PhotonNetwork.Disconnect();
        controlPanel.SetActive(true);
    }

    public void SendMessage()
    {
        
    }
}
