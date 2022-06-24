using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public FSM PlayerFSM;
    public Inventory inventory;

    private static Player playerInstance;

    public static Player GetInstance()
    {
        return playerInstance;
    }

    private void Start()
    {
        playerInstance = this;
        inventory = new Inventory();
        PlayerFSM = new FSM(gameObject, new StandingState(gameObject));
    }

    private void Update()
    {
        PlayerFSM.Update();
    }
}
