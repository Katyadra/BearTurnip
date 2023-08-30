using UnityEngine;
using UnityEngine.UI;
using Photon.Realtime;
public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] Text textName;
    [SerializeField] Text textPlayerCount;

    public void SetInfo(RoomInfo info)
    {
        textName.text = info.Name;
        textPlayerCount.text = info.PlayerCount + "/" + info.MaxPlayers; 
    }
}
