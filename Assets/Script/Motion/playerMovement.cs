using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    [Header("Adjust Speed")]
    public float speed = 2f;

    [Header("SceneMap")]
    public GameObject URDone;
    public GameObject E_btn;
    public Transform child;

    [Header("UI")]
    public GameObject puzzle;

    [SerializeField] private UI_Inventory uiInvetory;
    public int keyCount;
    public int tapeCount;
    public int heartCount;
    public int clothesCount;
    public int itemCount;

    private string xMoveAxis = "Horizontal";
    private float moveIntentionX = 0;
    private Vector3 target;
    private bool moving;
    private bool isMoving;
    private Rigidbody2D rb2D = null;
    private Animator animator = null;

    private enum MovementStatus { idle, walk }

    public Rigidbody2D getrb2D
    {
        get { return rb2D; }
        protected set { rb2D = value; }
    }

    private void GetInput()
    {
        moveIntentionX = Input.GetAxis(xMoveAxis);
        moving = Input.GetMouseButtonDown(0);
    }

    private void HandleWalkMouse()
    {
        if (isMoving && transform.position.x > target.x)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else if (isMoving && transform.position.x < target.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        if (isMoving && (Vector3)transform.position != target)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector3.MoveTowards(transform.position, target, step);
            target.z = -0.55f;
            target.y = transform.position.y;
        } 
        else
        {
            isMoving = false;
        }
    }

    private void HandleWalkWithKeyBoard()
    {
        if (moveIntentionX < 0 && transform.rotation.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 180f, 0);
        }
        else if (moveIntentionX > 0 && transform.rotation.y != 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }

        getrb2D.velocity = new Vector2(moveIntentionX * speed, getrb2D.velocity.y);
    }

    public void ApplyDamage()
    {
        animator.SetTrigger("IamHit");
    }

    private void HandleAnimation()
    {
        MovementStatus Status;

        if ((Mathf.Abs(moveIntentionX) > 0.1f) || isMoving)
        {
            Status = MovementStatus.walk;
        }

        else
        {
            Status = MovementStatus.idle;
        }

        animator.SetInteger("Status", (int)Status);
    }

    public int getItem
    {
        get { return itemCount; }
        protected set { itemCount = value; }
    }

    public void HandleFetch(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Key":
                keyCount++;
                break;
            case "Tape":
                tapeCount++;
                break;
            case "Heart":
                heartCount++;
                break;
            case "Clothes":
                clothesCount++;
                break;
            default: break;
        }
    }

    public void HandleUse(GameObject obj)
    {
        switch (obj.tag)
        {
            case "Door":
                keyCount--;
                break;
            case "Heart":
                tapeCount--;
                break;
            case "NPC":
                itemCount--;
                break;
            default: break;
        }
    }

    public void NotifyE()
    {
        E_btn.SetActive(true);
    }

    public void DenotifyE()
    {
        E_btn.SetActive(false);
    }

    // Start is called before the first frame update
    void Awake()
    {
        if (GetComponent<Rigidbody2D>())
        {
            rb2D = GetComponent<Rigidbody2D>();
        }

        if (GetComponent<Animator>())
        {
            animator = GetComponent<Animator>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        HandleAnimation();
        child.transform.rotation = Quaternion.Euler(0f, 0f, gameObject.transform.rotation.z * -1f);

        if (!puzzle.activeSelf && moving)
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            isMoving = true;
        }

        HandleWalkMouse();
    }

    private void FixedUpdate()
    {
        if (!puzzle.activeSelf && moveIntentionX > 0 || moveIntentionX < 0)
        {
            HandleWalkWithKeyBoard();
        }
    }
}
