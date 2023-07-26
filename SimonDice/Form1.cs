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
            // EN INSTANTES...
        }

        // M�todo creado desde un control (button).
        private void ButtonClickEvent(object sender, EventArgs e)
        {
            // EN INSTANTES...
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
            // EN INSTANTES...
        }
    }
}