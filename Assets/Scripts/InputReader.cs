using UnityEngine;

public class InputReader : IInputSource
{
    public float HorizontalMoving => Input.GetAxisRaw("Horizontal");

    public bool Jump { get; private set; }

    public void OnUpdate()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Jump = true;
        }
    }

    public void ResetActions()
    {
        Jump = false;
    }
}