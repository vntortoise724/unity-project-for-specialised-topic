using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SignBehavor : MonoBehaviour
{
    public bool isTaken;
    public GameObject sign;
    public Animator animator;

    public void takeN()
    {
        if (!isTaken)
        {
            isTaken = true;
            animator.SetTrigger("NoN");
            Destroy(gameObject);
            sign.SetActive(true);
        }
    }

}
