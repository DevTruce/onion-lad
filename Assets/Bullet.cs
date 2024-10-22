using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Rigidbody2D RB => GetComponent<Rigidbody2D>();

    void Update() => transform.right = RB.linearVelocity;

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.tag == "Target")
        {
            Destroy(gameObject);
            Destroy(collision.gameObject);
        }
    }
}
