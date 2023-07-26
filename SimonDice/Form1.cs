using System.Diagnostics; // Librería especial para la clase.

namespace SimonDice
{
    public partial class Form1 : Form
    {

        // Definiremos las variables para los cuadrados del juego.

        int blocksX = 160; // Ancho total de cada cuadrado.
        int blocksY = 80; // Altura total de cada cuadrado.
        int score = 0; // Puntuación inicial del juego.
        int level = 3; // Comienzo del nivel.

        // Ahora crearemos algunas variables mediante listas la aparición de los bloques en el juego.

        List<PictureBox> pictureBoxes = new List<PictureBox>(); // Cuadrados del juego.
        List<PictureBox> chooseBoxes = new List<PictureBox>(); // Escoger cuadrados del juego.
        Random rand = new Random(); // Variable aleatoria.

        Color temp; // Variable para un color.

        int index = 0; // Valor del índice por defecto.
        int tries = 0; // Número de intentos inicial del juego.

        int timeLimit = 0; // Tiempo límite inicial.
        bool selectingColors = false; // No se seleccionará un color para cada cuadrado, es decir, se generan aleatoriamente mediante una variable creada ya anteriormente arriba.

        string correctOrder = string.Empty; // Al hacer click a cada cuadrado, tendría que seguir la secuencia como se hizo en una demostración inicial de cada nivel.
        string playerOrder = string.Empty; // El jugador tiene que seguir al oponente que hizo la demostración, es decir, no equivocarse.

        public Form1()
        {
            InitializeComponent(); // Llamado del método inicial.
            SetUpBlocks(); // Llamado del método creado para ordenar bloques.
        }

        // Método creado desde el tick de este componente (temporizador).
        private void GameTimerEvent(object sender, EventArgs e)
        {
            // EN INSTANTES...
        }

        // Método creado desde un control (button).
        private void ButtonClickEvent(object sender, EventArgs e)
        {
            // Procedemos a utilizar una condición para poder pasar de nivel al obtener los éxitos.

            if (score == 3 && level < 7)
            {
                level++; // Pasa al siguiente nivel.
                score = 0; // Al pasar de nivel, se inicializa en 0 los puntos.
            }

            correctOrder = string.Empty; // El oponente inventa una secuencia en el orden correcto.
            playerOrder = string.Empty; // El jugador tiene que seguir al oponente para poder pasar de nivel.
            chooseBoxes.Clear(); // Se borra todo el tablero al escoger un cuadrado.
            chooseBoxes = pictureBoxes.OrderBy(x => rand.Next()).Take(level).ToList(); // Se debe escoger un cuadrado siguiendo la secuencia para no fallar.

            // Al escoger cualquier cuadrado del tablero, utilizaremos un ciclo for.

            for (int i = 0; i < chooseBoxes.Count; i++)
            {
                correctOrder += chooseBoxes[i].Name + " "; // Cuando escoge un cuadrado.
            }

            // Para los colores aleatorios de cada cuadrado, utilizaremos la siguiente iteración (foreach).

            foreach (PictureBox x in pictureBoxes)
            {
                x.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)); // Genera unos colores aleatorios para cada cuadrado del tablero.
            }

            // Otras sentencias de código son las siguientes...

            Debug.WriteLine(correctOrder); // Debug principal.
            index = 0; // Valor del índice inicial.
            timeLimit = 0; // El tiempo finaliza en 0.
            selectingColors = true; // Los colores pueden ser cualquiera (Aleatorio).
            temporizador.Start(); // Inicializa el tiempo al comenzar el juego (QUE EMPIECE EL JUEGO!!!!!!!!!).
        }

        // Ahora vamos a crear un método para ordenar los cuadrados.
        private void SetUpBlocks()
        {
            // El valor de los cuadrados no debe ser mayor a 16.

            for (int i = 1; i < 17; i++)
            {
                PictureBox newPic = new PictureBox(); // Para los cuadrados.
                newPic.Name = "pic_" + i; // Nombre de cada cuadrado.
                newPic.Height = 60; // La altura de cada cuadrado debe ser 60 al igual que su ancho.
                newPic.Width = 60; // Para el ancho lo mismo, porque tienen que ser cuadrados.
                newPic.BackColor = Color.DarkRed; // El color de cada cuadrado al inicio tendrán que ser de color rojo oscuro.
                newPic.Left = blocksX; // Cuadrados en X.
                newPic.Top = blocksY; // Cuadrados en Y.
                newPic.Click += ClickOnPictureBox; // Antes de eso se debe crear un nuevo método para el llamado.

                // Aquí mismo generaremos un algoritmo mediante condiciones "if" y "else".

                if (i == 4 || i == 8 || i == 12)
                {
                    blocksY += 65; // Distancia de los cuadrados en Y.
                    blocksX = 160; // Distancia de los cuadrados en X.
                }
                else // En caso contrario dependiendo de la distancia en X.
                {
                    blocksX += 65;
                }

                // Añadiremos los cuadrados creados al juego.

                this.Controls.Add(newPic); // Controles para el juego.
                pictureBoxes.Add(newPic); // Cuadrados para el juego.
            }
        }

        // Generaremos un nuevo método al hacer click a cada cuadrado.
        private void ClickOnPictureBox(object? sender, EventArgs e)
        {
            // EN INSTANTES...
        }
    }
}