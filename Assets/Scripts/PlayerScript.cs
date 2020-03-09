using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour
{
    private Rigidbody2D rd2d;

    public AudioClip WinSound;

    public AudioSource musicSource;
    public float speed;

    public Text score;

    private int scoreValue = 0;
    private int count;

    bool isGrounded = false;
    public Transform GroundCheck1; // Put the prefab of the ground here
    public LayerMask groundLayer; // Insert the layer here.

    public GameObject life1, life2, life3, over;
    public static int health;

    public Text winText;

    Animator anim;
    private bool facingRight = true;



    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();
        score.text = scoreValue.ToString();
        winText.gameObject.SetActive(false);

        anim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(hozMovement * speed, verMovement * speed));

      
        
        isGrounded = Physics2D.OverlapCircle(GroundCheck1.position, 0.15f, groundLayer); // checks if you are within 0.15 position in the Y of the ground

        if (Input.GetKeyDown(KeyCode.D))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.D))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            anim.SetInteger("State", 1);
        }

        if (Input.GetKeyUp(KeyCode.A))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            anim.SetInteger("State", 2);

            transform.Translate(new Vector3(hozMovement, 0, verMovement) * speed * Time.deltaTime);

        }

        if (Input.GetKeyUp(KeyCode.R))
        {
            anim.SetInteger("State", 0);
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            anim.SetInteger("State", 3);
        }

        if (Input.GetKeyUp(KeyCode.W))
        {
            anim.SetInteger("State", 0);
        }

        if (scoreValue >= 9)
        {
            winText.gameObject.SetActive(true);
         
        }

        if (facingRight == false && hozMovement > 0)
        {
            Flip();
        }
        else if (facingRight == true && hozMovement < 0)
        {
            Flip();
        }
    }

    void Flip()
    {
        facingRight = !facingRight;
        Vector2 Scaler = transform.localScale;
        Scaler.x = Scaler.x * -1;
        transform.localScale = Scaler;
    }

    void OnTrigger2D(Collider2D other)
    {
        if (scoreValue == 1)
        {
            transform.position = new Vector2(70.0f, 1.0f);
        }

        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      

        if (collision.collider.tag == "Coin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            Destroy(collision.collider.gameObject);


        }
        if (collision.collider.tag == "Enemy")
        {
            collision.gameObject.SetActive(false);
            GameControlScript.health = GameControlScript.health - 1;
            Destroy(collision.collider.gameObject);
        }

        if (scoreValue == 4)
        {
            GameControlScript.health = 3;
            transform.position = new Vector2(70.0f, 1.0f);
            
        }
        if (scoreValue == 9)
        {
            musicSource.clip = WinSound;
            musicSource.Play();
        }
    }

    



    private void OnCollisionStay2D(Collision2D collision)
    {
        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }
        
        if (collision.collider.tag == "ground")
        {
            

            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 4), ForceMode2D.Impulse);
                
            }
        }

        



    }
    void SetCountText()
    {
        score.text = "Count: " + scoreValue.ToString();
        if (scoreValue >= 4)
        {
            winText.text = "You Win";
            
        }

    }


}
