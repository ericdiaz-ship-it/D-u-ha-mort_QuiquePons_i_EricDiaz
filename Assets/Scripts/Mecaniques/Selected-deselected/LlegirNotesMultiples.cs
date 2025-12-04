using UnityEngine;
using TMPro;

public class LlegirNotasMultiples : MonoBehaviour
{
    [Header("UI del texto")]
    public GameObject panel;       // Panel del Canvas que contiene el texto
    public TMP_Text textBox;       // Texto donde se mostrará título + contenido

    [Header("Ajustes")]
    [Tooltip("Índice de la nota a mostrar al usar Interactuar() sin parámetro.")]
    public int currentNoteIndex = 0;

    private bool isActive = false;

    // Títulos de las notas
    private readonly string[] titles = new string[]
    {
        "El Murmullo de las Campanas Huecas (8 años)",
        "El Libro que Susurra sin Voz (9 años)",
        "El Pasillo que Respira (10 años)",
        "Lo Que Espera en las Esquinas (11 años)",
        "Las Voces Debajo del Suelo (12 años)",
        "El Reflejo que No Era Yo (13 años)",
        "Las Hermanas que Caminan Sin Ruido (14 años)",
        "Cuando el Libro Se Abre Solo (15 años)",
        "El Silencio del Padre (16 años)",
        "El Convento que Se Cierra Sobre Nosotras (17 años)",
        "La Palabra Prohibida (18 años)",
        "El Final que No Me Pertenece (18 años, última entrada)"
    };

