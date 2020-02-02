using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed=6f;
    public float cameraMaxDistance=100f;
    private int floormask;
    private Rigidbody playerRb;
    private Rigidbody pointRb;
    private Vector3 movement;
    private Animator anim;
    

    void Awake(){
        playerRb=GetComponent<Rigidbody>();
        pointRb=transform.GetChild(0).GetComponent<Rigidbody>();
        floormask=LayerMask.GetMask("Floor");
        anim=GetComponent<Animator>();
        
    }

    void FixedUpdate()
    {
        float horizontalMove=Input.GetAxisRaw("Horizontal");
        float VerticalMove=Input.GetAxisRaw("Vertical");
        Moveing(horizontalMove,VerticalMove);
        Turning();
        Animating(horizontalMove,VerticalMove);

    }
    
    void Moveing(float horizontalMove,float verticalMove){
        movement.Set(horizontalMove,0f,verticalMove);
        movement=movement.normalized*speed*Time.deltaTime;
        playerRb.MovePosition(transform.position+movement);

    }

    void Turning(){
        Ray cameraRay=Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit cameraHit;
        if(Physics.Raycast(cameraRay,out cameraHit,cameraMaxDistance,floormask)){
            Vector3 playerToMouse=cameraHit.point-transform.position;
            Quaternion newRotation=Quaternion.LookRotation(playerToMouse);
            //playerRb.MoveRotation(newRotation);
            pointRb.MoveRotation(newRotation);
            pointRb.gameObject.transform.position=gameObject.transform.position;
            }
    }
    
    void Animating(float horizontalMove,float verticalMove){
        bool walking=horizontalMove !=0f|| verticalMove !=0f;
    //anim.SetBool("isWalking",walking);
    }
    }
