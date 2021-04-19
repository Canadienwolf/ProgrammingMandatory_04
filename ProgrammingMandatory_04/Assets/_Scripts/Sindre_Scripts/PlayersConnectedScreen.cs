using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class PlayersConnectedScreen : MonoBehaviour
{
    public Text localIpTxt;
    public Button startBtn;
    public Text playerConnectionsTxt;

    NetworkManager manager;
    
    private int connectionAmount = 0;

    private void OnEnable() => PlayerConnectionHandler.onUpdatePlayerAmount += UpdateConnections;

    private void OnDisable() => PlayerConnectionHandler.onUpdatePlayerAmount -= UpdateConnections;

    void Start()
    {
        Invoke("LateStart", .1f);
    }

    void LateStart()
    {
        manager = NetworkManager.singleton;
        if (!manager)
        {
            Destroy(this);
            return;
        }

        if (InGameNetworkHandler.IsServer)
        {
            localIpTxt.text = $"IP\n{localIpAddress}";
        }
        else
        {
            localIpTxt.text = "Waiting for host...";
            startBtn.gameObject.SetActive(false);
        }
    }

    void UpdateConnections(int _amount)
    {
        connectionAmount = _amount;
        playerConnectionsTxt.text = $"{connectionAmount}/100";
    }

    string localIpAddress
    {
        get
        {
            var _host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (var _ip in _host.AddressList)
            {
                if (_ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                    return _ip.ToString();
            }
            return "No IP found";
        }
    }
}
