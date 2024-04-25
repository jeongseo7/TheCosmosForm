using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    private Animator animator;
    private Vector2 inputMovement = Vector2.zero;
    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    void Update()
    {
        Vector2 moveMovement = inputMovement * moveSpeed * Time.deltaTime;
        transform.Translate(moveMovement);
    }
    private void OnMove(InputValue inputValue)
    {
        inputMovement = inputValue.Get<Vector2>();
    }
    #region ũ��

    //bool isHorizonMove;
    //bool isVertonMove;

    //public float Speed = 5f;
    //Rigidbody2D rigidbody2d;
    //private Vector2 inputMovement = Vector2.zero;


    //void Awake()
    //{
    //    rigidbody2d = GetComponent<Rigidbody2D>();
    //    rigidbody2d.velocity = new Vector2(rigidbody2d.velocity.x, rigidbody2d.velocity.y);
    //}
    //void Update()
    //{

    //    Vector2 moveMovement = inputMovement * Speed * Time.deltaTime;
    //    transform.Translate(inputMovement);
    //    ////������ ���� ��������
    //    ////��ư�� ���� �� 
    //    //bool HorizonDown = Input.GetButtonDown("Horizonal");
    //    ////��ư�� �� ��
    //    //bool HorizonUp = Input.GetButtonUp("Horizonal");
    //    ////��ư�� ���� ��
    //    //bool VerticalDown = Input.GetButtonDown("Vertical");
    //    ////��ư�� �� ��
    //    //bool VerticalUp = Input.GetButtonUp("Vertical");

    //    //Ű�Է�
    //    //float moveHer = Input.GetAxis("Horizontal");
    //    //float moveVer = Input.GetAxis("Vertical");


    //    // 
    //    //if(HorizonDown || VerticalUp)
    //    //{
    //    //    isHorizonMove = true;
    //    //}
    //    //else if(VerticalDown|| HorizonUp)
    //    //{
    //    //    isHorizonMove= false;
    //    //}


    //}
    //private void OnMove(InputValue inputvalue)
    //{
    //    inputMovement = inputvalue.Get<Vector2>();
    //}

    #endregion
}
