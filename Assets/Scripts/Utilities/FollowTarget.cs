using UnityEngine;

namespace Heal.Components
{
    public class FollowTarget : MonoBehaviour
    {
        [SerializeField] private Transform target;

        private void Update ()
        {
            if (target != null) transform.position = target.position;
        }
    }
}