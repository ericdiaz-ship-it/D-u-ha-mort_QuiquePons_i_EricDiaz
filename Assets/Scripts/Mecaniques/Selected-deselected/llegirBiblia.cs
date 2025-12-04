using UnityEngine;
using TMPro;

public class llegirBiblia : MonoBehaviour
{
    public GameObject panel;
    public TMP_Text textBox;

    private bool isActive = false;

    private readonly string[] titles =
    {
        "JOAN XVII : 1–5",
        "SALM XXIII : 1–4",
        "ROMANS VIII : 38–39",
        "GÈNESI I : 1–3"
    };

    private readonly string[] passages =
    {
        @"Jesús va dir aquestes coses i, alçant els ulls al cel, digué:
Pare, ha arribat l’hora. Glorifica el teu Fill, perquè el teu Fill et glorifiqui a tu;
ja que li has donat poder sobre tota carn, perquè doni vida eterna a tots els qui li has donat.
I la vida eterna és aquesta: que et coneguin a tu, l’únic Déu veritable,
i a Jesucrist, a qui tu has enviat.
Jo t’he glorificat a la terra i he dut a terme l’obra que m’has encomanat.
Ara, doncs, Pare, glorifica’m al teu costat amb aquella glòria que tenia amb tu
abans que el món existís.",

        @"El Senyor és el meu pastor, no em manca res.
Em fa descansar en prats d’herba tendre i em mena cap a aigües tranquil·les.
Restaura la meva ànima i em guia per camins de justícia, per amor del seu nom.
Encara que passi per una vall tenebrosa, no tindré por de cap mal,
perquè tu estàs amb mi; el teu bastó i el teu gaiato em reconforten.",

        @"Estic convençut que ni la mort ni la vida,
ni els àngels ni els principats, ni el present ni el futur,
ni les potències, ni l’altura ni la profunditat,
ni cap altra criatura no ens podrà separar de l’amor de Déu,
que hi ha en Crist Jesús, Senyor nostre.",

        @"Al principi, Déu va crear el cel i la terra.
La terra era caòtica i buida, la foscor cobria l’abisme,
i l’Esperit de Déu planava sobre les aigües.
I Déu va dir: «Que existeixi la llum», i la llum va existir."
    };

    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.Return))
        {
            TancarPanel();
        }
    }

    public void Interactuar() // Per si també vols fer-lo servir directament
    {
        ObrirPassatge(0);
    }

    public void ObrirPassatge(int index)
    {
        if (index < 0 || index >= passages.Length) return;

        if (panel != null)
            panel.SetActive(true);

        if (textBox != null)
            textBox.text = $"<b>{titles[index]}</b>\n\n{passages[index]}";

        isActive = true;
    }

    private void TancarPanel()
    {
        if (panel != null)
            panel.SetActive(false);

        isActive = false;
    }
}
