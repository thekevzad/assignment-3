using UnityEngine;

public class ChaseBehavior : MonoBehaviour
{
    public Transform target; // Assign the target object in the inspector
    public float chaseSpeed = 5f;

    void Update()
    {
        if (target != null) // Check if target is assigned
        {
            // Calculate direction towards the target
            Vector3 direction = (target.position - transform.position).normalized;

            // Move towards the target using MoveTowards
            transform.position = Vector3.MoveTowards(transform.position, target.position, chaseSpeed * Time.deltaTime);

            // Calculate the rotation to look at the target
            Quaternion targetRotation = Quaternion.LookRotation(direction);

            // Smoothly rotate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * chaseSpeed);
        }
    }
}
