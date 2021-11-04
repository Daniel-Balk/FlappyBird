namespace FlappyBird
{
    partial class FlappyWindow
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            FlappyBird.Engine.FlappyBirdApplication flappyBirdApplication1 = new FlappyBird.Engine.FlappyBirdApplication();
            this.gameRenderComponent1 = new FlappyBird.Engine.GameRenderComponent();
            this.SuspendLayout();
            // 
            // gameRenderComponent1
            // 
            this.gameRenderComponent1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameRenderComponent1.FlappyBird = flappyBirdApplication1;
            this.gameRenderComponent1.Location = new System.Drawing.Point(0, 0);
            this.gameRenderComponent1.MaxFPS = 30;
            this.gameRenderComponent1.Name = "gameRenderComponent1";
            this.gameRenderComponent1.Size = new System.Drawing.Size(1184, 861);
            this.gameRenderComponent1.TabIndex = 0;
            this.gameRenderComponent1.Text = "Flappy Bird";
            // 
            // FlappyWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 861);
            this.Controls.Add(this.gameRenderComponent1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FlappyWindow";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Engine.GameRenderComponent gameRenderComponent1;
    }
}