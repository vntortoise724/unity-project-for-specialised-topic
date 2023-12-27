using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X_Behavior : MonoBehaviour
{
    public GameObject UI;

    public void CloseUI()
    {
        UI.SetActive(false);
        Time.timeScale = 1.0f;
    }
}
