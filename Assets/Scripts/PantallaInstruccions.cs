using UnityEngine;

public class PantallaInstruccions : MonoBehaviour
{
    public GameObject panelInstruccions;
    public void obrir()
    {
        panelInstruccions.SetActive(true);
    }
    public void tancar()
    {
        panelInstruccions.SetActive(false);
    }
    public void tancarContra()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
         panelInstruccions.SetActive(false);
    }
}
