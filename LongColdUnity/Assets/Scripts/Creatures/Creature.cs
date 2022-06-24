using UnityEngine;

public class Creature : MonoBehaviour
{
    [SerializeField] private float MaxXP;
    [SerializeField] private float HP;
    private FSM fsm;

    private void Update()
    {
        fsm.Update();
    }
}
