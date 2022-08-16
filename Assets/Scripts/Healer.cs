using UnityEngine;

namespace Heal.Components
{
    public class Healer : MonoBehaviour
    {
        [SerializeField] private float healAmount;

        public float GetHealAmount () => healAmount;

        public void OnHealerUsed ()
        {
            Destroy(gameObject);
        }
    } 
}
