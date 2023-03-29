using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLevelInitializer : MonoBehaviour
{
    [SerializeField] private PlayerMovement playerMovement;
    [SerializeField] private UIGamePlay uiGamePlay;

    private PlayerBrain brain;

    private void Awake()
    {
        brain = new PlayerBrain(playerMovement, inputSources: new List<IEntityInputSource>
        {
            uiGamePlay

        });
    }
    private void FixedUpdate()
    {
        brain.OnFixedUpdate();
    }
}
