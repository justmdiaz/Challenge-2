﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControlScript : MonoBehaviour
{
    public GameObject life1, life2, life3, over;
    public static int health;
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        life1.gameObject.SetActive(true);
        life2.gameObject.SetActive(true);
        life3.gameObject.SetActive(true);
        over.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (health > 3)
            health = 3;

        switch (health)
        {
            case 3:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(true);
                break;

            case 2:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(true);
                life3.gameObject.SetActive(false);
                break;

            case 1:
                life1.gameObject.SetActive(true);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                break;

            case 0:
                life1.gameObject.SetActive(false);
                life2.gameObject.SetActive(false);
                life3.gameObject.SetActive(false);
                over.gameObject.SetActive(true);
                Destroy(player);
                break;      
        }
        
     
    }
}
