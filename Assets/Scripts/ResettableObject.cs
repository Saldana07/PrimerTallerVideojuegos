using UnityEngine;

/// Guarda la pose inicial de un objeto y permite restaurarla (para reiniciar la máquina).
public class ResettableObject : MonoBehaviour
{
    Vector3 _pos;
    Quaternion _rot;
    Rigidbody _rb;
    bool _wasKinematic;

    void Awake()
    {
        _pos = transform.position;
        _rot = transform.rotation;
        _rb = GetComponent<Rigidbody>();
        if (_rb != null) _wasKinematic = _rb.isKinematic;
    }

    public void ResetObject()
    {
        if (_rb != null)
        {
            // Alternar kinematic borra velocidades sin depender de la versión de Unity
            _rb.isKinematic = true;
            transform.SetPositionAndRotation(_pos, _rot);
            _rb.isKinematic = _wasKinematic;
            _rb.Sleep();
        }
        else
        {
            transform.SetPositionAndRotation(_pos, _rot);
        }
    }
}
