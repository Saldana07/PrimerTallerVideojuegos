using UnityEngine;

/// Mueve un objeto de A a B (pistón, puerta, elevador) cuando se activa.
public class MovingPlatform : MonoBehaviour
{
    public Vector3 offset = new Vector3(0, 2, 0);
    public float speed = 1f;
    bool _active;
    Vector3 _start, _end;

    void Awake() { _start = transform.position; _end = _start + offset; }

    public void Activate() => _active = true;
    public void Deactivate() { _active = false; transform.position = _start; }

    void Update()
    {
        if (_active)
            transform.position = Vector3.MoveTowards(transform.position, _end, speed * Time.deltaTime);
    }
}
