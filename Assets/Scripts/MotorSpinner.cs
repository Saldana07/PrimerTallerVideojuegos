using UnityEngine;

/// Gira un objeto kinematic (ventilador, rueda, aspa) cuando se activa.
public class MotorSpinner : MonoBehaviour
{
    public Vector3 axis = Vector3.up;
    public float degreesPerSecond = 180f;
    public bool spinning;

    public void SetSpinning(bool value) => spinning = value;
    public void Toggle() => spinning = !spinning;

    void Update()
    {
        if (spinning) transform.Rotate(axis, degreesPerSecond * Time.deltaTime, Space.Self);
    }
}
