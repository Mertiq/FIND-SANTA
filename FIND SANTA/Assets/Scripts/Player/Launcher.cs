using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("baðlandý");
        PhotonNetwork.JoinLobby();
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinOrCreateRoom("1", new RoomOptions { MaxPlayers = 3, IsOpen = true, IsVisible = true }, TypedLobby.Default);


    }

    public override void OnJoinedRoom()
    {
        Debug.Log("odaya girildi");
        PhotonNetwork.Instantiate("Cube", Vector3.zero, Quaternion.identity, 0, null);
        //PhotonNetwork.Instantiate("CharacterCamera", Vector3.zero, Quaternion.identity, 0, null);
        
    }



}
