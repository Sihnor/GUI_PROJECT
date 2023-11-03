using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEditor.Rendering;
using UnityEditorInternal;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public Vector2 playerPos;
    public AudioSource walkSound;
    public AudioSource jumpSound1;
    public AudioSource jumpSound2;
    public Rigidbody2D rB;
    public SpriteRenderer sR;


    public float speed = 1f;
    [SerializeField] public float normalSpeed = 2f;
    [SerializeField] public float sprintSpeed = 4f;
    [SerializeField] public float jumpForce = 1.5f;
    [SerializeField] public float maxRotation = 2f;
    [SerializeField] public bool sprint = false;
    [SerializeField] public bool jumping = false;
    [SerializeField] public float jumpTime;
    [SerializeField] public BoxCollider2D gC;

    [SerializeField] public int hP = 8;
    private void Start()
    {
        rB = GetComponent<Rigidbody2D>();
        sR = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        float zRotation = transform.rotation.eulerAngles.z;

        SprintCheck();
        InputCheck();
        JumpCheck();
        AngelCheck(zRotation);
    }



    private void InputCheck()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            sR.flipX = true;
            playerPos = transform.position;
            playerPos.x -= speed * Time.deltaTime;
            transform.position = playerPos;
        }
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            sR.flipX = false;
            playerPos = transform.position;
            playerPos.x += speed * Time.deltaTime;
            transform.position = playerPos;
        }
    }
    public void JumpCheck()
    {
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && !jumping)
        {
            Jump();
            jumping = true;
            Vector2 force = Vector2.zero;
            force.y += jumpForce / 2;
            rB.AddForce(force, ForceMode2D.Impulse);
        }
    }
    public void SprintCheck()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = normalSpeed;
        }
    }

    public void AngelCheck(float zRotation)
    {
        if (zRotation > maxRotation || zRotation < -maxRotation)
        {
            rB.angularVelocity = 0f;
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f);
        }
    }

    public void Step()
    {
        walkSound.Play();
    }

    public void Jump()
    {
        System.Random rnd = new System.Random();
        int temp = rnd.Next(0, 2);
        if (temp == 0) jumpSound1.Play();
        if (temp == 1) jumpSound2.Play();
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Floor"))
        {
            jumping = false;
        }
    }

    public void dealDamage(int _dmage)
    {
        if (hP < 0)
        {
            hP = 0;
        }
        else
        {
            hP -= _dmage;
        }
    }
}
