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
}
