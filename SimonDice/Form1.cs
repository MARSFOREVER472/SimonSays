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
            InitializeComponent();
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

        // Ahora vamos a crear un m�todo para levantar el juego.

        private void SetUpBlocks()
        {
            // EN INSTANTES...
        }
    }
}