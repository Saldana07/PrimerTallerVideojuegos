using UnityEngine;
using UnityEngine.Events;

/// Controla el inicio, reinicio y cronómetro de la máquina.
/// Espacio = iniciar | R = reiniciar
public class MachineController : MonoBehaviour
{
    [Header("Eventos")]
    public UnityEvent onStart;   // Conecta aquí lo que da el primer empujón
    public UnityEvent onFinish;

    public bool Running { get; private set; }
    public float Elapsed { get; private set; }

    ResettableObject[] _resettables;

    void Start() => _resettables = FindObjectsByType<ResettableObject>(FindObjectsSortMode.None);

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !Running) StartMachine();
        if (Input.GetKeyDown(KeyCode.R)) ResetMachine();
        if (Running) Elapsed += Time.deltaTime;
    }

    public void StartMachine()
    {
        Running = true;
        Elapsed = 0f;
        onStart?.Invoke();
    }

    public void FinishMachine()
    {
        if (!Running) return;
        Running = false;
        onFinish?.Invoke();
        Debug.Log($"¡Máquina completada en {Elapsed:F2} s!");
    }

    public void ResetMachine()
    {
        Running = false;
        Elapsed = 0f;
        foreach (var r in _resettables) r.ResetObject();
    }

    void OnGUI()
    {
        GUI.Label(new Rect(10, 10, 400, 25), "ESPACIO: iniciar   |   R: reiniciar");
        GUI.Label(new Rect(10, 30, 400, 25), $"Tiempo: {Elapsed:F2} s  {(Running ? "(en curso)" : "")}");
    }
}
