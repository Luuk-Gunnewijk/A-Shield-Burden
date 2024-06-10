using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShield_Script : MonoBehaviour
{
    [SerializeField] ParticleSystem Block_Particle;
    [SerializeField] GameObject ShieldBounceObject;

    [SerializeField] private GameObject Shield_01;
    [SerializeField] private GameObject Shield_02;

    [SerializeField] LayerMask groundMask;

    PlayerMovement_Script myPlayerMovement_Script;


    private void Awake()
    {
        myPlayerMovement_Script = FindObjectOfType<PlayerMovement_Script>();
    }

    void Start()
    {
        Shield_01.SetActive(true);
        Shield_02.SetActive(false);
        ShieldBounceObject.SetActive(false);
    }

    void Update()
    {
        ShieldBounce();
        CheckWichShield();
        PlayBounceParticle();
    }

    void ShieldBounce()
    {
        if (Input.GetKey(KeyCode.Q) && Input.GetKey(KeyCode.S))
        {
            ShieldBounceObject.SetActive(true);
            Shield_01.SetActive(false);
            Shield_02.SetActive(false);
            CheckIfShieldIsOnGround();
        }
        else
        {
            ShieldBounceObject.SetActive(false);
            Shield_01.SetActive(true);
            Shield_02.SetActive(false);
        }
    }

    private void CheckWichShield()
    {
        if(myPlayerMovement_Script.Isrunning == true)
        {
            Shield_01.SetActive(false);
            Shield_02.SetActive(true);
        }
    }

    private bool CheckIfShieldIsOnGround()
    {
        RaycastHit2D hit;

        hit = Physics2D.Raycast(ShieldBounceObject.transform.position, Vector2.down, 1.0f, groundMask);

        return hit;
    }

    private void PlayBounceParticle()
    {
        if (CheckIfShieldIsOnGround() && ShieldBounceObject.active)
        {
            Block_Particle.Play();
        }
    }
}
