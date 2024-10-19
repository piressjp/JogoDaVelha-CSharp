namespace JogoDaVelha
{
    partial class StartForm
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
            this.buttonOneVsOne = new System.Windows.Forms.Button();
            this.buttonVsMachine = new System.Windows.Forms.Button();
            this.labelTitle = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOneVsOne
            // 
            this.buttonOneVsOne.Location = new System.Drawing.Point(262, 203);
            this.buttonOneVsOne.Name = "buttonOneVsOne";
            this.buttonOneVsOne.Size = new System.Drawing.Size(130, 30);
            this.buttonOneVsOne.TabIndex = 0;
            this.buttonOneVsOne.Text = "1 X 1";
            this.buttonOneVsOne.UseVisualStyleBackColor = true;
            this.buttonOneVsOne.Click += new System.EventHandler(this.ButtonOneVsOne_Click);
            // 
            // buttonVsMachine
            // 
            this.buttonVsMachine.Location = new System.Drawing.Point(262, 154);
            this.buttonVsMachine.Name = "buttonVsMachine";
            this.buttonVsMachine.Size = new System.Drawing.Size(130, 30);
            this.buttonVsMachine.TabIndex = 2;
            this.buttonVsMachine.Text = "1 X Machine";
            this.buttonVsMachine.UseVisualStyleBackColor = true;
            this.buttonVsMachine.Click += new System.EventHandler(this.ButtonVsMachine_Click);
            // 
            // labelTitle
            // 
            this.labelTitle.AutoSize = true;
            this.labelTitle.Font = new System.Drawing.Font("Arial", 22F, System.Drawing.FontStyle.Bold);
            this.labelTitle.Location = new System.Drawing.Point(217, 76);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(271, 44);
            this.labelTitle.TabIndex = 1;
            this.labelTitle.Text = "Jogo da Velha";
            this.labelTitle.Click += new System.EventHandler(this.labelTitle_Click);
            // 
            // StartForm
            // 
            this.BackColor = System.Drawing.Color.FloralWhite;
            this.ClientSize = new System.Drawing.Size(649, 389);
            this.Controls.Add(this.buttonVsMachine);
            this.Controls.Add(this.buttonOneVsOne);
            this.Controls.Add(this.labelTitle);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "StartForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Início";
            this.TransparencyKey = System.Drawing.Color.Transparent;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}