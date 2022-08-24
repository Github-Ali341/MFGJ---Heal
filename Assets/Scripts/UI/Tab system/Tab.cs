using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

namespace Heal.UI.TabSystem
{
    public class Tab : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
    {
        [SerializeField] private TabsGroup group;
        [SerializeField] private Image image;

        private void Awake ()
        {
            image = GetComponent<Image>();
            group.Subscribe(this);
        }

        public void OnPointerClick (PointerEventData eventData) => group.OnTabSelected(this);
        public void OnPointerEnter (PointerEventData eventData) => group.OnTabEnter(this);
        public void OnPointerExit (PointerEventData eventData) => group.OnTabExit(this);

        public void SetBGColor (Color color)
        {
            image.color = color;
        }
    } 
}
