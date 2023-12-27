using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UI_Button : MonoBehaviour
{
    public bool isNear;
    public int btn = 0;
    public UnityEvent interaction;
    public Animator animator;

    // Start is called before the first frame update
    private void OnMouseOver()
    {
        isNear = true;
        animator.SetBool("isNear", isNear);
    }

    private void OnMouseExit()
    {
        isNear = false;
        animator.SetBool("isNear", isNear);
    }

    // Update is called once per frame
    void Update()
    {
        if (isNear)
        {
            if (Input.GetMouseButtonDown(btn))
            {
                interaction.Invoke();
                isNear = false;
            }
        }
    }
}
