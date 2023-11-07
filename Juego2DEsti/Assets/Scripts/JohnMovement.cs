using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class John_Player : MonoBehaviour
{
    public GameObject BulletPrefab;
    public float JumpForce; // para la velocidad del salto

    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    public float escala = 1.0f;
    

    private float Horizontal;
    private bool Grounded;// es verdadero ho falso  si tocas el piso o si no tocas el piso 
    public float velocidadMaxima = 5.0f;
    private float lastShoot;
          

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");   //este llama a una funcion  //que tiene como parametro horizontal esto indica que si apreta la letra a o la d a-1 y d 1

       

       

        if (Horizontal < 0.0f) transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);

        else if (Horizontal > 0.0) transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        // Multiplica la escala actual por el valor de "escala"
        transform.localScale = new Vector3(escala * (Horizontal < 0.0f ? -1.0f : 1.0f), 15.0f, 15.0f);

        Animator.SetBool("running", Horizontal != 0.0f);
        
        Debug.DrawRay(transform.position, Vector3.down * 1.5f, Color.red);
        if (Physics2D.Raycast(transform.position, Vector3.down, 1.5f))
        {
            Grounded = true;
        }
        else Grounded = false;


        if (Input.GetKeyDown(KeyCode.W) && Grounded)
        {
            Jump();
        }

        if (Input.GetKey(KeyCode.Space) && Time.time > lastShoot + 0.25f)
        {
            Shoot();
            lastShoot = Time.time;
        }

    }
    private void Jump()
    {
        Rigidbody2D.AddForce(Vector2.up*JumpForce);
    }

    private void Shoot()
    {
        Vector3 direction;
        if (transform.localScale.x > 0.0f) // Si el personaje mira hacia la derecha (escala positiva en x)
        {
            direction = Vector2.right; // Disparar hacia la derecha
        }
        else
        {
            direction = Vector2.left; // Disparar hacia la izquierda
        }

        GameObject bullet = Instantiate(BulletPrefab, transform.position + direction * 0.1f, Quaternion.identity);
        bullet.GetComponent<BulletSripts>().SetDirection(direction);
    }



    private void FixedUpdate()
    {
        //Rigidbody2D.velocity =  new Vector2(Horizontal * Speed, Rigidbody2D.velocity.y);
        Rigidbody2D.velocity = new Vector2(Horizontal * velocidadMaxima, Rigidbody2D.velocity.y);
        
    }
}
