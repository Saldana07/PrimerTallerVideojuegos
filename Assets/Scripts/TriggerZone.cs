using UnityEngine;
using UnityEngine.Events;

/// Zona (Collider con Is Trigger) que dispara un evento cuando entra un Rigidbody.
/// Úsala para activar el siguiente paso de la cadena.
[RequireComponent(typeof(Collider))]
public class TriggerZone : MonoBehaviour
{
    public UnityEvent onEnter;
    public bool onlyOnce = true;
    bool _fired;

    void Reset() => GetComponent<Collider>().isTrigger = true;

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody == null) return;
        if (onlyOnce && _fired) return;
        _fired = true;
        onEnter?.Invoke();
    }

    public void ResetTrigger() => _fired = false;
}
