using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;

    private bool isMoving;
    private Vector2 input;
    private Vector2 lastMoveDir = Vector2.down; // default facing down
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");
        input.y = Input.GetAxisRaw("Vertical");

        // no diagonal movement
        if (input.x != 0)
            input.y = 0;

        // store last direction when moving
        if (input != Vector2.zero)
        {
            lastMoveDir = input;
        }

        animator.SetFloat("MoveX", lastMoveDir.x);
        animator.SetFloat("MoveY", lastMoveDir.y);
        animator.SetBool("IsMoving", input != Vector2.zero);

        if (!isMoving && input != Vector2.zero)
        {
            Vector3 targetPos = transform.position + new Vector3(input.x, input.y, 0);
            StartCoroutine(Move(targetPos));
        }
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;

        while (Vector3.Distance(transform.position, targetPos) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(
                transform.position,
                targetPos,
                moveSpeed * Time.deltaTime
            );
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
    }
}
