using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinManager : MonoBehaviourPunCallbacks
{
    public InputField CreateRoomField;
    public InputField JoinRoomField;
    public Text TextFieldForFails;

    void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(100, 999);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom() 
    {
        PhotonNetwork.CreateRoom("k",new Photon.Realtime.RoomOptions { MaxPlayers=2});
    }

    public void LoadRoom() 
    {
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("Game");
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
	{
        TextFieldForFails.text = message;
	}

	void Update()
    {
        
    }
}
