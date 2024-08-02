using UnityEngine;

public class BlackHole : MonoBehaviour
{
    [SerializeField] private Transform _destination;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && other.TryGetComponent<PlayerMovement>(out var player))
        {
            Teleport(player.transform, _destination.position, _destination.rotation);
            player.RemoveVelocity();
        }
    }

    private void Teleport(Transform player, Vector3 position, Quaternion rotation)
    {
        player.position = position;
        player.rotation = rotation;

        Physics.SyncTransforms();

    }
}