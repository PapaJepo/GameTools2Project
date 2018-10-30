using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Footprint : MonoBehaviour {

	[SerializeField] GameObject f_footprint;

    private Animator f_animator;
    

    private Transform f_rightTransform;
    private Transform f_leftTransform;


    void Start()
    {
        f_animator = GetComponent<Animator>();

        f_rightTransform = f_animator.GetBoneTransform(HumanBodyBones.RightFoot);
        f_leftTransform = f_animator.GetBoneTransform(HumanBodyBones.LeftFoot);

    }
	
	
	void Update ()
    {
		
	}

    public void MakeRFootprint()
    {
        Instantiate(f_footprint, f_rightTransform.position, f_rightTransform.rotation);
        
    }

    public void MakeLFootprint()
    {            
        Instantiate(f_footprint, f_leftTransform.position, f_leftTransform.rotation);
          
    }

}
