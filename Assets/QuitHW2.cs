using UnityEngine;
using UnityEngine.InputSystem;

public class QuitHW2 : MonoBehaviour
{
    public InputActionReference quitButtonA;
    public InputActionReference quitButtonB;

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

    }

}
