using UnityEngine;
using TMPro;

public class LlegirNotesMultiples : MonoBehaviour, IInteractuable
{
    [Header("UI del text")]
    public GameObject panel;       // Panel del Canvas que conté el text
    public TextMeshProUGUI textBox; // Text on es mostrarà títol + contingut

    private int currentNoteIndex = 0;
    private bool isActive = false;

    private readonly string[] titles = new string[]
    {
        "El Murmuri de les Campanes Buides (8 anys)",
        "El Llibre que Xiuxiueja sense Veu (9 anys)",
        "El Passadís que Respira (10 anys)",
        "El que Espera a les Cantonades (11 anys)",
        "Les Veus Sota el Sòl (12 anys)",
        "El Reflex que No Era Jo (13 anys)",
        "Les Germanes que Caminen Sense Soroll (14 anys)",
        "Quan el Llibre S'obre Sol (15 anys)",
        "El Silenci del Pare (16 anys)",
        "El Convent que es Tanca Sobre Nosaltres (17 anys)",
        "La Paraula Prohibida (18 anys)",
        "El Final que No Em Pertany (18 anys, última entrada)"
    };

    private readonly string[] notes = new string[]
    {
        @"Avui m'he despertat perquè les campanes sonaven estrany, com si algú hagués ficat dins un animalet que ratllava amb les ungles per sortir. No sé si les campanes poden tenir dins alguna cosa viva, però em va fer una mica de por pensar-hi. La Germana Pilar em va dir que són idees de nena, que les campanes sempre han sonat igual, i que potser és el vent que es cola on no toca.
La meva germana i jo netegem els bancs. Ella sempre neteja més ràpid que jo. Quan passo la mà per la fusta, sembla que tingués fred, com si la fusta no estigués del tot viva.
El Pare va caminar pel passadís i ni ens va mirar. Les germanes es van quedar molt quietes, com estatuetes de guix, mentre ell passava. La meva germana em va prémer la mà fins que em va fer mal. No sé per què. Crec que aquí hi ha coses que només entenen els grans i que mai no ens expliquen.",

        @"A la biblioteca antiga, on gairebé no entra llum, vaig trobar un llibre sense lletres a la tapa. Estava amagat darrere d'altres llibres grossos, com un nen tímid que no vol que el trobin. Quan el vaig obrir, em va semblar escoltar un xiuxiueig, però no venia de fora. Venia de dins meu, com si el llibre hagués despertat alguna cosa.
Les pàgines fan olor d'humitat, de coses que han estat molt temps adormides. De vegades crec que les lletres canvien una mica quan no les miro directament.
La Germana Inés va dir que aquests llibres “porten pensaments torçuts”, però no em va explicar què és un pensament torçat. Jo només vaig sentir curiositat.
L'he amagat sota el llit. La meva germana no ho sap. O això crec.",

        @"Avui el convent estava tan silenciós que semblava que algú hagués apagat els sons. Quan tornava del pati, vaig tenir la impressió que el passadís respirava, com si les parets es movessin una mica cap fora i després cap a dins, molt lent, molt profund.
No sé si va ser un somni despert o si el convent realment està viu.
Li vaig explicar a la meva germana. Ella em va abraçar fort i va dir que era la meva imaginació… però ho va dir mirant cap a un altre costat, amb els llavis blancs de tant prémer-los. Crec que també té por, però no vol admetre-ho.
Jo tampoc no ho admetria si ella no existís. Però estem juntes. Això ho fa menys terrible.",

        @"Hi ha alguna cosa a les cantonades. Ho sé. Avui vaig anar a buscar aigua i just abans de girar un passadís llarg, vaig veure una ombra quieta, com si m'estigués esperant. No es va moure ni va fer res. Només hi era, negra i molt prima.
Quan vaig passar la cantonada, no hi havia res. Però el meu cor bategava tan fort que vaig pensar que se sentiria per tot el convent.
Potser els ulls veuen coses abans que el cap. O potser les coses s'amaguen només quan les vols mirar de front.",

        @"Anit vaig escoltar el Pare a la seva habitació. Era com un res, però les paraules semblaven enfonsar-se al terra, com si les pronunciés dins d'un pou molt profund. No eren paraules que entengués, ni tan sols semblaven humanes.
Aquest matí, la Germana Lucía tenia els ulls inflats. Va dir que havia dormit malament, però quan ho va dir va mirar cap a la porta del Pare i es va tocar les mans, com si li dolguessin tot i que no es veiessin ferides.
Les monges avui parlaven més baix que mai. Fins i tot els passos semblaven més suaus, com si temessin despertar alguna cosa que dorm sota els pisos.",

        @"Mentre rentava els plats, vaig mirar l'aigua quieta al test. El meu reflex hi era, però no es movia igual que jo. Tenia els ulls una mica més oberts, com si m'estigués vigilant. I la boca entreoberta, com si volgués avisar-me de alguna cosa, però no pogués.
Vaig sacsejar el cap i aleshores sí que va tornar a moure's igual que jo, com un mirall normal.
La meva germana em va trobar tremolant i va dir que tinc el cap ple de fantasies per culpa del llibre. Però quan va agafar el test per buidar-lo, va evitar mirar-se a l'aigua. Això ho vaig veure claríssim.
Crec que ella també comença a veure coses, però no vol dir-m'ho.",

        @"Últimament les germanes es mouen com si flotessin. No sento els seus passos. Només apareixen al meu costat sense que m'adoni. Abans parlaven mentre feien les tasques, però ara les seves veus semblen amagar-se.
Avui una germana va deixar caure un got i el Pare la va mirar. Només això: la va mirar. Però ella va prémer els llavis i es va posar molt pàl·lida, com si un fred gran hagués passat per sobre d'ella.
Em pregunto si aquí totes aprenem, poc a poc, a no existir massa.",

        @"El llibre va aparèixer obert al meu llit, tot i que jo l'havia deixat tancat i sota la manta. Estava en una pàgina que no recordo haver llegit. Tenia una frase subratllada amb llapis, un llapis que jo mai no havia fet servir:
“Allò que s'amaga no vol seguir amagat.”
Vaig sentir un escalfor tan fort que vaig haver de seure.
La meva germana diu que potser una corrent d'aire el va obrir. Però aquí mai hi ha corrents d'aire. Les finestres gairebé no deixen passar el sol.
Crec que el llibre sap que volem deixar de llegir-lo. I no li agrada.",

        @"El Pare ens mira com si fóssim fetes d'un material que no li agrada tocar. Però tot i així, quan passa entre nosaltres, sento que compta alguna cosa, com si portés un registre secret: un, dos, tres, quatre…
Anit vaig escoltar un cop sec a la seva habitació. Després, un soroll que semblava un solloç breu. Quan vam baixar a sopar, les germanes estaven tan silencioses que semblava que haguessin oblidat com s'usen les paraules.
La meva germana es va acostar a mi i em va xiuxiuejar: “Aquí passen coses.”
Jo només vaig poder assentir.",

        @"Les ombres ja no s'amaguen. Caminen amb mi una estona i després desapareixen. De vegades les veig darrere de les columnes, però quan m'hi acosto ja no hi són.
La meva germana vol que marxem. Diu que fora hi ha aire que no apreta el pit, que fora la gent respira sense por. Jo vull creure-ho, però sento que si m'allunyo del convent, alguna cosa em seguirà.
El llibre pesa més que abans. I quan l'obro, les lletres semblen voler escapar-se de la pàgina.",

        @"El llibre té una pàgina nova. Abans no hi era. Ho juro. Està completament blanca excepte per una frase escrita amb tinta molt fina:
“No creueu la porta.”
No sé si es refereix a la porta gran del convent o a una altra porta que encara no conec… però sento que no és un avís. És una ordre.
Aquesta nit, mentre dormia, vaig escoltar el meu nom al passadís. Era una veu petita, com d'un nen amagat darrere d'un moble. Quan vaig sortir, no hi havia ningú, però l'aire estava fred com si hagués passat alguna cosa corrent.
La meva germana prepara una bossa. Jo també. Tot i que les meves mans tremolen quan toco la roba.",

        @"No sé si va ser un somni. Crec que no.
Algú es va asseure al meu llit anit. No vaig sentir passos. Només vaig notar el matalàs enfonsar-se als peus i després una ombra que es va inclinar cap a mi.
No va parlar amb veu. Va parlar dins del meu cap, molt lentament, com si hagués viscut anys allà, esperant el moment.
Em va dir que si me'n vaig, el sofriment creixerà. Que jo sóc l'arrel que sosté alguna cosa fosca, alguna cosa que no pertany del tot a aquest món.
Em va dir que havia d'arrencar-me per a que tot acabi.
La paraula “arrencar-me” em va fer plorar. No pel dolor, sinó perquè l'ombra ho deia com si fos un acte d'amor cap a les altres.
Tancaré el llibre. Intentaré dormir. Demà marxarem. Tot i que sento un pes al pit, com si el convent m'agafés per dins i no volgués deixar-me anar.
Però jo també tinc una germana. I sé que ella em necessita viva."
    };

    void Update()
    {
        if (!isActive) return;

        // Avançar a la següent nota amb Enter
        if (Input.GetKeyDown(KeyCode.Return))
        {
            currentNoteIndex++;
            if (currentNoteIndex >= notes.Length)
            {
                TancarPanel();
            }
            else
            {
                MostrarNota(currentNoteIndex);
            }
        }
        // Tancar amb Espai
        else if (Input.GetKeyDown(KeyCode.Space))
        {
            TancarPanel();
        }
    }

    // Cridar quan s'interactua
    public void Interactuar()
    {
        currentNoteIndex = 0;
        ObrirPanel(currentNoteIndex);
    }

    private void ObrirPanel(int index)
    {
        if (panel != null)
            panel.SetActive(true);

        MostrarNota(index);
        isActive = true;
    }

    private void MostrarNota(int index)
    {
        if (textBox != null)
            textBox.text = $"<b>{titles[index]}</b>\n\n{notes[index]}";
    }

    private void TancarPanel()
    {
        if (panel != null)
            panel.SetActive(false);

        isActive = false;
        currentNoteIndex = 0;
    }
}
