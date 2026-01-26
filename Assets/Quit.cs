using UnityEngine;
using UnityEngine.InputSystem;

public class Quit : MonoBehaviour
{

    public InputActionReference quitButtonA;
    public InputActionReference quitButtonB;
    public InputActionReference viewPoint;

    private int ViewPoint = 1;
    public Transform XR_Rig;
    public Transform ViewPoint1;
    public Transform ViewPoint2;
    public Transform ViewPoint3;

    void Start()
    {
        quitButtonA.action.Enable();
        quitButtonA.action.performed += (ctx) =>
        {
            #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
            #else
                Application.Quit();
            #endif
        };

        quitButtonB.action.Enable();
        quitButtonB.action.performed += (ctx) =>
        {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
                Application.Quit();
#endif
        };

        viewPoint.action.Enable();
        viewPoint.action.performed += (ctx) =>
        {
            ChangeViewPoint();
        };
    }

    void ChangeViewPoint()
    {
        if(ViewPoint == 1)
        {
            ViewPoint = 2;
            XR_Rig.position = ViewPoint2.position;
            XR_Rig.rotation = ViewPoint2.rotation;
        }
        else if (ViewPoint == 2)
        {
            ViewPoint = 3;
            XR_Rig.position = ViewPoint3.position;
            XR_Rig.rotation = ViewPoint3.rotation;
        }
        else if (ViewPoint == 3)
        {
            ViewPoint = 1;
            XR_Rig.position = ViewPoint1.position;
            XR_Rig.rotation = ViewPoint1.rotation;
        }
    }
}
