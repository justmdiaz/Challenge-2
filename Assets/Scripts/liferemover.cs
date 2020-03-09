using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class liferemover : MonoBehaviour
{
    void OnTriggerEnter2D (Collider2D col)
    {
        PlayerScript.health -= 1;
    }

}
