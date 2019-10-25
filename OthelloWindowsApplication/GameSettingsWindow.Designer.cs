namespace OthelloWindowsApplication
{
    public partial class GameSettingsWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.ComputerButton = new System.Windows.Forms.Button();
            this.PlayerButton = new System.Windows.Forms.Button();
            this.BoardSizeButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ComputerButton
            // 
            this.ComputerButton.Location = new System.Drawing.Point(14, 89);
            this.ComputerButton.Name = "ComputerButton";
            this.ComputerButton.Size = new System.Drawing.Size(157, 45);
            this.ComputerButton.TabIndex = 2;
            this.ComputerButton.Text = "Play against the computer";
            this.ComputerButton.UseVisualStyleBackColor = true;
            // 
            // PlayerButton
            // 
            this.PlayerButton.Location = new System.Drawing.Point(206, 89);
            this.PlayerButton.Name = "PlayerButton";
            this.PlayerButton.Size = new System.Drawing.Size(157, 45);
            this.PlayerButton.TabIndex = 3;
            this.PlayerButton.Text = "Play against your friend";
            this.PlayerButton.UseVisualStyleBackColor = true;
            // 
            // BoardSizeButton
            // 
            this.BoardSizeButton.Location = new System.Drawing.Point(14, 14);
            this.BoardSizeButton.Name = "BoardSizeButton";
            this.BoardSizeButton.Size = new System.Drawing.Size(350, 54);
            this.BoardSizeButton.TabIndex = 4;
            this.BoardSizeButton.Text = "Board Size: 6x6 (click to increase)";
            this.BoardSizeButton.UseVisualStyleBackColor = true;
            this.BoardSizeButton.Click += new System.EventHandler(this.boardSizeButton_Click);
            // 
            // GameSettingsWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(371, 143);
            this.Controls.Add(this.BoardSizeButton);
            this.Controls.Add(this.PlayerButton);
            this.Controls.Add(this.ComputerButton);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameSettingsWindow";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Othello - Game Settings";
            this.ResumeLayout(false);

        }

        #endregion
        public System.Windows.Forms.Button ComputerButton;
        public System.Windows.Forms.Button PlayerButton;
        private System.Windows.Forms.Button BoardSizeButton;
    }
}