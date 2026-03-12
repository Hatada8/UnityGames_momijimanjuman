using UnityEngine;

public class OnKeyPress_ChangeAnimation_Parametes : MonoBehaviour
{
    Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // 押された瞬間だけ反応させる
        if (Input.GetKeyDown("up"))
            animator.SetTrigger("MoveUp");

        else if (Input.GetKeyDown("down"))
            animator.SetTrigger("MoveDown");

        else if (Input.GetKeyDown("left"))
            animator.SetTrigger("MoveLeft");

        else if (Input.GetKeyDown("right"))
            animator.SetTrigger("MoveRight");
    }
}
