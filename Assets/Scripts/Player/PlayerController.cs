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
    }
    public void Move(InputAction.CallbackContext _ctx){
        moveVector = _ctx.ReadValue<Vector2>();
        print(moveVector);
    }
    public void Flip(){
        Vector3 newScale = transform.localScale;
        if(moveVector.x < 0){
            newScale.x = -1;   
        }
        else
            newScale.x = 1;
        transform.localScale = newScale;
    }
}
