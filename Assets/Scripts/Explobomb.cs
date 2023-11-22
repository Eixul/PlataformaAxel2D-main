using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explobomb : MonoBehaviour
{
    [SerializeField] private float radio;
    [SerializeField] private float fuerzaExplosion;

    
    public void Update()
    {
        
    }
    
    public void Explosion()
    {
        Collider2D[] initialObjetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach(Collider2D collider in initialObjetos)
        {
            Player player = collider.GetComponent<Player>();
            if (player != null)
            {
                player.Death();
            }
        }
        
        Collider2D[] objetos = Physics2D.OverlapCircleAll(transform.position, radio);

        foreach(Collider2D collider in objetos)
        {
            Rigidbody2D rB2D = collider.GetComponent<Rigidbody2D>();
            if(rB2D != null)
            {
                Vector2 direction = collider.transform.position - transform.position;
                float distancia = 1 + direction.magnitude;
                float fuerzaFinal = fuerzaExplosion / distancia;
                rB2D.AddForce(direction * fuerzaFinal);
            }
        }

        Destroy(gameObject);
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radio);
    }

    void OnCollisionEnter2D (Collision2D collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            Player player = collider.gameObject.GetComponent<Player>();
            player.Death();//Luego tiene que ser que pierda vida
            Destroy(gameObject);
        }
    }
}
