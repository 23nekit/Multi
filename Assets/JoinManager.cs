using Photon.Pun;
using Photon.Pun.Demo.Cockpit;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JoinManager : MonoBehaviourPunCallbacks
{
    public InputField RoomField;
    public Text TextFieldForFails;
    public GameObject KeyboardWithRoomField;

    private int ChoosedConfiguration;

    void Start()
    {
        PhotonNetwork.NickName = "Player" + Random.Range(100, 999);
        PhotonNetwork.AutomaticallySyncScene = true;
        PhotonNetwork.GameVersion = "1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public void CreateRoom() 
    {
        KeyboardWithRoomField.SetActive(true);
        ChoosedConfiguration = 1;
    }

    public void LoadRoom() 
    {
        KeyboardWithRoomField.SetActive(true);
        ChoosedConfiguration = 2;
    }

	public void Enter()
	{
		if (ChoosedConfiguration == 1)
        {
            PhotonNetwork.CreateRoom(RoomField.text, new Photon.Realtime.RoomOptions { MaxPlayers = 2 });
        }
        else if (ChoosedConfiguration == 2) 
        {
            PhotonNetwork.JoinRoom(RoomField.text);
        }
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
