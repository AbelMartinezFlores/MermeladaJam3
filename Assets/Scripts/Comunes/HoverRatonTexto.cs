using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class HoverRatonTexto : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{

    [SerializeField] private Color normal;
    [SerializeField] private Color hover;
    [SerializeField] private Text texto;

    public void OnPointerClick(PointerEventData eventData)
    {
        texto.color = normal;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        texto.color = hover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        texto.color = normal;
    }
}
