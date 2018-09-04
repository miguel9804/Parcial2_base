using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class Hazard : MonoBehaviour
{
    private Collider2D myCollider;
    private object myRigidbody;
    private int vida_APBullet = 2;

    [SerializeField]
    private float resistance = 1F;

    private float spinTime = 1F;
    
    // Use this for initialization
    protected void Start()
    { 
       
        myCollider = GetComponent<Collider2D>();
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    protected void OnCollisionEnter2D (Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Bullet>() != null)
        {
            //TODO: Make this to reduce damage using Bullet.damage attribute
            resistance -= 1;

            if (resistance == 0)
            {
               
                OnHazardDestroyed();
                Destroy(collision.gameObject);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag=="APBullet")
        {
            vida_APBullet -= 1;
            resistance -= 1;
            if(resistance==0)
            {
                OnHazardDestroyed();
                if(vida_APBullet==0)
                {
                    Destroy(collision.gameObject);
                }
            }
        }
    }

    protected void OnHazardDestroyed()
    {
        //TODO: GameObject should spin for 'spinTime' secs. then disappear
        Destroy(gameObject);
    }
}