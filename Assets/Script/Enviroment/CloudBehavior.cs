using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudBehavior : MonoBehaviour
{

    public float delaySeconds = 2f;

    private WaitForSeconds cullDelay = null;

    private void Update()
    {
        cullDelay = new WaitForSeconds(delaySeconds);
        StartCoroutine(DelayCull());
    }

    private IEnumerator DelayCull()
    {
        yield return cullDelay;
        gameObject.SetActive(false);
    }
}
