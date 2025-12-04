using UnityEngine;
using TMPro;

public class LlegirNotesMultiples : MonoBehaviour
{
    [Header("UI del text")]
    public GameObject panell;       // Panell del Canvas que conté el text
    public TMP_Text caixaText;      // Text on es mostrarà títol + contingut

    [Header("Configuració")]
    [Tooltip("Índex de la nota a mostrar quan s'usa Interactuar() sense paràmetre.")]
    public int indexNotaActual = 0;

    private bool actiu = false;

    // Títols de les notes
    private readonly string[] titols = new string[]
    {
        "El Murmuri de les Campanes Buides (8 anys)",
        "El Llibre que Xiuxiueja sense Veu (9 anys)",
        "El Passadís que Respira (10 anys)",
        "Allò que Espera a les Cantonades (11 anys)",
        "Les Veus sota el Terra (12 anys)",
        "El Reflex que No Era Jo (13 anys)",
        "Les Germanes que Caminen Sense Soroll (14 anys)",
        "Quan el Llibre s’obre Sol (15 anys)",
        "El Silenci del Pare (16 anys)",
        "El Convent que es Tanca sobre Nosaltres (17 anys)",
        "La Paraula Prohibida (18 anys)",
        "El Final que No em Pertany (18 anys, última entrada)"
    };

