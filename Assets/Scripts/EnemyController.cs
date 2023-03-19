using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private PlayerController player;
    private Rigidbody2D rb2d;


    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>(); 
    }
    private void CheckPlayer()
    {
        // TODO : Implementasi enemy mengecek apakah player berada di dalam radius
        
        Vector3 playerPos = player.transform.position;
        Vector3 enemyPos = this.transform.position;
        float distance = Vector3.Distance(playerPos, enemyPos);
        if (distance < 2.5f)
        {
            MoveEnemy(playerPos, enemyPos);
        }
    }

    private void MoveEnemy(Vector3 playerPos, Vector3 enemyPos)
    {
        // TODO : Implementasi enemy mengikuti player jika masuk dalam jangkauan radius
        this.transform.position = Vector2.MoveTowards(enemyPos, playerPos, 6 * Time.deltaTime);

        
    }



    private void FixedUpdate()
    {
        CheckPlayer();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(this.gameObject);
        }
    }
}
