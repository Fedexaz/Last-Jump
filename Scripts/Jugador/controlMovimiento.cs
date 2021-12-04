using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class controlMovimiento : MonoBehaviour
{

    //SoundSystem
    public AudioClip[] Footstep;
    public float steprate;
    private AudioSource Play;
    private float cooldown;
    private float rate;

    //CORROBORAR DONDE ESTA PARADO

    public bool piso = true;

    //SISTEMA DE ANIMACIONES
    private Animator animacionesPersonaje;

    //VARIABLES CONTROL PERSONAJE

    public Button botonLevantarse;

    private CharacterController controller;

    private Vector3 playerVelocity;

    private bool groundedPlayer;
    public bool canUp = true;

    private float playerSpeed = 6f;
    private float gravityValue = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        animacionesPersonaje = gameObject.GetComponent<Animator>();
        Play = GetComponent<AudioSource>();
    }

    void Update()
    {
        ControlJugador();
    }

    void Stepsound()
    {
        if(piso)
        {
            if (cooldown < Time.time)
            {
                Play.clip = Footstep[0];
                Play.PlayOneShot(Play.clip);
                cooldown = Time.time + rate;
            }
        }
        else
        { 
            if (cooldown < Time.time)
            {
                Play.clip = Footstep[1];
                Play.PlayOneShot(Play.clip);
                cooldown = Time.time + rate;
            }
        }
    }

    private void ControlJugador()
    {
        if (animacionesPersonaje.GetBool("agachado"))
        {
            rate = steprate * 1.8f;
            playerSpeed = 2.5f;
            controller.center = new Vector3(0, 0.65f, 0);
            controller.height = 1.5f;
        }
        else 
        { 
            playerSpeed = 6f;
            controller.height = 3f;
            controller.center = new Vector3(0, 1.45f, 0);
            rate = steprate;
        }
        
        Vector2 movimiento = Gamepad.current.leftStick.ReadValue();

        //CONTROLADOR DE VELOCIDADES

        if (!animacionesPersonaje.GetBool("agachado"))
        {
            // 
            if (Gamepad.current.leftStick.ReadValue().x < .1 || Gamepad.current.leftStick.ReadValue().y < .1 || Gamepad.current.leftStick.ReadValue().y > -.1 || Gamepad.current.leftStick.ReadValue().x > -.1)
            {
                playerSpeed = .5f;
            }

            //
            if (Gamepad.current.leftStick.ReadValue().x < .2 || Gamepad.current.leftStick.ReadValue().y < .2 || Gamepad.current.leftStick.ReadValue().y > -.2 || Gamepad.current.leftStick.ReadValue().x > -.2)
            {
                playerSpeed = .5f;
            }

            //
            if (Gamepad.current.leftStick.ReadValue().x < .3 || Gamepad.current.leftStick.ReadValue().y < .3 || Gamepad.current.leftStick.ReadValue().y > -.3 || Gamepad.current.leftStick.ReadValue().x > -.3)
            {
                playerSpeed = 1f;
            }

            //
            if (Gamepad.current.leftStick.ReadValue().x < .4 || Gamepad.current.leftStick.ReadValue().y < .4 || Gamepad.current.leftStick.ReadValue().y > -.4 || Gamepad.current.leftStick.ReadValue().x > -.4)
            {
                playerSpeed = 2f;
            }

            //
            if (Gamepad.current.leftStick.ReadValue().x < .5 || Gamepad.current.leftStick.ReadValue().y < .5 || Gamepad.current.leftStick.ReadValue().y > -.5 || Gamepad.current.leftStick.ReadValue().x > -.5)
            {
                playerSpeed = 2.5f;
            }

            //
            if (Gamepad.current.leftStick.ReadValue().x < .6 || Gamepad.current.leftStick.ReadValue().y < .6 || Gamepad.current.leftStick.ReadValue().y > -.6 || Gamepad.current.leftStick.ReadValue().x > -.6)
            {
                playerSpeed = 3f;
            }

            //
            if (Gamepad.current.leftStick.ReadValue().x < .7 || Gamepad.current.leftStick.ReadValue().y < .7 || Gamepad.current.leftStick.ReadValue().y > -.7 || Gamepad.current.leftStick.ReadValue().x > -.7)
            {
                playerSpeed = 4f;
            }

            //
            if (Gamepad.current.leftStick.ReadValue().x < .8 || Gamepad.current.leftStick.ReadValue().y < .8 || Gamepad.current.leftStick.ReadValue().y > -.8 || Gamepad.current.leftStick.ReadValue().x > -.8)
            {
                playerSpeed = 5f;
            }

            if (Gamepad.current.leftStick.ReadValue().x > .9 || Gamepad.current.leftStick.ReadValue().y > .9 || Gamepad.current.leftStick.ReadValue().y < -.9 || Gamepad.current.leftStick.ReadValue().x < -.9)
            {
                playerSpeed = 6f;
            }
        }

        animacionesPersonaje.SetFloat("velocidad", movimiento.magnitude);

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        Vector3 move = new Vector3(Gamepad.current.leftStick.ReadValue().x, 0, Gamepad.current.leftStick.ReadValue().y);
        controller.Move(move * Time.deltaTime * playerSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
            Stepsound();
        }

        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if(!canUp)
        {
            botonLevantarse.interactable = false;
        }
        else
        {
            botonLevantarse.interactable = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Agachado")
        {
            canUp = false;
        }

        if (other.gameObject.tag == "sonidoPasoNormal")
        {
            piso = true;
        }

        if (other.gameObject.tag == "sonidoSendero")
        {
            piso = false;
        }

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Agachado")
        {
            canUp = true;
        }
    }

    public void Agacharse()
    {
        //AGACHARSE
        if (controller.isGrounded && !animacionesPersonaje.GetBool("agachado"))
        {
            animacionesPersonaje.SetBool("agachado", true);
        }
    }

    public void Levantarse()
    {
        //Levantarse
        if (controller.isGrounded && animacionesPersonaje.GetBool("agachado"))
        {
            animacionesPersonaje.SetBool("agachado", false);
        }
    }
 }
