using UnityEngine;

public class FollowTarget : MonoBehaviour
{
    [SerializeField] private Transform target;

    private void Update ()
    {
        if (target != null) transform.position = target.position;
    }
}
