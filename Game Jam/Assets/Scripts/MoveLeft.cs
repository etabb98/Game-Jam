using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour
{
    public float Speed = 20;
    private PlayerController playerControllerScript; //reference other script
    //private float leftBound = -15;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();  //connects to other script //call specifically the player object 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * Speed); //deltatime has it move overtime instead of every frame

        /*if (playerControllerScript.gameOver == false) //if the gameOver var in the Player Controller Script //var must be public
        { 
            transform.Translate(Vector3.left * Time.deltaTime * Speed); //deltatime has it move overtime instead of every frame
        }
        
        if (transform.position.x < leftBound && gameObject.CompareTag("Obstacle"))
        {
            Destroy(gameObject);
        }*/
    }
}
