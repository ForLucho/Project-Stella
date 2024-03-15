namespace Presentation
{
    partial class Actividades
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
            this.contenedoract = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // contenedoract
            // 
            this.contenedoract.Location = new System.Drawing.Point(0, 0);
            this.contenedoract.Name = "contenedoract";
            this.contenedoract.Size = new System.Drawing.Size(815, 547);
            this.contenedoract.TabIndex = 0;
            // 
            // Actividades
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(815, 547);
            this.Controls.Add(this.contenedoract);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Actividades";
            this.Text = "Indexactividades";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel contenedoract;
    }
}