using UnityEngine;

public class Collectable : MonoBehaviour
{
    public virtual void Collect()
    {
        Debug.Log("Collected Item");
    }

    void OnTriggerEnter(Collider collision)
   {
       if (collision.CompareTag("Player"))

    {
        // Calls collect function
        Collect();

        //Destroy collectable
        Destroy(gameObject);
    }
   

   }

}

