using System.Collections;
using UnityEngine;

public class DeActivator : MonoBehaviour
{
    public int time;

    private void OnEnable()
    {
        StartCoroutine(countDown());
    }

    IEnumerator countDown()
    {
        yield return new WaitForSeconds(time);
        gameObject.SetActive(false);
    }
}
