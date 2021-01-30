using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 2.0f;
    private float jumpHeight = 1.0f;
    private float gravityValue = -9.81f;
    public bool hide = false;
    public float speedBonus = 1;
    public float speedBonusTime = 0;
    private AudioSource footsteps;

    private void Start()
    {
        GameObject child = this.transform.Find("Footsteps").gameObject;
        footsteps = child.GetComponent<AudioSource>();
        controller = gameObject.AddComponent<CharacterController>();
    }

    void Update()
    {
        if (!hide)
        {
            if (speedBonusTime > 0)
            {
                speedBonusTime -= Time.deltaTime;
            }
            else
            {
                speedBonus = 1;
            }
            groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
                groundedPlayer = controller.isGrounded;
            if (groundedPlayer && playerVelocity.y < 0)
            {
                playerVelocity.y = 0f;
            }

            Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            controller.Move(move * Time.deltaTime * playerSpeed * speedBonus);

            if (move != Vector3.zero)
            {
                if (!footsteps.isPlaying) footsteps.Play();
                gameObject.transform.forward = move;
            }
            else
            {
                footsteps.Stop();
            }
            playerVelocity.y += gravityValue * Time.deltaTime;
            controller.Move(playerVelocity * Time.deltaTime);
        }
        if (Input.GetKeyDown("h"))
        {
            hide = !hide;
        }
    }
}