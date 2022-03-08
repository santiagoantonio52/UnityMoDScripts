using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhaleMovementController : MonoBehaviour {

    [SerializeField]
    private float swingSpeed = 5f;
    [SerializeField]
    private float angularSwingSpeed = 15;
    [SerializeField]
    private float swingDepth;

    [SerializeField]
    [Space]
    private float minDistanceToChangeToNextWayPoint;
    
    [Space]
    private Vector3 targetPosition;
    private float currentDistanceToTargetPosition;

    [Space]
    public Transform[] wayPoints;
    private int currentWayPointIndex;

    [Space]
    private Animator animator;

    // Use this for initialization
    void Start () {

        targetPosition = wayPoints[currentWayPointIndex].position;
    }

    // Update is called once per frame
    public void Move ()
    {
        currentDistanceToTargetPosition = Vector3.Distance(transform.position, targetPosition);

        if(currentDistanceToTargetPosition <= minDistanceToChangeToNextWayPoint)
        {
            if (currentWayPointIndex + 1 < wayPoints.Length)
                currentWayPointIndex++;
            else
                currentWayPointIndex = 0;

            targetPosition = wayPoints[currentWayPointIndex].position;
        }

        transform.position = Vector3.MoveTowards(transform.position,  targetPosition, swingSpeed* Time.deltaTime);
        LookToTargetPosition();
    }

    public void LookToTargetPosition()
    {
        //Gets the Direction to target
        Vector3 positionToLook = transform.position - targetPosition;
        Quaternion targetRotation = Quaternion.LookRotation(positionToLook);//And create a rotation to transform rotation

        //Apply the rotation to transform
        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, angularSwingSpeed * Time.deltaTime);
    }

    void OnDrawGizmos()
    {
        for (int i = 0; i < wayPoints.Length; i++)
        {
            if(wayPoints[i] != null)
            {
                Gizmos.DrawSphere(wayPoints[i].position, 1);

                if (i + 1 < wayPoints.Length && wayPoints[i + 1] != null)
                    Debug.DrawLine(wayPoints[i].position, wayPoints[i + 1].position, Color.red);
                else
                    Debug.DrawLine(wayPoints[i].position, wayPoints[i].position, Color.red);
            }
        }
    }
}
