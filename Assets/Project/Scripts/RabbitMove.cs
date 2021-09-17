using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RabbitMove : MonoBehaviour
{
    // Start is called before the first frame update

    private CapsuleCollider col;
    private Rigidbody rb;
    private Vector3 velocity;
    private Animator anim;
    private AnimatorStateInfo currentBaseState;
    float move, speed;
    Quaternion startRotation, endRotation;
    GameObject player;

    void Start()
    {
        anim = GetComponent<Animator>();
        col = GetComponent<CapsuleCollider>();
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
        //transform.Rotate(0,90f,0);
    }

    // Update is called once per frame
    void Update()
    {
        currentBaseState = anim.GetCurrentAnimatorStateInfo(0);
        move = Random.Range(0, 3.0f);
        if (Vector3.Distance (player.transform.position, transform.position) > 20f)
            Destroy(gameObject);
        if (move>2){
            if (currentBaseState.IsName("Idle")){
                startRotation = transform.rotation;
                endRotation = transform.rotation * Quaternion.Euler(0,Random.Range(-90f,90f),0);
                //transform.Rotate(0, Random.Range(0,90.0f), 0);
                speed = 0.8f;
                anim.Play("Run");
                velocity = new Vector3(0,0,speed);
                velocity = transform.TransformDirection(velocity);

                transform.rotation = Quaternion.Slerp(startRotation, 
                    endRotation, Time.fixedDeltaTime*10.0f);
            } 
        } //else speed = 0;
        else if (currentBaseState.IsName("Idle")){
            speed = 0;
            startRotation = transform.rotation;
            endRotation = transform.rotation;
        }
    }
    
    void FixedUpdate(){
        velocity = new Vector3(0,0,speed);
        velocity = transform.TransformDirection(velocity);
        transform.localPosition += velocity * Time.fixedDeltaTime;
       
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Physics.IgnoreCollision(player.GetComponent<Collider>(), GetComponent<Collider>());
        }
        if (collision.gameObject.tag == "Pond"){
            Destroy(gameObject);
        }
    } 
}
