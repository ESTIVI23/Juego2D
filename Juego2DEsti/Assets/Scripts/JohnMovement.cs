using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John_Player : MonoBehaviour
{
    public float Speed;   //  
    public float JumpForce; // para la velocidad del salto

    private Rigidbody2D Rigidbody2D;
    private float Horizontal;
    private bool Grounded;// es verdadero ho falso  si tocas el piso o si no tocas el piso 
   // public float velocidadMaxima = 5.0f;
          

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");   //este llama a una funcion  //que tiene como parametro horizontal esto indica que si apreta la letra a o la d a-1 y d 1
        Debug.DrawRay(transform.position, Vector3.down * 0.1000f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 0.1000f))
        {
            Grounded = true;
        }
        else Grounded = false;


        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }                                           
    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up *JumpForce);
    }
     


    private void FixedUpdate()
    {
        Rigidbody2D.velocity =  new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        //Rigidbody2D.velocity = new Vector2(Horizontal * velocidadMaxima, Rigidbody2D.velocity.y);
        
    }
}
