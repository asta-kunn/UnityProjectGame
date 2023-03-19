using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float speed;
    [SerializeField] private Vector3 direction;
    public void Init(Vector3 direction)
    {
        this.direction = direction - this.transform.position;
        this.transform.SetParent(null);
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += transform.right * speed * Time.deltaTime;
    }

    // TODO : Implementasi behaviour bullet jika mengenai wall atau enemy
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(this.gameObject);
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }
        else if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }
}
