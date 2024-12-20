using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawMove : MonoBehaviour
{
    public Transform[] patrolpoints;
    public float moveSpeed;
    public int patrolDestination;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (patrolDestination == 0)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[0].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolpoints[0].position)<.2f)
            {
                transform.localScale = new Vector3(1,1,1);
                patrolDestination = 1;
            }
        }
        if (patrolDestination == 1)
        {
            transform.position = Vector2.MoveTowards(transform.position, patrolpoints[1].position, moveSpeed * Time.deltaTime);
            if(Vector2.Distance(transform.position, patrolpoints[1].position) <.2f)
            {
                transform.localScale = new Vector3(1,1,1);
                patrolDestination = 0;
            }
        }
    }
}
