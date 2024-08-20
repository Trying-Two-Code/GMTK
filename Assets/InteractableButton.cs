using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : MonoBehaviour, IInteractable
{
    public BoxCollider[] FixThese;

    public AudioClip Sound;

    public MeshRenderer _button;
    public Material Deactivated;
    public Material Activated;

    public static int ButtonsPressed = 0;

    public float TimeTilNotPressed = 5f;
    private float t;

    private bool pressed = false;

    public Animator SetReady;
    public GameObject MoveThis;
    public Transform Here;
    public Door OpenThis;
    public int whenThisManyPressed;
    public float PlayerSpeedAdd;

    public bool dieOnClick = false;
    public void Interact(PlayerManager player)
    {
        if(_button != null)
        {
            _button.material = Activated;
        }
       
        ButtonsPressed += 1;
        t = TimeTilNotPressed;
        pressed = true;
    }

    private void Update()
    {

        if (pressed)
        {
            if (SetReady != null)
            {
                SetReady.SetBool("ready", true);
            }
            Debug.Log(ButtonsPressed);
            t -= Time.deltaTime;
            if(t <= 0)
            {
                DeactivateButton();
            }
            if(OpenThis != null)
            {
                if (ButtonsPressed >= whenThisManyPressed)
                {
                    OpenThis.Open();
                }
            }
            if(MoveThis != null)
            {
                if (ButtonsPressed >= whenThisManyPressed)
                {
                    MoveThis.transform.position = Here.position;
                    MoveThis = null;
                }
            }
            if (dieOnClick)
            {
                Destroy(gameObject);
            }
            if(PlayerSpeedAdd > 0)
            {
                PlayerController PC = GameObject.Find("Player").GetComponent<PlayerController>();
                PC.maxSprintSpeed += PlayerSpeedAdd;
                PC.maxSpeed += PlayerSpeedAdd;
                PC.acceleration += PlayerSpeedAdd;
            }
            if(Sound != null)
            {
                if (dieOnClick)
                {
                    CreateSound.SFX(Sound, 1, 0, null, 10f);
                }
                else
                {
                    CreateSound.SFX(Sound, 1, 0, transform, 10f);
                }
                
            }
            if(FixThese.Length != 0)
            {
                for (int i = 0; i < FixThese.Length; i++)
                {
                    FixThese[i].enabled = true;
                }
            }
        }
    }

    void DeactivateButton()
    {
        pressed = false;
        t = TimeTilNotPressed;
        ButtonsPressed -= 1;
        if(_button != null)
        {
            _button.material = Deactivated;
        }
        
    }

}
