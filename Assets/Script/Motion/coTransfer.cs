using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coTransfer : MonoBehaviour
{
    public bool isHappy;
    public Animator animator;

    public void HandleCompletion(GameObject obj)
    {
        if (!isHappy)
        {
            playerMovement movement = obj.GetComponent<playerMovement>();
            if (movement != null)
            {
                if(movement.clothesCount > 0)
                {
                    isHappy = true;
                    movement.clothesCount--;
                    movement.itemCount++;
                    movement.HandleUse(gameObject);
                    animator.SetTrigger("isGiven");
                    gameObject.GetComponent<BoxCollider2D>().enabled = false;
                }
            }
        }
    }
}
