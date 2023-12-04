using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRunning : MonoBehaviour
{
    private bool isDead = false;//kiem tra trang thai chet
    private float YVelocity = 0f;//van toc theo truc y
    private float gravity = 9.8f;//gia toc
    private Vector3 moveVector;//vec to di chuyen
    private CharacterController player;//nhan vat
    private float animTime = 2f;//thoi gian animation


    [SerializeField] protected float speed = 5f;


    private void Awake()//khởi tạo các biến
    {
        player = GetComponent<CharacterController>();//anh xa
    }
    void Start()
    {
        
    }

    void Update()
    {
        if(Time.time<animTime)
        {
            player.Move(Vector3.forward * speed * Time.deltaTime);//di chuyen
        }
        else
        {
            if(isDead==false)//neu nhan vat khong chet
            {

                
                //kiem tra mat san
                if (player.isGrounded)
                {
                    YVelocity = -0.5f;
                    //YVelocity -= gravity * Time.deltaTime;
                }
                else //neu k phai san
                {
                    YVelocity -= gravity * Time.deltaTime;
                }
                //chuyen dong tung thanh phan
                moveVector.x = Input.GetAxis("Horizontal") * speed;
                //moveVector.y = YVelocity;
                //moveVector.y = Input.GetAxisRaw("Vertical") * -YVelocity;
                moveVector.z = speed;
                if (Input.GetKey(KeyCode.Space))
                {
                    moveVector.y = -YVelocity;
                }
                else
                {
                    moveVector.y = YVelocity;
                }

                //tong hoep
                player.Move(moveVector * Time.deltaTime);
            }
        }
    }
    public void SetSpeed(float s)//ham thay doi toc do
    {
        speed += s;
    }
    internal void Dead()//kiem tra trang thai chet
    {
        isDead = true;
    }
}
