using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

    Animator c_anim;
    
    public Transform BulletSpawn;
    public GameObject Bullet;
    public Transform Enemy;

    private float BulletSpeed = 500;
    public float health = 30f;

    Collider BulletCol;

    void Start ()
    {
        c_anim = GetComponent<Animator>();
        

    }
	
	
	void Update ()
    {
        float move = Input.GetAxis("Vertical");
        c_anim.SetFloat("forward", move);
        float strafe = Input.GetAxis("Horizontal");
        c_anim.SetFloat("strafe", strafe);
        bool crouch = Input.GetKey(KeyCode.C);
        c_anim.SetBool("crouched", crouch);
        bool shoot = Input.GetMouseButtonDown(0);
        c_anim.SetBool("shoot", shoot);
        
        

        if (health <= 0)
        {
            bool die = true;
            c_anim.SetBool("die", die);
            Destroy(gameObject, 3f);
        }

    }

    public void ActiveShoot()
    {
        
        GameObject Shoot;
        Rigidbody BulletPhys;
        //Destroy(Shoot, 3f);
        Shoot = Instantiate(Bullet, BulletSpawn.transform.position, BulletSpawn.transform.rotation) as GameObject;


        BulletPhys = Shoot.GetComponent<Rigidbody>();
        BulletPhys.AddForce(transform.forward * BulletSpeed);
        Destroy(Shoot, 1f);

       
    }

   
}
