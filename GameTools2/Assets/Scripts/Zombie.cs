using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour {

    public Transform player;
    public float speed;
    Animator z_anim;
    public float health = 10f;
    public float damage = 10f;
    public GameObject Player;
    public AudioSource Bite,Death;
    



    void Start ()
    {
        z_anim = GetComponent<Animator>();
        
	}
	
	
	void Update ()
    {
        //TakeDamage();
        Debug.Log(health);
        float step = speed * Time.deltaTime;
        float dist = Vector3.Distance(player.position, transform.position);

        if(dist < 10 && dist >2)
        {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, step);
            bool walk = true;
            z_anim.SetBool("PlayerClose", walk);

            if(dist<3)
            {
                walk = false;
                z_anim.SetBool("PlayerClose", walk);
                bool attack = true;
                z_anim.SetBool("Attack", attack);

                

            }
           
        }
        else
        {
           bool walk = false;
           z_anim.SetBool("PlayerClose", walk);
        }

        if (health <= 0)
        {
            Death.Play();
            bool walk = false;
            z_anim.SetBool("PlayerClose", walk);
            bool attack = false;
            z_anim.SetBool("Attack", attack);
            bool die = true;
            z_anim.SetBool("Die", die);
            Destroy(gameObject, 3f);
        }
    }

    /*public void TakeDamage()
    {
        if(health<=0)
        {
            
            bool walk = false;
            z_anim.SetBool("PlayerClose", walk);
            bool attack = false;
            z_anim.SetBool("Attack", attack);
            bool die = true;
            
            z_anim.SetBool("Die", die);
        }

    }*/
    public void AttackHit()
    {
        Bite.Play();
        GameObject.Find("player").GetComponent<Movement>().health -= damage;
        Animator c_anim = Player.GetComponent<Animator>();
        c_anim.SetTrigger("Damage");
        
    }


}
