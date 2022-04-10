using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float walkingSpeed = 9f;
    [SerializeField] private float runningSpeed = 14f;
    [SerializeField] private float cooldownTime = 15f;
    [SerializeField] private float speedBoostDuration = 5f;
    float speed = 9;
    public bool isOnCooldown = false;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
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
        direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        direction.Normalize();
    }

    void MoveCharacter(Vector2 position)
    {
        transform.Translate(position * Time.deltaTime * speed);
    }

    IEnumerator Run(float time)
    {
        speed = runningSpeed;
        StartCoroutine("ActivateCooldown",cooldownTime);
        yield return new WaitForSeconds(time);
        speed = walkingSpeed;

    }

    IEnumerator ActivateCooldown(float time)
    {
        isOnCooldown = true;
        yield return new WaitForSeconds(time);
        isOnCooldown = false;

    }



}