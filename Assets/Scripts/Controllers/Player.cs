using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Singleton<Player>
{
    public bool IsFinished;

    public PlayerMovement PlayerMovement { get; private set; }
    public PlayerController PlayerController { get; private set; }
    public BallController BallController { get; private set; }

    private void Awake()
    {

        PlayerMovement = GetComponent<PlayerMovement>();        
        PlayerController = GetComponent<PlayerController>();
        BallController = GetComponent<BallController>();
    }

    private void OnEnable()
    {
        LevelManager.OnLevelStart += OnLevelStart;
        LevelManager.OnLevelSuccess += OnLevelSuccess;
        LevelManager.OnLevelFail += OnLevelFail;
    }

    private void OnDisable()
    {
        LevelManager.OnLevelStart -= OnLevelStart;
        LevelManager.OnLevelSuccess -= OnLevelSuccess;
        LevelManager.OnLevelFail -= OnLevelFail;
    }

    private void OnLevelStart()
    {
        PlayerController.CanPlay = true;
        PlayerMovement.CanMove = true;     
    }
    private void OnLevelSuccess()
    {
        PlayerController.CanPlay = false;


        PlayerMovement.CanMove = false;
        PlayerMovement.Rigidbody.velocity = Vector3.zero;

    }
    private void OnLevelFail()
    {
        PlayerController.CanPlay = false;
        PlayerMovement.CanMove = false;
        PlayerMovement.Rigidbody.velocity = Vector3.zero;
    }

    public void PassFinishLine()
    {
        IsFinished = true;
    }
}
