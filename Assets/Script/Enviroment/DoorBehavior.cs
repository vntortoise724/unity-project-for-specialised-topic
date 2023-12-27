using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorBehavior : MonoBehaviour
{
    public bool isOpen;
    public GameObject openDoor;
    public GameObject closeDoor;

    public void OpenDoor(GameObject obj)
    {
        if (!isOpen)
        {
            playerMovement movement = obj.GetComponent<playerMovement>();
            if (movement)
            {
                if (movement.keyCount > 0)
                {
                    isOpen = true;
                    movement.HandleUse(gameObject);
                    openDoor.SetActive(true);
                    Destroy(gameObject);
                }
            }
        }
    }

    public void Finish(GameObject obj)
    {
        if(isOpen)
        {
            obj.SetActive(true);
            Time.timeScale = 0f;
        }
    }
}
