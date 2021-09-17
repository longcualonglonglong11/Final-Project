using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace UnityChan{
        [RequireComponent(typeof(Animator))]
        [RequireComponent(typeof(CapsuleCollider))]
        [RequireComponent(typeof(Rigidbody))]
    public class UnitychanControl : MonoBehaviour
    {
        float animSpeed = 1.5f;
        float forwardSpeed = 2.5f;
        float runSpeed = 2.0f;
        float backwardSpeed = 2.0f;
        float rotateSpeed = 2.0f;
        float jumpForce = 4.0f;
        float h, v;

        bool run;
        private CapsuleCollider col;
        private Rigidbody rb;
        private Vector3 velocity;
        private float orgColHight;
		private Vector3 orgVectColCenter;
		private Animator anim;							
		private AnimatorStateInfo currentBaseState;		

		private GameObject Ucamera;
		static int idleState = Animator.StringToHash ("Base Layer.Idle");
		static int locoState = Animator.StringToHash ("Base Layer.Locomotion");
		static int jumpState = Animator.StringToHash ("Base Layer.Jump");
		static int restState = Animator.StringToHash ("Base Layer.Rest");

        ItemHandle itemHandle;

        void Start()
        {
            anim = GetComponent<Animator>();
            col = GetComponent<CapsuleCollider>();
            rb = GetComponent<Rigidbody>();
            Ucamera = GameObject.FindWithTag("MainCamera");
            orgColHight = col.height;
            orgVectColCenter = col.center;
            if (GameObject.Find("Character") != null)
                itemHandle = GameObject.Find("Character").GetComponent<ItemHandle>();
        }

        // Update is called once per frame
        void Update()
        {
            h = Input.GetAxis ("Horizontal");				
			v = Input.GetAxis ("Vertical");			
            if (v > 0.1 && run)
                v += 1.0f;	
			anim.SetFloat ("Speed", v);							
			anim.SetFloat ("Direction", h); 						
			anim.speed = animSpeed;								
			currentBaseState = anim.GetCurrentAnimatorStateInfo (0);
            if (Input.GetButtonDown("Jump") && !anim.IsInTransition(0)){
                itemHandle.jumpSound.Play();
                rb.AddForce (Vector3.up * jumpForce, ForceMode.VelocityChange);
                anim.SetBool("Jump", true);
            } else {
                anim.SetBool("Jump", false);
                if (currentBaseState.fullPathHash == idleState){
                    if (Input.GetKeyDown(KeyCode.Alpha3))
                        anim.SetBool("Rest", true);
                }
                else if (currentBaseState.fullPathHash == restState){
                    if (!anim.IsInTransition(0))
                        anim.SetBool("Rest", false);
                }
                if (Input.GetKeyDown(KeyCode.LeftShift))
                    run = !run;
            }
            if (currentBaseState.fullPathHash == jumpState){
                Ucamera.SendMessage("setCameraPositionJumpView");
            }
        }

        void FixedUpdate(){
            velocity = new Vector3(0, 0, v);
            velocity = transform.TransformDirection(velocity);
            if (v > 0.1f){
                if (run)
                    velocity *= forwardSpeed + runSpeed;
                else velocity *= forwardSpeed;
            }
            else if (v < -0.1f)
                velocity *= backwardSpeed;

            transform.localPosition += velocity * Time.fixedDeltaTime;
            transform.Rotate (0, h * rotateSpeed, 0);
        }

        void resetCollider ()
		{
			col.height = orgColHight;
			col.center = orgVectColCenter;
		}

    }
}
