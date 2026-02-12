using UnityEngine;

public class SuurennusLasiSkripti : MonoBehaviour
{

    public Transform SuurennuslasiLinssi;
    public Transform PelaajaKamera;


    // Update is called once per frame
    void Update()
    {
        transform.LookAt(SuurennuslasiLinssi);
        transform.position = PelaajaKamera.position;
    }
}
