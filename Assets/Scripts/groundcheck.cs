using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class groundcheck : MonoBehaviour
{
    private Rigidbody2D rd2d;
    void FixedUpdate()
    { 
        float verMovement = Input.GetAxis("Vertical");

        rd2d.AddForce(new Vector2(0 * 0, verMovement * 2));


    }
    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision.collider.tag == "ground")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);
            }
        }
    }

}
