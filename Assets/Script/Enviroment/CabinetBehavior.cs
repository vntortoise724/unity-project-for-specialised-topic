using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CabinetBehavior : MonoBehaviour
{
    public bool isOpen;
    public Animator animator;
    public GameObject stuff;

    public void OpenChest()
    {
        if (!isOpen)
        {
            isOpen = true;
            animator.SetBool("isOpen", isOpen);
            stuff.SetActive(true);
        }
    }
}
