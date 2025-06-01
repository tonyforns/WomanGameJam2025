using UnityEngine;

public class CharacterMovment : MonoBehaviour
{
    private Vector3 targetPosition;

    private float speed = 5f;

    private bool isMoving = false;

    public void Move()
    {
        isMoving = true;
    }
    private void Start()
    {
        Move();
    }

    void Update()
    {
        if (isMoving && targetPosition != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (Vector3.Distance(transform.position, targetPosition) < 0.1f)
            {
                isMoving = false;
                transform.position = targetPosition;
            }

        }
    }

}