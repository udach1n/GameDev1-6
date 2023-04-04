using UnityEngine;
using UnityEngine.UI;


public class GameUiView : MonoBehaviour, IInputSource
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Button jumpButton;

    public float HorizontalMoving => joystick.Horizontal;

    public bool Jump { get; private set; }

    private void Awake()
    {
        jumpButton.onClick.AddListener(() => Jump = true);
    }

    private void OnDestroy()
    {
        jumpButton.onClick.RemoveAllListeners();
    }

    public void ResetActions()
    {
        Jump = false;
    }
}