    // Contenido de las notas
    private readonly string[] notes = new string[]
    {
        @"Hoy desperté porque las campanas sonaban raro, como si alguien hubiese metido dentro un animalito que raspaba con las uñas para salir. No sé si las campanas pueden tener dentro algo vivo, pero me dio un poco de miedo pensar en ello. La Hermana Pilar me dijo que son ideas de niña, que las campanas siempre han sonado igual, y que quizá es el viento que se mete donde no toca.
Mi hermana y yo limpiamos los bancos. Ella siempre limpia más rápido que yo. Cuando paso la mano por la madera, parece que tuviera frío, como si la madera no estuviera viva del todo.
El Padre caminó por el pasillo y ni nos miró. Las hermanas se quedaron muy quietas, como estatuas de yeso, mientras él pasaba. Mi hermana me apretó la mano hasta que me dolió. No sé por qué. Creo que aquí hay cosas que solo entienden los mayores y que nunca nos explican.",

        @"En la biblioteca vieja, donde casi no entra luz, encontré un libro sin letras en la tapa. Estaba escondido detrás de otros libros gordos, como un niño tímido que no quiere que lo encuentren. Cuando lo abrí, me pareció escuchar un susurro, pero no venía de afuera. Venía de dentro de mí, como si el libro hubiera despertado algo.
Las páginas huelen a humedad, a cosas que estuvieron mucho tiempo dormidas. A veces creo que las letras cambian un poquito cuando no las estoy mirando directamente.
La Hermana Inés dijo que estos libros “traen pensamientos torcidos”, pero no me explicó qué es un pensamiento torcido. Yo solo sentí curiosidad.
Lo escondí bajo mi cama. Mi hermana no lo sabe. O eso creo.",

        @"Hoy el convento estaba tan silencioso que parecía que alguien hubiera apagado los sonidos. Cuando regresaba del patio, tuve la impresión de que el pasillo respiraba, como si las paredes se movieran un poquito hacia afuera y luego hacia adentro, muy lento, muy profundo.
No sé si fue un sueño despierta o si el convento realmente está vivo.
Le conté a mi hermana. Ella me abrazó fuerte y dijo que era mi imaginación… pero lo dijo mirando hacia otro lado, con los labios blancos de tanto apretarlos. Creo que también tiene miedo, pero no quiere admitirlo.
Yo tampoco lo admitiría si ella no existiera. Pero estamos juntas. Eso lo hace menos terrible.",

        @"Hay algo en las esquinas. Lo sé. Hoy fui a buscar agua y justo antes de doblar un pasillo largo, vi una sombra quieta, como si estuviera esperándome. No se movió ni hizo nada. Solo estaba allí, negra y muy delgada.
Cuando pasé la esquina, no había nada. Pero mi corazón latía tan fuerte que pensé que iba a escucharse por todo el convento.
Tal vez los ojos ven cosas antes que la cabeza. O tal vez las cosas se esconden solo cuando se las quiere mirar de frente.",

        @"Anoche escuché al Padre en su habitación. Era como un rezo, pero las palabras parecían hundirse en el suelo, como si las pronunciara dentro de un pozo muy profundo. No eran palabras que yo entendiera, ni siquiera parecían humanas.
Esta mañana, la Hermana Lucía tenía los ojos hinchados. Dijo que había dormido mal, pero cuando lo dijo miró hacia la puerta del Padre y se tocó las manos, como si le dolieran aunque no se vieran heridas.
Las monjas hoy hablaban más bajito que nunca. Incluso los pasos parecían más suaves, como si temieran despertar algo que duerme bajo los pisos.",

        @"Mientras lavaba los platos, miré el agua quieta en el barreño. Mi reflejo estaba allí, pero no se movía igual que yo. Tenía los ojos un poco más abiertos, como si estuviera vigilándome. Y la boca entreabierta, como si quisiera avisarme de algo, pero no pudiera.
Sacudí la cabeza y entonces sí volvió a moverse igual que yo, como un espejo normal.
Mi hermana me encontró temblando y dijo que tengo la cabeza llena de fantasías por culpa del libro. Pero cuando tomó el barreño para vaciarlo, evitó mirarse en el agua. Eso lo vi clarísimo.
Creo que ella también empieza a ver cosas, pero no quiere decírmelo.",

        @"Últimamente las hermanas se mueven como si flotaran. No oigo sus pasos. Solo aparecen a mi lado sin que me dé cuenta. Antes hablaban mientras hacían las tareas, pero ahora sus voces parecen esconderse.
Hoy una hermana dejó caer un vaso y el Padre la miró. Solo eso: la miró. Pero ella apretó los labios y se puso muy pálida, como si un frío grande hubiera pasado por encima de ella.
Me pregunto si aquí todas aprendemos, poco a poco, a no existir demasiado.",

        @"El libro apareció abierto en mi cama, aunque yo lo había dejado cerrado y bajo la manta. Estaba en una página que no recuerdo haber leído. Tenía una frase subrayada con lápiz, un lápiz que yo nunca usé:
“Lo que se esconde no desea seguir escondido.”
Sentí un escalofrío tan fuerte que tuve que sentarme.
Mi hermana dice que quizá una corriente de aire lo abrió. Pero aquí nunca hay corrientes de aire. Las ventanas apenas dejan pasar el sol.
Creo que el libro sabe que queremos dejar de leerlo. Y no le gusta.",

        @"El Padre nos mira como si estuviéramos hechas de un material que no le gusta tocar. Pero aun así, cuando pasa entre nosotras, siento que cuenta algo, como si llevara un registro secreto: un, dos, tres, cuatro…
Anoche escuché un golpe seco en su habitación. Después, un ruido que parecía un sollozo breve. Cuando bajamos a cenar, las hermanas estaban tan silenciosas que parecía que hubieran olvidado cómo se usan las palabras.
Mi hermana se acercó a mí y me susurró: “Aquí pasan cosas.”
Yo solo pude asentir.",

        @"Las sombras ya no se esconden. Caminan conmigo un rato y luego desaparecen. A veces las veo detrás de las columnas, pero cuando me acerco ya no están.
Mi hermana quiere que nos vayamos. Dice que fuera hay aire que no aprieta el pecho, que fuera la gente respira sin miedo. Yo quiero creerlo, pero siento que si me alejo del convento, algo me seguirá.
El libro pesa más que antes. Y cuando lo abro, las letras parecen querer escaparse de la página.",

        @"El libro tiene una página nueva. Antes no estaba. Juro que no. Está completamente blanca excepto por una frase escrita en tinta muy fina:
“No crucéis la puerta.”
No sé si se refiere a la puerta grande del convento o a otra puerta que aún no conozco… pero siento que no es una advertencia. Es una orden.
Esta noche, mientras dormía, escuché mi nombre en el pasillo. Era una voz pequeña, como de un niño escondido detrás de un mueble. Cuando salí, no había nadie, pero el aire estaba frío como si hubiera pasado algo corriendo.
Mi hermana prepara una bolsa. Yo también. Aunque mis manos tiemblan cuando toco la ropa.",

        @"No sé si fue un sueño. Creo que no.
Alguien se sentó en mi cama anoche. No escuché pasos. Solo sentí el colchón hundirse a los pies y luego una sombra que se inclinó hacia mí.
No habló con voz. Habló dentro de mi cabeza, muy despacio, como si llevara años viviendo allí, esperando el momento.
Me dijo que si me voy, el sufrimiento crecerá. Que yo soy la raíz que sostiene algo oscuro, algo que no pertenece del todo a este mundo.
Me dijo que debía arrancarme para que todo termine.
La palabra “arrancarme” me hizo llorar. No por el dolor, sino porque la sombra lo decía como si fuera un acto de amor hacia las demás.
Voy a cerrar el libro. Voy a intentar dormir. Mañana nos iremos. Aunque siento un peso en el pecho, como si el convento me sujetara por dentro y no quisiera soltarme.
Pero yo también tengo una hermana. Y sé que ella me necesita viva."
    };

    void Update()
    {
        if (isActive && Input.GetKeyDown(KeyCode.Return))
        {
            TancarPanel();
        }
    }

    public void Interactuar()
    {
        InteractuarNota(currentNoteIndex);
    }

    public void InteractuarNota(int index)
    {
        if (index < 0 || index >= notes.Length) return;
        ObrirPanel(index);
    }

    private void ObrirPanel(int index)
    {
        if (panel != null)
            panel.SetActive(true);

        if (textBox != null)
        {
            // Combina título + salto de línea + contenido
            textBox.text = $"<b>{titles[index]}</b>\n\n{notes[index]}";
        }

        isActive = true;
    }

    private void TancarPanel()
    {
        if (panel != null)
            panel.SetActive(false);

        isActive = false;
    }
}
