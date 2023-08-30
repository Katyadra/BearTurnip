using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEditorInternal.VersionControl;


public class PhotonManager : MonoBehaviourPunCallbacks
{
    [SerializeField] string region;
    [SerializeField] InputField RoomName;
    [SerializeField] ListItem itemPrefab;
    [SerializeField] Transform content;
    void Start()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.ConnectToRegion(region);  
    }
    public override void OnConnectedToMaster()
    {
        Debug.Log("Вы подключились к: " + PhotonNetwork.CloudRegion);
    }
    public override void OnDisconnected(DisconnectCause cause)
    {
        Debug.Log("Вы отключены от сервера!");
    }
    public void CreateRoomButton()
    {
        if (!PhotonNetwork.IsConnected)
        {
            return;
        }
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.MaxPlayers = 2;
        PhotonNetwork.CreateRoom(RoomName.text, roomOptions, TypedLobby.Default);
    }
    public override void OnCreatedRoom()
    {
        Debug.Log("Создана комната, имя комнаты: " + PhotonNetwork.CurrentRoom.Name);
    }
    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.LogError("Не удалось создать комнату");
    }
    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        foreach (RoomInfo info in roomList) 
        {
            ListItem listItem = Instantiate(itemPrefab, content);

        }
    }
}
