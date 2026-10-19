# Máquina de Rube Goldberg – Unity

Proyecto de Videojuegos (Univalle). Máquina de Rube Goldberg con física de Unity.

## Controles
- **ESPACIO**: inicia la máquina
- **R**: reinicia todos los objetos

## Scripts (`Assets/Scripts`)
| Script | Función |
|---|---|
| MachineController | Inicio, reinicio y cronómetro |
| ResettableObject | Guarda/restaura la posición inicial |
| TriggerZone | Dispara un evento al entrar un Rigidbody |
| BallLauncher | Da un impulso a un Rigidbody |
| MotorSpinner | Gira aspas/ruedas al activarse |
| MovingPlatform | Mueve pistones/puertas al activarse |
| GoalTrigger | Meta final |
| CameraFollow | Cámara que sigue un objeto |

## Crear la escena de ejemplo
Menú **Rube Goldberg > Crear escena base**, luego guardar en `Assets/Scenes/`.
