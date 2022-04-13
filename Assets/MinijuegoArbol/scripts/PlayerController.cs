using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 9f;
    [SerializeField] private float runningSpeed = 14f;
    [SerializeField] private float cooldownTime = 15f;
    [SerializeField] private float speedBoostDuration = 5f;
    public float speed = 9;
    public bool isOnCooldown = false;
    public Vector3 direction;
    SpriteRenderer characterSprite;
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        characterSprite = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        ObtainInput();
        //si no esta corriendo, y apreta shift izquierda corre.
        if (!isOnCooldown)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                StartCoroutine("Run", speedBoostDuration);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine("ActivateCooldown", 3);
        }

        

        MoveCharacter(direction);

    }


    void ObtainInput()
    {
        direction = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
        direction.Normalize();
    }

    void MoveCharacter(Vector3 position)
    {
        rb.MovePosition(transform.position + position * Time.deltaTime * speed);
    }

    IEnumerator Run(float time)
    {
        characterSprite.color = Color.red;
        speed = runningSpeed;
        StartCoroutine("ActivateCooldown",cooldownTime);
        yield return new WaitForSeconds(time);
        characterSprite.color = Color.white;
        speed = walkingSpeed;

    }

    IEnumerator ActivateCooldown(float time)
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(time);
        isOnCooldown = false;

    }



}