    // Contingut de les notes
    private readonly string[] notes = new string[]
    {
        @"Avui m’he despertat perquè les campanes sonaven estrany, com si algú hi hagués posat dins un animaló que rascava amb les ungles per sortir. No sé si les campanes poden tenir res viu a dins, però em va fer una mica de por pensar-ho. La Germana Pilar em va dir que són idees de nena, que les campanes sempre han sonat igual, i que potser és el vent que entra on no toca.
La meva germana i jo vam netejar els bancs. Ella sempre neteja més ràpid que jo. Quan passo la mà per la fusta, sembla que tingui fred, com si la fusta no estigués del tot viva.
El Pare va caminar pel passadís i ni tan sols ens va mirar. Les germanes es van quedar molt quietes, com estàtues de guix, mentre passava. La meva germana em va prémer la mà fins que em va fer mal. No sé per què. Crec que aquí hi ha coses que només entenen els grans i que mai no ens expliquen.",

        @"A la biblioteca vella, on gairebé no entra la llum, vaig trobar un llibre sense lletres a la tapa. Estava amagat darrere d’altres llibres gruixuts, com un nen tímid que no vol que el trobin. Quan el vaig obrir, em va semblar sentir un xiuxiueig, però no venia de fora. Venia de dins meu, com si el llibre hagués despertat alguna cosa.
Les pàgines fan olor d’humitat, de coses que han dormit durant molt de temps. A vegades crec que les lletres canvien una miqueta quan no les miro directament.
La Germana Inés va dir que aquests llibres “porten pensaments torts”, però no em va explicar què és un pensament tort. Jo només vaig sentir curiositat.
El vaig amagar sota el meu llit. La meva germana no ho sap. O això crec.",

        @"Avui el convent estava tan silenciós que semblava que algú hagués apagat els sons. Quan tornava del pati, vaig tenir la impressió que el passadís respirava, com si les parets es moguessin una mica cap a fora i després cap a dins, molt lent, molt profund.
No sé si era un somni despert o si el convent realment és viu.
Li ho vaig explicar a la meva germana. Ella em va abraçar fort i va dir que era la meva imaginació… però ho va dir mirant cap a una altra banda, amb els llavis ben blancs de tan apretats. Crec que ella també té por, però no ho vol admetre.
Jo tampoc ho admetria si no existís. Però estem juntes. I això ho fa menys terrible.",

        @"Hi ha alguna cosa a les cantonades. Ho sé. Avui vaig anar a buscar aigua i just abans de girar per un passadís llarg, vaig veure una ombra quieta, com si m’estigués esperant. No es va moure ni va fer res. Només era allà, negra i molt prima.
Quan vaig girar la cantonada, no hi havia res. Però el meu cor bategava tan fort que vaig pensar que se sentiria per tot el convent.
Potser els ulls veuen coses abans que el cap. O potser les coses només s’amaguen quan les vols mirar de cara.",

        @"Ahir a la nit vaig sentir el Pare a la seva habitació. Era com una pregària, però les paraules semblaven enfonsar-se al terra, com si les pronunciés dintre d’un pou molt profund. No eren paraules que jo entengués, ni tan sols semblaven humanes.
Aquest matí, la Germana Llúcia tenia els ulls inflats. Va dir que havia dormit malament, però mentre ho deia va mirar cap a la porta del Pare i es va tocar les mans, com si li fessin mal tot i que no es veien ferides.
Les monges avui parlaven més fluix que mai. Fins i tot les passes semblaven més suaus, com si tinguessin por de despertar alguna cosa que dorm sota els terres.",

        @"Mentre rentava els plats, vaig mirar l’aigua quieta del ribell. El meu reflex era allà, però no es movia igual que jo. Tenia els ulls una mica més oberts, com si m’estigués vigilant. I la boca entreoberta, com si em volgués avisar d’alguna cosa, però no pogués.
Vaig sacsejar el cap i llavors sí que es va tornar a moure igual que jo, com un mirall normal.
La meva germana em va trobar tremolant i va dir que tinc el cap ple de fantasies per culpa del llibre. Però quan ella va agafar el ribell per buidar-lo, va evitar mirar-se a l’aigua. Això ho vaig veure claríssim.
Crec que ella també comença a veure coses, però no m’ho vol dir.",

        @"Últimament les germanes es mouen com si flotessin. No sento les seves passes. Només apareixen al meu costat sense que me n’adoni. Abans parlaven mentre feien les tasques, però ara les seves veus semblen amagar-se.
Avui una germana ha deixat caure un got i el Pare l’ha mirat. Només això: l’ha mirat. Però ella s’ha mossegat els llavis i s’ha tornat molt pàl·lida, com si li hagués passat per damunt un fred enorme.
Em pregunto si aquí totes aprenem, a poc a poc, a no existir massa.",

        @"El llibre va aparèixer obert sobre el meu llit, tot i que jo l’havia deixat tancat i sota la manta. Estava en una pàgina que no recordo haver llegit. Hi havia una frase subratllada amb llapis, un llapis que jo no he fet servir mai:
«Allò que s’amaga no desitja continuar amagat.»
Vaig sentir un calfred tan fort que em vaig haver d’asseure.
La meva germana diu que potser un corrent d’aire el va obrir. Però aquí mai hi ha corrents d’aire. Les finestres gairebé no deixen entrar el sol.
Crec que el llibre sap que volem deixar de llegir-lo. I no li agrada.",

        @"El Pare ens mira com si estiguéssim fetes d’un material que no li agrada tocar. Però tot i així, quan passa entre nosaltres, sento que compta alguna cosa, com si portés un registre secret: un, dos, tres, quatre…
Ahir a la nit vaig sentir un cop sec a la seva habitació. Després, un soroll que semblava un sanglot breu. Quan vam baixar a sopar, les germanes estaven tan silencioses que semblava que haguessin oblidat com s’usen les paraules.
La meva germana es va apropar a mi i em va xiuxiuejar: «Aquí passen coses».
Jo només vaig poder assentir.",

        @"Les ombres ja no s’amaguen. Caminen amb mi una estona i després desapareixen. A vegades les veig darrere de les columnes, però quan m’hi apropo ja no hi són.
La meva germana vol que marxem. Diu que fora hi ha un aire que no oprimeix el pit, que fora la gent respira sense por. Jo vull creure-ho, però sento que si m’allunyo del convent, alguna cosa em seguirà.
El llibre pesa més que abans. I quan l’obro, les lletres semblen voler escapar de la pàgina.",

        @"El llibre té una pàgina nova. Abans no hi era. Ho juro. És completament blanca excepte per una frase escrita amb tinta molt fina:
«No creueu la porta.»
No sé si es refereix a la porta gran del convent o a una altra porta que encara no conec… però sento que no és un advertiment. És una ordre.
Aquesta nit, mentre dormia, he sentit el meu nom al passadís. Era una veu petita, com la d’un infant amagat darrere d’un moble. Quan vaig sortir, no hi havia ningú, però l’aire estava fred com si alguna cosa hagués passat corrents.
La meva germana prepara una bossa. Jo també. Tot i que em tremolen les mans quan toco la roba.",

        @"No sé si va ser un somni. Crec que no.
Algú es va asseure al meu llit aquesta nit. No vaig sentir passes. Només vaig sentir el matalàs enfonsar-se als peus i després una ombra que s’inclinava cap a mi.
No em va parlar amb veu. Em va parlar dins del cap, molt a poc a poc, com si fes anys que hi visqués, esperant el moment.
Em va dir que si me’n vaig, el sofriment creixerà. Que jo soc l’arrel que sosté alguna cosa fosca, alguna cosa que no pertany del tot a aquest món.
Em va dir que m’havia d’arrencar perquè tot s’acabés.
La paraula “arrencar-me” em va fer plorar. No pel dolor, sinó perquè l’ombra ho deia com si fos un acte d’amor cap a les altres.
Tancaré el llibre. Intentaré dormir. Demà marxarem. Tot i que sento un pes al pit, com si el convent m’agafés per dins i no em volgués deixar anar.
Però jo també tinc una germana. I sé que ella em necessita viva."
    };

    void Update()
    {
        if (actiu && Input.GetKeyDown(KeyCode.Return))
        {
            TancarPanell();
        }
    }

    public void Interactuar()
    {
        InteractuarNota(indexNotaActual);
    }

    public void InteractuarNota(int index)
    {
        if (index < 0 || index >= notes.Length) return;
        ObrirPanell(index);
    }

    private void ObrirPanell(int index)
    {
        if (panell != null)
            panell.SetActive(true);

        if (caixaText != null)
        {
            // Combina títol + salt de línia + contingut
            caixaText.text = $"<b>{titols[index]}</b>\n\n{notes[index]}";
        }

        actiu = true;
    }

    private void TancarPanell()
    {
        if (panell != null)
            panell.SetActive(false);

        actiu = false;
    }
}
