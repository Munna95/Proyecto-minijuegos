using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingThings : MonoBehaviour
{   
    [SerializeField] Text textoPrueba;
    public PlayerController cambiarNombre;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        textoPrueba.text = "Esta en cooldown?: " + cambiarNombre.isOnCooldown;
    }


}
