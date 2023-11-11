using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D rb;
    Animator playerAnim;
    
    Vector2 moveVector;
    
    [SerializeField] float moveSpeed;
    bool isAtking;
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        playerAnim = this.GetComponent<Animator>();
    }

    void Update()
    {
        if(moveVector != Vector2.zero){
            this.transform.position += new Vector3(moveVector.x,moveVector.y,0) * Time.deltaTime * moveSpeed;
            playerAnim.SetBool("isMove", true);
            Flip();

        }
        else{
            playerAnim.SetBool("isMove", false);
        }
        if(playerAnim.GetCurrentAnimatorStateInfo(0).IsName("Attack") && playerAnim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f){
            playerAnim.SetBool("isAttack", false);
        }
    }
    public void Move(InputAction.CallbackContext _ctx){
        moveVector = _ctx.ReadValue<Vector2>();
        print(moveVector);
    }
    public void Attack(InputAction.CallbackContext _ctx){
        if(_ctx.started){
            playerAnim.SetBool("isAttack", true);
            isAtking = true;
            print("ATTACK!!!");
        }
    }
    
    void Flip(){
        Vector3 newScale = transform.localScale;
        if(moveVector.x < 0){
            newScale.x = -1;   
        }
        else
            newScale.x = 1;
        transform.localScale = newScale;
    }
}
