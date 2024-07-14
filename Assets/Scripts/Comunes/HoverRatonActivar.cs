using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class HoverRatonActivar : MonoBehaviour
{

    private Image panel;
    private Color normal;
    private Color hover;

    private void Start()
    {
        panel = gameObject.GetComponent<Image>();

        normal = new Color(panel.color.r, panel.color.g, panel.color.b, 0);
        hover = new Color(panel.color.r, panel.color.g, panel.color.b, 255);

        panel.color = normal;
    }

    void OnMouseEnter()
    {
        panel.color = hover;
    }

    void OnMouseExit()
    {
        panel.color = normal;
        //hola
    }

}
