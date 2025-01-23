using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GallinaMovimiento : MonoBehaviour
{
    [SerializeField] float velocidad = 5f;  // La velocidad de la gallina
    [SerializeField] float gravedad = -9.8f;  // La gravedad que afectará a la gallina
    [SerializeField] CharacterController controller;

    // Start se llama al principio
    void Start()
    {
        // Obtén el CharacterController adjunto al objeto
        controller = GetComponent<CharacterController>();
    }

    // Update se llama una vez por frame
    void Update()
    {
        // Obtener las entradas de movimiento (WASD o las flechas)
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        // Crear un vector de movimiento basado en las entradas
        Vector3 movimiento = new Vector3(movimientoHorizontal, 0, movimientoVertical);

        // Ajustar la dirección del movimiento
        movimiento = -transform.TransformDirection(movimiento);

        // Aplicar velocidad
        controller.Move(movimiento * velocidad * Time.deltaTime);

        // Aplicar gravedad
        if (!controller.isGrounded)
        {
            movimiento.y += gravedad * Time.deltaTime;
        }

        // Mover al personaje con la gravedad incluida
        controller.Move(movimiento * Time.deltaTime);
    }
}
