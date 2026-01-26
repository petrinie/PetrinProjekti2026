using UnityEngine;

public class Planet : MonoBehaviour
{
    public float SpeedX = 10f;
    public float SpeedY = 10f;
    public float SpeedZ = 10f;

    private Vector3 RotateDelta;

    void Update()
    {
        transform.Rotate(SpeedX * Time.deltaTime, SpeedY * Time.deltaTime, SpeedZ * Time.deltaTime, Space.Self);
    }
}
