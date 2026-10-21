# Máquina de Rube Goldberg – Unity

Primer taller de Videojuegos

Máquina de Rube Goldberg hecha en Unity usando únicamente el motor de física del editor. Una pelota baja por una rampa, rebota sobre una serie de pilares con textura de cemento, cae al piso de madera y tumba un grupo de canecas.

## Autor

- **Nombre:** Sebastian Saldaña
- **Curso:** Videojuegos 
- **Repositorio:** https://github.com/Saldana07/PrimerTallerVideojuegos

## Requisitos

- Unity 6 (render pipeline: Universal Render Pipeline)
- Git

## Cómo abrir el proyecto

1. Clona el repositorio:
   ```bash
   git clone https://github.com/Saldana07/PrimerTallerVideojuegos.git
   ```
2. En Unity Hub, elige **Add > Add project from disk** y selecciona la carpeta clonada.
3. Espera a que Unity genere la carpeta `Library` (la primera vez tarda unos minutos).
4. Abre la escena `Assets/Scenes/Maquina.unity`.
5. Presiona **Play**.

## Cómo funciona la máquina

1. **Rampa:** la pelota arranca en lo alto de una rampa inclinada y rueda por ella.
2. **Pilares:** la pelota rebota de un pilar a otro, cada uno más bajo que el anterior.
3. **Piso:** el piso no tiene rebote, así que la pelota pierde el salto y rueda hacia el final.
4. **Bolos:** la pelota golpea el grupo de bolos y los tumba.

## Componentes y físicas

| Elemento | Componentes principales |
|---|---|
| Pelota | Sphere Collider (con Physics Material `Rebote`) y Rigidbody (Mass = 1, Continuous Dynamic, Freeze Position Z) |
| Rampa | Cubo inclinado con Box Collider |
| Pilares | Cilindros fijos con Capsule Collider, sin Rigidbody |
| Piso | Cubo con Box Collider y Physics Material sin rebote |
| Bolos | Rigidbody de masa baja y Collider para que caigan al ser golpeados |



## Estructura del proyecto

```
Assets/
├── Materials/   Materiales visuales y Physics Materials
├── Prefabs/     Prefabs de la escena
├── Scenes/      Escena principal (Maquina)
├── Textures/    Texturas usadas en los materiales
└── Settings/    Configuración de URP
```

