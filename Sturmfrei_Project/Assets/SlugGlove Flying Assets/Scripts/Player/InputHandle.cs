using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandle : MonoBehaviour
{
    private PlayerMovement Player;

    public float Horizontal;
    public float Vertical;

    public bool Jump;
    public bool JumpHold;

    public bool Accelerate;

    public bool Dashing;

    //public bool LB;
    //public bool RB;

    public bool Fly;

    private void Start()
    {
        Player = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxis("Horizontal");
        Vertical = Input.GetAxis("Vertical");

        Jump = Input.GetButtonDown("Jump");
        Dashing = Input.GetButtonDown("Dashing");
        //JumpHold = Input.GetButton("Jump");
        //Fly = JumpHold; 

        //RB = Input.GetButton("RightTilt");
        //LB = Input.GetButton("LeftTilt");

    }
}
