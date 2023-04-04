using System.Collections.Generic;
using UnityEngine;

public class GameLevel : MonoBehaviour
{
    [SerializeField] private PlayerMovement player;
    [SerializeField] private GameUiView gameUiView;

    private InputReader inputReader;
    private PlayerControl playerControl;

    private void Awake()
    {
        inputReader = new InputReader();
        playerControl = new PlayerControl(player, new List<IInputSource>
        {
            gameUiView,
            inputReader
        });
    }

    private void Update()
    {
        inputReader.OnUpdate();
    }

    private void FixedUpdate()
    {
        playerControl.OnFixedUpdate();
    }
}
