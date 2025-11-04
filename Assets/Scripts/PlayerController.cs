using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/4/25
 * Manages movement of Player
 */

public class PlayerController : MonoBehaviour
{
    
    private Vector3 direction; //Controls direction player is facing
    public float speed; //Controls speed of player
    public float jumpForce; //Controls height of player jump

    public Rigidbody rb; //Reference to players rigidbody for movement
    public float groundCheckDist; //Distance for which the player is considered "grounded"

    private bool missiles; //Checks if player has missile upgrade

    // Start is called before the first frame update
    void Start()
    {
        missiles = false;
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
    }

    private void FixedUpdate()
    {
        Move();
    }

    /// <summary>
    /// Controls player movement and rotates player accordingly
    /// </summary>
    private void Move()
    {
        //Moves the Player Left
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            //Sets direction to left
            direction = Vector3.left;

            //Sets rotaion to a set angle
            transform.rotation = Quaternion.Euler(0f, 0f, 0f);

            //Moves Player
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }

        //Moves the Player Right
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            //Sets direction to right
            direction = Vector3.right;

            //Sets rotaion to a set angle
            transform.rotation = Quaternion.Euler(0f, 180f, 0f);

            //Moves Player
            rb.MovePosition(transform.position + direction * speed * Time.deltaTime);
        }
       
    }


    /// <summary>
    /// Causes the player to jump using float jumpForce
    /// </summary>
    private void Jump()
    {
        //Lets the Player jump
        if ((Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.W)) && IsGrounded())
        {
            //Set direction Vector3 to move up
            direction = Vector3.up;
            //Lets the Player jump
            rb.AddForce(direction * jumpForce, ForceMode.Impulse);
        }
    }


    /// <summary>
    /// Performs a raycast downward from the player to check for the ground
    /// </summary>
    /// <returns>Returns True if Player is standing on the ground</returns>
    private bool IsGrounded()
    {

        bool IsGrounded = false;

        RaycastHit hit;

        //Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDist
        if (Physics.Raycast(transform.position, Vector3.down, out hit, groundCheckDist))
        {
            IsGrounded = true;
        }

        return IsGrounded;

    }


    /// <summary>
    /// Returns value of bool "hasMissiles"
    /// </summary>
    /// <returns>Returns true if player has missile upgrade and false if player does not</returns>
    public bool HasMissiles()
    {
        return missiles;
    }


    /// <summary>
    /// Sets hasMissiles to true;
    /// </summary>
    public void MissileUpgrade()
    {
        missiles = true;
    }
}
