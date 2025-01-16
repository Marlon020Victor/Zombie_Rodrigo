using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBasics : MonoBehaviour
{
    
    public float Forca;
    public float Speed;
    private Rigidbody2D rig;
    private Animator anim;
    public bool Nochao;
    public bool Jumping = false;
    
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D Player)
    {
        if (Player.gameObject.tag == "NoChao")
        {
            Nochao = true;
        }
    }
    
    // Update is called once per frame
    void Update()
    {
        
        if (Jumping == false)
        {
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"),0f,0f);
            transform.position += movement * Speed;

            float input = Input.GetAxis("Horizontal");

            if (input > 0)
            {
                transform.eulerAngles = new Vector2(0f, 0f);
                //anim.SetBool("Walk", true);
            }
            else if (input < 0)
            {
                transform.eulerAngles = new Vector2(180f, 0f);
                //anim.SetBool("Walk", true);
            }
            else
            {
                //anim.SetBool("Walk", true);  
            }
            
            if (Input.GetKey(KeyCode.F) && Jumping == false)
            {
                //anim.SetBool("Attack", true);
            }
            else
            {
                //anim.SetBool("Attack", false);
            }
            
        }
        
        if (Input.GetButtonDown("Jump") && Nochao && Jumping == false)
        {
            rig.AddForce(Vector2.up * Forca, ForceMode2D.Impulse);
            Nochao = false;
            Jumping = true; 
            //anim.SetBool("Jump", true);
        }
        else
        {
            Jumping = false;
        }
        
        
    }
}
