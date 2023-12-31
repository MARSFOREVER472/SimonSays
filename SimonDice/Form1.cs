using System.Diagnostics; // Librer�a especial para la clase.

namespace SimonDice
{
    public partial class Form1 : Form
    {

        // Definiremos las variables para los cuadrados del juego.

        int blocksX = 160; // Ancho total de cada cuadrado.
        int blocksY = 80; // Altura total de cada cuadrado.
        int score = 0; // Puntuaci�n inicial del juego.
        int level = 3; // Comienzo del nivel.

        // Ahora crearemos algunas variables mediante listas la aparici�n de los bloques en el juego.

        List<PictureBox> pictureBoxes = new List<PictureBox>(); // Cuadrados del juego.
        List<PictureBox> chooseBoxes = new List<PictureBox>(); // Escoger cuadrados del juego.
        Random rand = new Random(); // Variable aleatoria.

        Color temp; // Variable para un color.

        int index = 0; // Valor del �ndice por defecto.
        int tries = 0; // N�mero de intentos inicial del juego.

        int timeLimit = 0; // Tiempo l�mite inicial.
        bool selectingColors = false; // No se seleccionar� un color para cada cuadrado, es decir, se generan aleatoriamente mediante una variable creada ya anteriormente arriba.

        string correctOrder = string.Empty; // Al hacer click a cada cuadrado, tendr�a que seguir la secuencia como se hizo en una demostraci�n inicial de cada nivel.
        string playerOrder = string.Empty; // El jugador tiene que seguir al oponente que hizo la demostraci�n, es decir, no equivocarse.

        public Form1()
        {
            InitializeComponent(); // Llamado del m�todo inicial.
            SetUpBlocks(); // Llamado del m�todo creado para ordenar bloques.
        }

        // M�todo creado desde el tick de este componente (temporizador).
        private void GameTimerEvent(object sender, EventArgs e)
        {
            // Procederemos a crear un algoritmo mediante un temporizador en cuesti�n de segundos.

            if (selectingColors) // Si se selecciona cualquier cuadrado de un color distinto.
            {
                timeLimit++; // El tiempo l�mite se incrementa.

                // Por cada segundo del temporizador, utilizaremos una estructura del switch.

                switch (timeLimit)
                {
                    case 10: // Si son 10 segundos.
                        temp = chooseBoxes[index].BackColor;
                        chooseBoxes[index].BackColor = Color.Beige; // Se debe escoger un color cuando es una pista.
                        break;

                    case 20: // Si son 20 segundos.
                        chooseBoxes[index].BackColor = temp;
                        break;

                    case 30: // Si son 30 segundos.
                        chooseBoxes[index].BackColor = Color.Beige; // Se debe escoger un color cuando es una pista.
                        break;

                    case 40: // Si son 40 segundos.
                        chooseBoxes[index].BackColor = temp;
                        break;

                    case 50: // Si son 50 segundos.

                        // En estos momentos se divide en un algoritmo diferente a los primeros 50 segundos.

                        if (index < chooseBoxes.Count - 1)
                        {
                            index++; // El valor del �ndice se incrementa.
                            timeLimit = 0; // El tiempo l�mite se inicializa.
                        }
                        else // En caso contrario...
                        {
                            selectingColors = false; // No se seleccionar� un color para cada cuadrado.
                        }
                        break;
                }
            }

            // Ahora realizaremos las siguientes acciones de �xito y fracaso mediante un "if" y un "else".

            if (tries >= level)
            {
                // Cuando aciertas algunos cuadrados en cada nivel del juego...

                if (correctOrder == playerOrder)
                {
                    tries = 0; // Se inicializa en 0 el n�mero de intentos.
                    temporizador.Stop(); // Frena el temporizador infinitamente (cualquier n�mero).
                    MessageBox.Show("Felicidades, lo hiciste muy bien!!"); // Felicidades, lo hiciste muy bien!!.
                    score++; // Aumenta la puntuaci�n al acertar cada cuadrado.
                }
                else // En caso contrario si es que el jugador falla.
                {
                    tries = 0; // Se inicializa en 0 el n�mero de intentos.
                    temporizador.Stop(); // Frena el temporizador infinitamente (cualquier n�mero).
                    MessageBox.Show("Int�ntalo nuevamente!!", "No, no es el MH!!"); // No, no es el MM!! || int�ntalo nuevamente.
                }
            }

            lblInformal.Text = "Click on " + level + " blocks in the same sequence."; // Mensaje de texto como instrucci�n o consejo fundamental del juego.
        }

