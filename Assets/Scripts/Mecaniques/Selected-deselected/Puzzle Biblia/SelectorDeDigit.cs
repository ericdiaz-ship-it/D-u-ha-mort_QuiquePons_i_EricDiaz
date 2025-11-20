using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectorDeDigit : MonoBehaviour
{
    public TMP_Text textDigit;
    public ControlarContra gestor;

    public void Incrementar()
    {
        int valor = int.Parse(textDigit.text);
        valor = (valor + 1) % 10;
        textDigit.text = valor.ToString();

        gestor.RevisarCodi(); // Comprova automàticament
    }

    public void Decrementar()
    {
        int valor = int.Parse(textDigit.text);
        valor = (valor - 1 + 10) % 10;
        textDigit.text = valor.ToString();

        gestor.RevisarCodi(); // Comprova automàticament
    }
}
