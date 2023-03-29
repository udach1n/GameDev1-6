using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerBrain : MonoBehaviour
{
    private readonly PlayerMovement _playermovement;
    private readonly List<IEntityInputSource> _inputSources;
    public PlayerBrain(PlayerMovement playermovement, List<IEntityInputSource> inputSources)
    {
        _playermovement = playermovement;
        _inputSources = inputSources;
    }
    public void OnFixedUpdate(){
        _playermovement.UpdateAnimation(GetHorizontalDirection());
        if (IsJump)
        {
            _playermovement.Jump();
        }
        
    }

    private float GetHorizontalDirection()
    {
        foreach (var inputSource in _inputSources)
        {
            if (inputSource.HorizontalDirection == 0)
            {
                continue;
            }
            return inputSource.HorizontalDirection; 
        }
        return 0;
    }
    private bool IsJump => _inputSources.Any(source => source.Jump);
}
