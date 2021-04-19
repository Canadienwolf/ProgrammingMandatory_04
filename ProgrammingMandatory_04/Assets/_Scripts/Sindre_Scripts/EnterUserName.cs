using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class EnterUserName : MonoBehaviour
{
    public GameObject chooseRole;
    public InputField usernameField;
    public Button confirmButton;
    public string loginUri = "https://hera.nord.no/~329266/SPO3021/M04_Database/login.php";

    public static string userName = "No Name";
    public static int userId = -1;
    public static int userScore = 0;

    void Start()
    {
        if (PlayerPrefs.HasKey("UserId"))
            userId = PlayerPrefs.GetInt("UserId");
        else
            userId = -1;

        if (PlayerPrefs.HasKey("UserName"))
        {
            userName = PlayerPrefs.GetString("UserName");
            usernameField.text = userName;
        }

        confirmButton.onClick.AddListener(RunLogin);
    }

    void Update() => confirmButton.interactable = !string.IsNullOrEmpty(usernameField.text);

    void ConfirmUsername()
    {
        chooseRole.SetActive(true);
        gameObject.SetActive(false);
    }

    void RunLogin() => StartCoroutine(RequestLogin());

    IEnumerator RequestLogin()
    {
        userName = usernameField.text;
        PlayerPrefs.SetString("UserName", userName);

        WWWForm _form = new WWWForm();
        _form.AddField("userId", userId.ToString());
        _form.AddField("userName", userName);
        _form.AddField("guid", System.Guid.NewGuid().ToString());

        using (UnityWebRequest _webRequest = UnityWebRequest.Post(loginUri, _form))
        {
            yield return _webRequest.SendWebRequest();

            if (_webRequest.result == UnityWebRequest.Result.Success)
            {
                string[] _returnValue = _webRequest.downloadHandler.text.Split('_');

                userId = int.Parse(_returnValue[0]);
                userScore = int.Parse(_returnValue[1]);
                PlayerPrefs.SetInt("UserId", userId);
                ConfirmUsername();
            }
            else
            {
                Debug.LogError(_webRequest.error);
            }
        }
    }
}
