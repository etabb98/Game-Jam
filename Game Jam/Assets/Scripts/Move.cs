using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Transform start, end;
    public float moveSpeed = 2;
    public Transform startPos;

   private Vector2 nextPos;
    
    // Start is called before the first frame update
    void Start()
    {
        nextPos = startPos.position;
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, right, moveSpeed * Time.deltaTime);

        if (transform.position == start.position)
        {
            nextPos = end.position;
        }
        if (transform.position == end.position)
        {
            nextPos = start.position;
        }

        transform.position = Vector2.MoveTowards(transform.position, nextPos, moveSpeed * Time.deltaTime);

    }

    private void DrawGiz()
    {
        Gizmos.DrawLine(start.position, end.position);
    }
}
