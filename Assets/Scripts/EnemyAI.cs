using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 25f;

    public float visionDistance = 5f;

    public int direction = 1;

    private float moved;
  

    void Start()
    {
        StartCoroutine(Patrol());
    }

    // COROUTINE 
    public IEnumerator Patrol()
    {
        while (true)
        {
            moved = 0f;

            // Move in one direction until distance is reached
            while (moved < moveDistance)
            {
                transform.Translate(Vector3.right * direction * speed * Time.deltaTime);
                moved += speed * Time.deltaTime;

                yield return null;
            }

            // Wait before switching direction
            yield return new WaitForSeconds(2f);

            // Flip direction
            direction *= -1;
        }
    }

    void Update()
    {

        Vector3 visionDirection = Vector3.right * direction;
        
        // RAYCAST 
        RaycastHit hit;

        if (Physics.Raycast(
            transform.position, visionDirection,
            out hit,
            visionDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Debug.Log("Player detected");

                GameManager.Instance.GameOver();
            }
        }
    }

    void OnDrawGizmos()
    {
        // Patrol range
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, moveDistance);

        // Vision ray
        Gizmos.color = Color.red;
        Vector3 visionDirection = Vector3.right * direction;
        
        
       Gizmos.DrawLine(
            transform.position,
            transform.position + visionDirection * visionDistance);
            
       
    }
}