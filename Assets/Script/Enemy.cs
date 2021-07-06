using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 10;
    protected float force = 1f;
    protected float mass = 20;
    protected Rigidbody2D enemyRb;
    // Start is called before the first frame update
    public virtual void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyRb.mass = mass;
        enemyRb.drag = 0;
        enemyRb.gravityScale = 0;
        gameObject.layer = 7;
        gameObject.tag = "Enemy";
        enemyRb.AddRelativeForce(Vector2.up * force * enemyRb.mass, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        Move();
    }

    public virtual void Move()
    {
        enemyRb.AddRelativeForce(Vector2.up * force * enemyRb.mass);
    }
    public virtual void OnCollisionEnter2D(Collision2D other) {
        // Debug.Log(gameObject.name);
        if(other.gameObject.tag == "PlayerBullet")hp--;
        if(other.gameObject.name == "DestroyWall")Destroy(gameObject);
        if(hp < 1)Destroy(gameObject);
    }
}
