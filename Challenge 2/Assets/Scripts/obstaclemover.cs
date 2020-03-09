using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstaclemover : MonoBehaviour
{
    public Transform p1, p2;
    public Transform start;
    public float speed;

    Vector3 next;


    
    // Start is called before the first frame update
    void Start()
    {
        next = start.position;

    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position== p1.position)
        {
            next = p2.position;
        }
        if(transform.position== p2.position)
        {
            next = p1.position;
        }
        transform.position = Vector3.MoveTowards(transform.position, next, speed * Time.deltaTime);

        if (Input.GetKey("escape"))
            Application.Quit();
    }

}
