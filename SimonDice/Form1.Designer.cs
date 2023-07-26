namespace SimonDice
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            label1 = new Label();
            label2 = new Label();
            button1 = new Button();
            temporizador = new System.Windows.Forms.Timer(components);
            SuspendLayout();
            // 
            // label1
            // 
            label1.Font = new Font("Segoe UI", 20F, FontStyle.Bold, GraphicsUnit.Point);
            label1.Location = new Point(96, 9);
            label1.Name = "label1";
            label1.Size = new Size(417, 60);
            label1.TabIndex = 0;
            label1.Text = "Simon Says Game C#";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(108, 360);
            label2.Name = "label2";
            label2.Size = new Size(381, 28);
            label2.TabIndex = 1;
            label2.Text = "Click on the 3 blocks in the same sequence";
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Emoji", 9F, FontStyle.Regular, GraphicsUnit.Point);
            button1.Location = new Point(238, 408);
            button1.Name = "button1";
            button1.Size = new Size(112, 50);
            button1.TabIndex = 2;
            button1.Text = "Empezar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += ButtonClickEvent;
            // 
            // temporizador
            // 
            temporizador.Interval = 20;
            temporizador.Tick += GameTimerEvent;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(598, 494);
            Controls.Add(button1);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Form1";
            ShowIcon = false;
            Text = "Simon Says Game";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button button1;
        private System.Windows.Forms.Timer temporizador;
    }
}