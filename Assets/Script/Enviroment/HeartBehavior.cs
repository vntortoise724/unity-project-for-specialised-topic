using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBehavior : MonoBehaviour
{
    public GameObject heart;

    public void DestroyNLive(GameObject obj)
    {
        playerMovement movement = obj.GetComponent<playerMovement>();
        if (movement)
        {
            if (movement.tapeCount > 0)
            {
                movement.HandleUse(gameObject);
                Destroy(gameObject);
                heart.SetActive(true);
            }
        }
        
    }
}
