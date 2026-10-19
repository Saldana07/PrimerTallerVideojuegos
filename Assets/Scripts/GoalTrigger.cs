using UnityEngine;

/// Meta final: al entrar la pelota, la máquina termina.
[RequireComponent(typeof(Collider))]
public class GoalTrigger : MonoBehaviour
{
    public MachineController machine;

    void Reset() => GetComponent<Collider>().isTrigger = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody != null && machine != null) machine.FinishMachine();
    }
}
