using UnityEngine;
using System.Collections;

/*
 * Description: EnemyMovement
 * Author:      JiangShu
 * Create Time: 2015/7/24 16:52:46
 */
public class EnemyMovement : MonoBehaviour
{
    public float aiSpeed = 10;
    public float aiTurnSpeed = 5;


    public Transform[] waypoints;
    int currentWaypoint = 0;
    Vector3 currentWaypointPosition;
    void Start()
    {

    }
    void Update()
    {

    }

    public void FixedUpdate()
    {
        MoveTowardWaypoints();   
    }
    
    void MoveTowardWaypoints()
    {
        float currentWaypointX = waypoints[currentWaypoint].position.x;
        float currentWaypointY = waypoints[currentWaypoint].position.y;
        float currentWaypointZ = transform.position.z;
        currentWaypointPosition = new Vector3(currentWaypointX, currentWaypointY, currentWaypointZ);
        Quaternion toRotation = Quaternion.FromToRotation(Vector3.up, currentWaypointPosition - transform.position);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, aiTurnSpeed);
        rigidbody2D.AddForce(transform.up * aiSpeed);

        //计算距离
        Vector3 relativeWaypoint = transform.InverseTransformPoint(currentWaypointPosition);
        if(relativeWaypoint.sqrMagnitude < 10)
        {
            currentWaypoint++;
            if(currentWaypoint == waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        //阻力
        float currentSpeed = Mathf.Abs(transform.InverseTransformDirection(rigidbody2D.velocity).y);

        float maxDrag = 1;
        float currentDrag = 2.5f;

        float maxAngularDrag = 2.5f;
        float currentAngularDrag = 1;

        float dragLerpTime = currentSpeed * 0.1f;

        float myDrag = Mathf.Lerp(currentDrag, maxDrag, dragLerpTime);
        float myAngularDrag = Mathf.Lerp(currentAngularDrag, maxAngularDrag, dragLerpTime);

        rigidbody2D.drag = myDrag;
        rigidbody2D.angularDrag = myAngularDrag;
    }
}
