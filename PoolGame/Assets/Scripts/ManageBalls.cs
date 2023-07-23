using UnityEngine;

public class ManageBalls : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) // Delete Ball Collided.
    {
        Destroy(gameObject);
    }
}
