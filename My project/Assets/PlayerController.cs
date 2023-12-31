using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Logic Variables
    public float jumpForce = 10f; // player force when jumping
    public float gravityModifier = 2f;
    public bool isOnGround = true;

    public bool gameOver = false;
    


    private Animator playerAnim;
    private Rigidbody playerRb;
    private AudioSource playerAudio;

    public ParticleSystem explosionParticle;    
    public ParticleSystem dirtParticle;    

    public AudioClip jumpSound;
    public AudioClip crashSound;

    // Start is called before the first frame update
    void Start()
    {
       playerRb = GetComponent<Rigidbody>(); 

       playerAnim = GetComponent<Animator>(); 

       playerAudio = GetComponent<AudioSource>(); 

       Physics.gravity *= gravityModifier;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver){
            Jump();
        }
    }
    void Jump(){
 
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);

            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");

            dirtParticle.Stop();

            playerAudio.PlayOneShot(jumpSound, 1.0f);
 
    }
    void ResetJump(){
            isOnGround = true;
    }

    void Die(){
        explosionParticle.Play();

        gameOver = true;
        Debug.Log("Game Over!");
        playerAnim.SetBool("Death_b",true);
        playerAnim.SetInteger("DeathType_int", 1);

        dirtParticle.Stop();

        playerAudio.PlayOneShot(crashSound, 1.0f);
 
    }

    private void OnCollisionEnter(Collision collision){
        if (collision.gameObject.CompareTag("Ground"))
        {
            ResetJump();

        } else if (collision.gameObject.CompareTag("Obstacle"))
        {
            Die();
        }
        
    }
}
