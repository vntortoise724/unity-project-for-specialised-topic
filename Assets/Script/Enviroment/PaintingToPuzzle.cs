using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingToPuzzle : MonoBehaviour
{

    public GameObject puzzleUI;

    public void jumptoPuzzle()
    {
        puzzleUI.SetActive(true);
        Time.timeScale = 0f;
    }

}
