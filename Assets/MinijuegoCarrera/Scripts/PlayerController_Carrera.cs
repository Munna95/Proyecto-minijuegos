using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController_Carrera : MonoBehaviour
{
    [SerializeField] float jumpForce;
    [SerializeField] float maxEnergy;
    [SerializeField] float minEnergy;
    [SerializeField] float addedEnergy;
    [SerializeField] float energyParameter; //este es el que va a multiplicar el tiempo, cambiar el nombre
    [SerializeField] float energy;
    [SerializeField] float mutiplier;
    Rigidbody2D rb;
    Vector2 inicialPosition = new Vector2(-8.11f, -3.43f);
    float contador = 0;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector2 inicialPosition = new Vector2(-8.11f, -3.43f);

    }

    // Update is called once per frame
    void Update()
    {
        movePlayer(energy);
        addEnergy();
        substractEnergy();

        Debug.Log(contador);


    }

    void movePlayer(float speed)
    {
        //rb.AddForce(new Vector2(1f, 0), ForceMode2D.Force);
        //rb.velocity = new Vector2(speed, 0);
        if (Input.GetKeyDown("space"))
        {
            rb.velocity = new Vector2(mutiplier * contador * contador * Time.deltaTime + rb.velocity.x, 0);
            contador++;
            if (contador > 20) contador = 20;
        }
        
    }

    void substractEnergy()
    {
        
        contador -= Time.deltaTime * (contador * contador)/ energyParameter;
        if (contador < 0) contador = 0;

        /*
        if (energy <= minEnergy)
        {
            energy = minEnergy;
        }
        else if (energy > maxEnergy * 0.75f) 
        {
            energy -= Time.deltaTime * energyParameter*4;
        }
        else if (energy > maxEnergy * 0.5f) 
        {
            energy -= Time.deltaTime * energyParameter * 3;
        }
        else if (energy > maxEnergy * 0.25f)
        {
            energy -= Time.deltaTime * energyParameter * 2;
        }
        else 
        {
            energy -= Time.deltaTime * energyParameter ;
        }
        */
    }

  
    void addEnergy()
    {
        
        if (energy >= maxEnergy)
        {
            energy = maxEnergy;
        }
        else if(Input.GetKeyDown("m")){
            
            energy += addedEnergy;
            contador++;
        }
        


    }
    float calculateSpeed(float energy)
    {

        return 2f;
    }

    public void tpBack()
    {
        transform.position = inicialPosition;
    }




}
