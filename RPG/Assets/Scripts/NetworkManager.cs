using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
public class NetworkManager : MonoBehaviourPunCallbacks
{
    public int maxPlayers;

    public static NetworkManager instance;

    void Awake()
    {
        if (instance != null && instance != this)
            gameObject.SetActive(false);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    private void Start()
    {
        // connect to master server
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.JoinLobby();
    }

    public void CreateRoom (string roomName)
    {
        RoomOptions options = new RoomOptions();
        options.MaxPlayers = (byte)maxPlayers;

        PhotonNetwork.CreateRoom(roomName);
    }

    public void JoinRoom (string roomName)
    {
        PhotonNetwork.JoinRoom(roomName);
    }

    public void ChangeScene (string sceneName)
    {
        PhotonNetwork.LoadLevel(sceneName);
    }
}