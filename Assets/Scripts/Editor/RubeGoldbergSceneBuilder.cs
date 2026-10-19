#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.Events;
using UnityEventTools = UnityEditor.Events.UnityEventTools;

/// Menú: Rube Goldberg > Crear escena base
/// Genera una escena de ejemplo: pelota -> rampa -> dominós -> palanca -> meta.
public static class RubeGoldbergSceneBuilder
{
    [MenuItem("Rube Goldberg/Crear escena base")]
    static void Build()
    {
        var scene = EditorSceneManager.NewScene(NewSceneSetup.DefaultGameObjects, NewSceneMode.Single);

        // Controlador
        var ctrlGO = new GameObject("MachineController");
        var ctrl = ctrlGO.AddComponent<MachineController>();

        // Suelo
        var floor = Prim(PrimitiveType.Cube, "Suelo", new Vector3(0, -0.5f, 0), new Vector3(40, 1, 12), new Color(0.35f, 0.35f, 0.4f));

        // Pelota
        var ball = Prim(PrimitiveType.Sphere, "Pelota", new Vector3(-12, 5.2f, 0), Vector3.one * 0.8f, Color.red);
        var ballRb = ball.AddComponent<Rigidbody>();
        ballRb.mass = 1f;
        ball.AddComponent<ResettableObject>();

        // Rampa
        var ramp = Prim(PrimitiveType.Cube, "Rampa", new Vector3(-9, 3f, 0), new Vector3(7, 0.3f, 3), new Color(0.2f, 0.5f, 0.9f));
        ramp.transform.rotation = Quaternion.Euler(0, 0, -20);

        // Primer empujón (se dispara al presionar ESPACIO)
        var launcher = ctrlGO.AddComponent<BallLauncher>();
        launcher.target = ballRb;
        launcher.direction = Vector3.right;
        launcher.force = 2f;
        UnityEventTools.AddPersistentListener(ctrl.onStart, launcher.Launch);

        // Plataforma baja tras la rampa
        Prim(PrimitiveType.Cube, "Plataforma", new Vector3(-2, 0.25f, 0), new Vector3(10, 0.5f, 3), new Color(0.3f, 0.7f, 0.4f));

        // Dominós
        for (int i = 0; i < 8; i++)
        {
            var d = Prim(PrimitiveType.Cube, $"Domino_{i}", new Vector3(-5 + i * 1.0f, 1.5f, 0), new Vector3(0.25f, 2f, 1.5f), Color.yellow);
            d.AddComponent<Rigidbody>().mass = 0.5f;
            d.AddComponent<ResettableObject>();
        }

        // Palanca (balancín) con bisagra
        var pivot = Prim(PrimitiveType.Cube, "PivoteBalancin", new Vector3(5, 1f, 0), new Vector3(0.4f, 1f, 1f), Color.gray);
        var plank = Prim(PrimitiveType.Cube, "Balancin", new Vector3(5, 1.7f, 0), new Vector3(5, 0.2f, 1.5f), new Color(0.6f, 0.4f, 0.2f));
        var plankRb = plank.AddComponent<Rigidbody>();
        plankRb.mass = 2f;
        var hinge = plank.AddComponent<HingeJoint>();
        hinge.axis = Vector3.forward;
        plank.AddComponent<ResettableObject>();

        // Bola que cae sobre el balancín desde un lado
        var ball2 = Prim(PrimitiveType.Sphere, "BolaPesada", new Vector3(3.2f, 4f, 0), Vector3.one * 0.7f, Color.magenta);
        ball2.AddComponent<Rigidbody>().mass = 3f;
        ball2.AddComponent<ResettableObject>();

        // Meta
        var goal = Prim(PrimitiveType.Cube, "Meta", new Vector3(11, 0.6f, 0), new Vector3(2.5f, 1.2f, 3), new Color(0.1f, 1f, 0.3f, 1f));
        goal.GetComponent<Collider>().isTrigger = true;
        goal.AddComponent<GoalTrigger>().machine = ctrl;

        // Cámara
        var cam = Camera.main;
        if (cam != null)
        {
            cam.transform.position = new Vector3(0, 5, -22);
            cam.transform.rotation = Quaternion.Euler(8, 0, 0);
        }

        EditorSceneManager.MarkSceneDirty(scene);
        Debug.Log("Escena base creada. Guárdala con Ctrl+S en Assets/Scenes/ y presiona Play (ESPACIO inicia, R reinicia).");
    }

    static GameObject Prim(PrimitiveType t, string name, Vector3 pos, Vector3 scale, Color color)
    {
        var go = GameObject.CreatePrimitive(t);
        go.name = name;
        go.transform.position = pos;
        go.transform.localScale = scale;
        go.GetComponent<Renderer>().sharedMaterial = new Material(go.GetComponent<Renderer>().sharedMaterial) { color = color };
        return go;
    }
}
#endif
