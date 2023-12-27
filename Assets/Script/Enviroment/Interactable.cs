using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Interactable : MonoBehaviour
{
    public bool isNear;
    public bool isMouseNear;
    public KeyCode interactKey = KeyCode.E;
    public UnityEvent interactAction;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnMouseOver()
    {
        isMouseNear = true;
        animator.SetBool("isNear", isMouseNear);
    }

    private void OnMouseExit()
    {
        isMouseNear = false;
        animator.SetBool("isNear", isMouseNear);
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear)
        {
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
            animator.SetBool("isNear", isNear);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            isNear = false;
            collision.gameObject.GetComponent<playerMovement>().DenotifyE();
            animator.SetBool("isNear", isNear);
        }
    }
}
