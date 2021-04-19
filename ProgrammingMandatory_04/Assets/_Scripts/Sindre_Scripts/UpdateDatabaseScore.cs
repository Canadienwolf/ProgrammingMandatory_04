using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class UpdateDatabaseScore : MonoBehaviour
{
    public string loginUri = "https://hera.nord.no/~329266/SPO3021/M04_Database/updatescore.php";

    public void RunRequest() => StartCoroutine(RequestUpdateScore());

    IEnumerator RequestUpdateScore()
    {
        WWWForm _form = new WWWForm();
        _form.AddField("userId", EnterUserName.userId.ToString());
        _form.AddField("userScore", EnterUserName.userScore.ToString());

        using (UnityWebRequest _webRequest = UnityWebRequest.Post(loginUri, _form))
        {
            yield return _webRequest.SendWebRequest();

            if (_webRequest.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Upload success!");
            }
            else
            {
                Debug.LogError(_webRequest.error);
            }
        }
    }
}
