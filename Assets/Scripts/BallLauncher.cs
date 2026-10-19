using UnityEngine;

/// Da un impulso a un Rigidbody (primer paso de la máquina, o resorte/empujón).
public class BallLauncher : MonoBehaviour
{
    public Rigidbody target;
    public Vector3 direction = Vector3.right;
    public float force = 5f;

    public void Launch()
    {
        if (target == null) return;
        target.AddForce(direction.normalized * force, ForceMode.Impulse);
    }
}
