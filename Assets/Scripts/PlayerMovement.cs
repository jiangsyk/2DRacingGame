using UnityEngine;
using System.Collections;

/*
 * Description: PlayerMovement
 * Author:      JiangShu
 * Create Time: 2015/7/20 17:07:24
 */
public class PlayerMovement : MonoBehaviour
{
    public float speed = 10f;
    public float reverseSpeed = 10f;
    public float turnSpeed = .6f;

    private float moveDirection;
    private float turnDirection;

    public float currentSpeed;

    void Start()
    {

    }
    void Update()
    {
        moveDirection = Input.GetAxis("Vertical");
        turnDirection = Input.GetAxis("Horizontal");
    }
    void FixedUpdate()
    {
        currentSpeed = Mathf.Abs(transform.InverseTransformDirection(rigidbody2D.velocity).y);

        float maxDrag = 1;
        float currentDrag = 2.5f;

        float maxAngularDrag = 2.5f;
        float currentAngularDrag = 1;

        float dragLerpTime = currentSpeed * 0.1f;

        float myDrag = Mathf.Lerp(currentDrag, maxDrag, dragLerpTime);
        float myAngularDrag = Mathf.Lerp(currentAngularDrag, maxAngularDrag, dragLerpTime);

        if(moveDirection > 0)
        {
            moveDirection = moveDirection * speed;
            turnDirection = turnDirection * -turnSpeed;

            if(currentSpeed > 0.5f)
                rigidbody2D.AddTorque(turnDirection);//旋转
        }
        if(moveDirection < 0)
        {
            moveDirection = moveDirection * reverseSpeed;
            turnDirection = turnDirection * turnSpeed;

            if(currentSpeed > 0.5f)
                rigidbody2D.AddTorque(turnDirection);//旋转
        }
        rigidbody2D.AddForce(transform.up * moveDirection);

        rigidbody2D.drag = myDrag;
        rigidbody2D.angularDrag = myAngularDrag;
    }
}
