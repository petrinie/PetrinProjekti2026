using UnityEngine;
using UnityEngine.InputSystem;

public class LightSwitch : MonoBehaviour
{
    public Light Valo;
    private int ValoColor = 0;

    public Material RED;
    public Material BLUE;
    public Material YELLOW;
    public Material WHITE;

    public InputActionReference action;


    void Start()
    {

        Valo = GetComponent<Light>();
        action.action.Enable();
        action.action.performed += (ctx) =>
        {
            ValoColor++;
            if (ValoColor > 4) ValoColor = 0;
            if (ValoColor == 1)
            {
                Valo.color = Color.red;
                transform.parent.gameObject.GetComponent<Renderer>().material = RED;
            }
            else if (ValoColor == 2)
            {
                Valo.color = Color.blue;
                transform.parent.gameObject.GetComponent<Renderer>().material = BLUE;
            }
            else if (ValoColor == 3)
            {
                Valo.color = Color.yellow;
                transform.parent.gameObject.GetComponent<Renderer>().material = YELLOW;
            }
            else if (ValoColor == 4)
            {
                Valo.color = Color.white;
                transform.parent.gameObject.GetComponent<Renderer>().material = WHITE;
            }
        };

    }
}
