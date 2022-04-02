using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float shootSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3 (Time.deltaTime * shootSpeed, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D done)
    {
        Destroy(gameObject);
    }
}