using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;
using Photon.Realtime;

public class Launcher : MonoBehaviourPunCallbacks
{
    public static Launcher instance;

    // Поля для ввода имен комнаты, хоста и гостей
    [SerializeField] private TMP_InputField _roomInputField;
    [SerializeField] private TMP_InputField _hostNameInputField;
    [SerializeField] private TMP_InputField _guestNameInputField;

    // UI для отображения ошибок и текущего названия комнаты
    [SerializeField] private TMP_Text _errorText;
    [SerializeField] private TMP_Text _roomNameText;

    // Контейнер для UI списка комнат и списка игроков
    [SerializeField] private Transform _roomList;
    [SerializeField] private Transform _playerList;

    // Префабы для комнат и списка игроков
    [SerializeField] private GameObject _roomButtonPrefab;
    [SerializeField] private GameObject _playerNamePrefab;

    // UI для кнопки запуска игры
    [SerializeField] private GameObject _startGameButton;


    private void Start()
    {
        instance = this;
        Debug.Log("Присоединяемся к Мастер серверу...");
        PhotonNetwork.ConnectUsingSettings();
        MenuManager.instance.OpenMenu("loading");
    }

    public override void OnConnectedToMaster()
    {
        Debug.Log("Присоединились к Мастер серверу!");
        PhotonNetwork.JoinLobby();
        PhotonNetwork.AutomaticallySyncScene = true;
    }

    public override void OnJoinedLobby()
    {
        Debug.Log("Присоединились к Лобби!");
        MenuManager.instance.OpenMenu("title");
    }

    public void CreateRoom()
    {
        if (string.IsNullOrEmpty(_roomInputField.text))
        {
            return;
        }

        if (string.IsNullOrEmpty(_hostNameInputField.text))
        {
            PhotonNetwork.NickName = "Player " + Random.Range(0, 10000).ToString("D4");
        }
        else
        {
            PhotonNetwork.NickName = _hostNameInputField.text;
        }

        PhotonNetwork.CreateRoom(_roomInputField.text);
        MenuManager.instance.OpenMenu("loading");
    }

    public override void OnJoinedRoom()
    {
        _roomNameText.text = "Room Name: " + PhotonNetwork.CurrentRoom.Name;

        MenuManager.instance.OpenMenu("room");

        Player[] players = PhotonNetwork.PlayerList;

        for (int i = 0; i < _playerList.childCount; i++)
        {
            Destroy(_playerList.GetChild(i).gameObject);
        }

        for (int i = 0; i < players.Length; i++)
        {
            Instantiate(_playerNamePrefab, _playerList).GetComponent<PlayerListItem>().SetUp(players[i]);
        }
        _startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnMasterClientSwitched(Player newMasterClient)
    {
        _startGameButton.SetActive(PhotonNetwork.IsMasterClient);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        _errorText.text = "Error: " + message;
        MenuManager.instance.OpenMenu("error");
    }

    public void LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        MenuManager.instance.OpenMenu("loading");
    }

    public override void OnLeftRoom()
    {
        MenuManager.instance.OpenMenu("createroom");
    }

    public void JoinRoom(RoomInfo info)
    {

        if (string.IsNullOrEmpty(_guestNameInputField.text))
        {
            PhotonNetwork.NickName = "Player " + Random.Range(0, 10000).ToString("D4");
        }
        else
        {
            PhotonNetwork.NickName = _guestNameInputField.text;
        }

        PhotonNetwork.JoinRoom(info.Name);
        MenuManager.instance.OpenMenu("loading");
    }

    public override void OnRoomListUpdate(List<RoomInfo> roomList)
    {
        for (int i = 0; i < _roomList.childCount; i++)
        {
            Destroy(_roomList.GetChild(i).gameObject);
        }
        for (int i = 0; i < roomList.Count; i++)
        {
            if (roomList[i].RemovedFromList)
                continue;
            Instantiate(_roomButtonPrefab, _roomList).GetComponent<RoomListItem>().SetUp(roomList[i]);
        }
    }

    public override void OnPlayerEnteredRoom(Player player)
    {
        Instantiate(_playerNamePrefab, _playerList).GetComponent<PlayerListItem>().SetUp(player);
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(1);
    }
}
