using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Chris Pimentel
 * 11/4/25
 * Manages movement and other aspects of the Player
 */

public class PlayerController : MonoBehaviour
{
    public int maxHealth = 99; //How much  health the player can have
    private int health; //How much health the player currently has
    public HealthBar healthBar; //Reference to health bar on UI

    private bool canBeDamaged; //Allows for invincibility frames
    public float iframeTime = 5f; //How long the player is invincible after getting hit
    private bool isBlinking; //Controls if the player is blinking
         
    private Vector3 direction; //Controls direction player is facing
    public float speed = 10; //Controls speed of player
    public float jumpForce = 5; //Controls height of player jump

    public Rigidbody rb; //Reference to players rigidbody for movement
    public float groundCheckDist = 1.5f; //Distance for which the player is considered "grounded"

    private bool missiles; //Checks if player has missile upgrade

    // Start is called before the first frame update
    void Start()
    {
        missiles = false; //Player does not start with missiles;
        health = maxHealth; //health is set to current possible max health
        healthBar.SetMaxHealth(maxHealth); //Set health bar to reflect current health
        canBeDamaged = true; //Player can be damaged to start;
        isBlinking = false; //Player does no start out blinking
    }

    // Update is called once per frame
    void Update()
    {
        Jump();
        Blink();
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
    /// Takes health away from player by a certain amount
    /// </summary>
    /// <param name="damage"></param>
    public void GetDamaged(int damage)
    {
        //Checks if player has no iframes
        if (canBeDamaged)
        {
            health -= damage;
            healthBar.SetHealth(health);
        }

        StartCoroutine(WaitToBeDamaged());

    }


    /// <summary>
    /// Refills health of the player by a certain amount
    /// Health can NOT go over maxHealth
    /// </summary>
    /// <param name="healing"></param>
    public void GetHealed(int healing)
    {
        health += healing;

        //If health goes past maxHealth, keep health at max
        if (health > maxHealth)
            health = maxHealth;

        healthBar.SetHealth(health);
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


    /// <summary>
    /// Increases maxHealth and heals player to max
    /// </summary>
    /// <param name="addedHealth"></param>
    public void HealthUpgrade(int addedHealth)
    {
        maxHealth += addedHealth;
        health = maxHealth;

        healthBar.SetHealth(health);  
    }


    /// <summary>
    /// Doubles the jump height of player
    /// </summary>
    public void JumpUpgrade()
    {
        jumpForce *= 2;
    }


    private IEnumerator WaitToBeDamaged()
    {
        //Player can no longer be damaged
        canBeDamaged = false;
        //Player blinks to indicate iframes
        isBlinking = true;
        StartCoroutine(Blink());


        //Player is invincible for "iframeTime" seconds
        yield return new WaitForSeconds(iframeTime);

        //Player can now be damaged
        canBeDamaged = true;
        //Player no longer blinks
        isBlinking = false;
    }

    private IEnumerator Blink()
    {
        for (int i = 0; isBlinking; i++)
        {
            if (i % 2 == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
            }
            else
            {
                GetComponent<MeshRenderer>().enabled = true;
            }
            yield return new WaitForSeconds(.1f);
        }
        GetComponent<MeshRenderer>().enabled = true;
    }
}
