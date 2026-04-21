using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 2f;
    public float moveDistance = 25f;

    public float visionRadius = 5f;

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

       Collider[] hits = Physics.OverlapSphere(transform.position, visionRadius);

        foreach (Collider hit in hits)
        {
            if (hit.GetComponent<Collider>().CompareTag("Player"))
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
        Gizmos.DrawWireSphere(transform.position, visionRadius);
       
    }
}