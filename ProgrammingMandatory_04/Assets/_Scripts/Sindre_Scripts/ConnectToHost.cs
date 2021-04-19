using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConnectToHost : MonoBehaviour
{
    public Button connectButton;
    public InputField ipAddressInputField;

    private NetworkManager networkManager;

    void Start()
    {
        networkManager = NetworkManager.singleton;

        connectButton.onClick.AddListener(TryConnectToHost);
    }

    void Update() => connectButton.interactable = !string.IsNullOrEmpty(ipAddressInputField.text);

    void TryConnectToHost()
    {
        networkManager.networkAddress = ipAddressInputField.text;

        networkManager.StartClient();
    }
}
