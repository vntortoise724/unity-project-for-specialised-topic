using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class npcMovement : MonoBehaviour
{
    public bool isHappy;
    public Transform player;
    public Transform throwOrigin;
    public Animator NPCanimator;
    public GameObject cloud;
    public GameObject child;
    public GameObject throwItem;
    public GameObject item;

    public AudioListener soundListener;
    public AudioSource BG;
    public AudioSource Crying;
    public AudioSource Happying;

    public void LookAtPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        if (transform.position.x > player.position.x && transform.rotation.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        } else if (transform.position.x < player.position.x && transform.rotation.y != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    private void HandleThrowItems()
    {
        Instantiate(throwItem, throwOrigin.position, throwOrigin.rotation);
    }

    public void HandleCompletion(GameObject obj)
    {
        if (!isHappy)
        {
            playerMovement movement = obj.GetComponent<playerMovement>();
            if (movement != null)
            {
                if (movement.heartCount > 0)
                {
                    isHappy = true;
                    movement.heartCount--;
                    movement.itemCount++;
                    movement.HandleUse(gameObject);
                    NPCanimator.SetTrigger("Happy");
                    Happying.Play();
                    item.SetActive(true);
                    HandleThrowItems();
                }
                else
                {
                    cloud.SetActive(true);
                    Crying.Play();
                }
            }
        }
    }

    private void Update()
    {
        child.transform.rotation = Quaternion.Euler(0f, 0f, gameObject.transform.rotation.z * -1f);
    }
}
