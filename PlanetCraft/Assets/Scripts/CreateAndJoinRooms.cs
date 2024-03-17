using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class CreateAndJoinRooms : MonoBehaviourPunCallbacks
{
    [SerializeField] GameObject createInput;
    [SerializeField] GameObject joinInput;

    public void CreateRoom()
    {
        PhotonNetwork.CreateRoom(createInput.ToString());
    }

    public void JoinRoom()
    {
        PhotonNetwork.JoinRoom(joinInput.ToString());
    }
    public override void OnJoinedRoom()
    {
        PhotonNetwork.LoadLevel("arena");
    }
}
