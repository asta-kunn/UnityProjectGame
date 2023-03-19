using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{

    private Rigidbody2D rb2d;
    [SerializeField] private Camera cam;
    [SerializeField] private GameObject gunPoint;
    [SerializeField] private Bullet bullet;
    
    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckCursor();

    }

    private void FixedUpdate()
    {
        Movement();
    }


    private void CheckCursor()
    {
        Vector3 mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 characterPos = transform.position;
        if (mousePos.x > characterPos.x)
        {
            this.transform.rotation = new Quaternion(0, 0, 0, 0);
        }
        else if (mousePos.x < characterPos.x)
        {
            this.transform.rotation = new Quaternion(0, 180, 0, 0);
        }
            
        
        // TODO : Implementasi player menembak jika mouse diklik kiri
        if (Input.GetMouseButtonDown(0))
        {   
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            Bullet firedBullet = Instantiate(bullet, gunPoint.transform);
            firedBullet.Init(mousePos);
        }
       
        
    }

    private void Movement()
    {
        // TODO : Implementasi movement player dan kamera mengikuti player
       
        if (Input.GetKey(KeyCode.W))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 20);
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        else if (Input.GetKey(KeyCode.S))
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -20);
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            rb2d.velocity = new Vector2(-20, rb2d.velocity.y);
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rb2d.velocity = new Vector2(20, rb2d.velocity.y);
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }
        else
        {
            rb2d.velocity = new Vector2(0, 0);
            cam.transform.position = new Vector3(transform.position.x, transform.position.y, -10);
        }

        

    }

}
