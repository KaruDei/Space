using UnityEngine;

public class Ballon : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if (other.CompareTag("Player") && other.TryGetComponent<Player>(out var player))
        {
            player.GetQxygenAndFuel();
            Destroy(gameObject);
        }
    }
}