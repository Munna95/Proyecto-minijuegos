using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    [SerializeField] private float initialSpeed;
    [SerializeField] private float runningSpeed;
    [SerializeField] private float cooldownTimeSeconds;
    [SerializeField] private int speedBoostDuration;
    float speed;
    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ObtainInput();

        if (IsOnCooldown())
        {
            cooldownTimeSeconds -= Time.deltaTime;
        }
        else
        {
            cooldownTimeSeconds = 0;
        }

        IsOnCooldown();

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }
        else speed = initialSpeed;

        MoveCharacter(direction);

    }

    /*
    void checkOnRun()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runningSpeed;
        }
        else speed = initialSpeed;
    }*/
    bool IsOnCooldown()
    {
        return cooldownTimeSeconds > 0;
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

}