        // M�todo creado desde un control (button).
        private void ButtonClickEvent(object sender, EventArgs e)
        {
            // Procedemos a utilizar una condici�n para poder pasar de nivel al obtener los �xitos.

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

            // Para los colores aleatorios de cada cuadrado, utilizaremos la siguiente iteraci�n (foreach).

            foreach (PictureBox x in pictureBoxes)
            {
                x.BackColor = Color.FromArgb(rand.Next(256), rand.Next(256), rand.Next(256)); // Genera unos colores aleatorios para cada cuadrado del tablero.
            }

            // Otras sentencias de c�digo son las siguientes...

            Debug.WriteLine(correctOrder); // El nombre de un cuadrado se muestra en la consola.
            index = 0; // Valor del �ndice inicial.
            timeLimit = 0; // El tiempo finaliza en 0.
            selectingColors = true; // Los colores pueden ser cualquiera (Aleatorio).
            temporizador.Start(); // Inicializa el tiempo al comenzar el juego (QUE EMPIECE EL JUEGO!!!!!!!!!).
        }

        // Ahora vamos a crear un m�todo para ordenar los cuadrados.
        private void SetUpBlocks()
        {
            // El valor de los cuadrados no debe ser mayor a 16.

            for (int i = 1; i < 17; i++)
            {
                PictureBox newPic = new PictureBox(); // Para los cuadrados.
                newPic.Name = "pic_" + i; // Nombre de cada cuadrado.
                newPic.Height = 60; // La altura de cada cuadrado debe ser 60 al igual que su ancho.
                newPic.Width = 60; // Para el ancho lo mismo, porque tienen que ser cuadrados.
                newPic.BackColor = Color.DarkRed; // El color de cada cuadrado al inicio tendr�n que ser de color rojo oscuro.
                newPic.Left = blocksX; // Cuadrados en X.
                newPic.Top = blocksY; // Cuadrados en Y.
                newPic.Click += ClickOnPictureBox; // Antes de eso se debe crear un nuevo m�todo para el llamado.

                // Aqu� mismo generaremos un algoritmo mediante condiciones "if" y "else".

                if (i == 4 || i == 8 || i == 12)
                {
                    blocksY += 65; // Distancia de los cuadrados en Y.
                    blocksX = 160; // Distancia de los cuadrados en X.
                }
                else // En caso contrario dependiendo de la distancia en X.
                {
                    blocksX += 65;
                }

                // A�adiremos los cuadrados creados al juego.

                this.Controls.Add(newPic); // Controles para el juego.
                pictureBoxes.Add(newPic); // Cuadrados para el juego.
            }
        }

        // Generaremos un nuevo m�todo al hacer click a cada cuadrado.
        private void ClickOnPictureBox(object? sender, EventArgs e)
        {
            // Por �ltimo, en este m�todo asignaremos algunas funcionalidades a los cuadrados del juego.

            if (!selectingColors && chooseBoxes.Count > 1)
            {
                PictureBox temp = sender as PictureBox;
                temp.BackColor = Color.Black; // Al inicio del juego, los cuadrados ser�n de color negro.
                playerOrder += temp.Name + " "; // El nombre se mostrar� en el depurador local de Windows.
                Debug.WriteLine(playerOrder); // El debug de esta variable se mostrar� en la consola del depurador.
                tries++; // El n�mero de intentos se incrementar�.
            }
            else // En caso contrario, no har� nada.
            {
                return;
            }
        }
    }
}