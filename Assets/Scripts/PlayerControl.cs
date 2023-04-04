using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    private readonly PlayerMovement player;
    private readonly List<IInputSource> inputSources;

    public PlayerControl(PlayerMovement player, List<IInputSource> inputSources)
    {
        this.player = player;
        this.inputSources = inputSources;
    }

    public void OnFixedUpdate()
    {
        player.Moving(GetHorizontalDirection(), IsJump());

        foreach (var inputSource in inputSources)
            inputSource.ResetActions();
    }

    private float GetHorizontalDirection()
    {
        foreach (var inputSource in inputSources)
        {
            if (inputSource.HorizontalMoving == 0)
                continue;

            return inputSource.HorizontalMoving;
        }
        return 0;
    }

    private bool IsJump() => inputSources.Any(source => source.Jump);
}

