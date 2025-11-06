using UnityEngine;

public class CambiarColor : MonoBehaviour, IInteractuable
{
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public void Interactuar()
    {
        Color nuevoColor = new Color(Random.value, Random.value, Random.value);
        rend.material.color = nuevoColor;
        Debug.Log($"{gameObject.name} cambió de color a {nuevoColor}");
    }
}
