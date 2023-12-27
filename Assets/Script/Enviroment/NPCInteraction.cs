using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class NPCInteraction : MonoBehaviour
{
    public bool isNear;
    public KeyCode interactKey;
    public UnityEvent interactAction;
    public npcMovement npc;

    // Update is called once per frame
    void Update()
    {
        if (isNear)
        {
            if (npc != null)
            {
                npc.LookAtPlayer();
            }

            if (Input.GetKeyDown(interactKey))
            {
                interactAction.Invoke();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNear = true;
            collision.gameObject.GetComponent<playerMovement>().NotifyE();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNear = false;
            collision.gameObject.GetComponent<playerMovement>().DenotifyE();
            
        }
    }
}
