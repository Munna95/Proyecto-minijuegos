using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingThings : MonoBehaviour
{
    public PlayerController pepe;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.CompareTag("Player"))
        {
            if (pepe.speed > 9)
            {
                //para ver que este corriendo
                transform.Translate(pepe.direction * 1.5f);
                //Debug.Log(pepe.direction);
                Debug.Log("CHOCAMOSSSSS");
            }
            else Debug.Log("apenas te toque...");
        }
    }

    // Update is called once per frame
    void Update()
    {

    }


}
