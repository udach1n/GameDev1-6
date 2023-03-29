using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIGamePlay : MonoBehaviour, IEntityInputSource
{
    [SerializeField] private Joystick joystick;
    [SerializeField] private Button jumpButton;

    public float HorizontalDirection => joystick.Horizontal;

    public bool Jump { get; private set; }

    private void Awake()
    {
        jumpButton.onClick.AddListener(call:()=> Jump = true);
    }
    private void OnDestroy()
    {
        jumpButton.onClick.RemoveAllListeners();

    }
}
