using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller; // Bileşene erişim
    public float speed = 12f;
    public float gravity = -20f;
    public float jumpHeight = 3f;

    Vector3 velocity;
    bool isGrounded;

    void Update()
    {
        // Yerde miyiz kontrolü
        isGrounded = controller.isGrounded;

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        // Hareket Girdileri (W-A-S-D)
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Zıplama Mekaniği (Ödevin istediği parça)
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        // Yerçekimi Uygulama
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}