namespace Helsinki
{
    partial class Form1
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
            this.buttonBeolvas = new System.Windows.Forms.Button();
            this.button2Feladat = new System.Windows.Forms.Button();
            this.button3Feladat = new System.Windows.Forms.Button();
            this.button5Feladat = new System.Windows.Forms.Button();
            this.button7Feladat = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // buttonBeolvas
            // 
            this.buttonBeolvas.Location = new System.Drawing.Point(13, 13);
            this.buttonBeolvas.Name = "buttonBeolvas";
            this.buttonBeolvas.Size = new System.Drawing.Size(75, 23);
            this.buttonBeolvas.TabIndex = 0;
            this.buttonBeolvas.Text = "Beolvas";
            this.buttonBeolvas.UseVisualStyleBackColor = true;
            this.buttonBeolvas.Click += new System.EventHandler(this.buttonBeolvas_Click);
            // 
            // button2Feladat
            // 
            this.button2Feladat.Location = new System.Drawing.Point(13, 80);
            this.button2Feladat.Name = "button2Feladat";
            this.button2Feladat.Size = new System.Drawing.Size(75, 23);
            this.button2Feladat.TabIndex = 1;
            this.button2Feladat.Text = "2. Feladat";
            this.button2Feladat.UseVisualStyleBackColor = true;
            this.button2Feladat.Click += new System.EventHandler(this.button2Feladat_Click);
            // 
            // button3Feladat
            // 
            this.button3Feladat.Location = new System.Drawing.Point(13, 110);
            this.button3Feladat.Name = "button3Feladat";
            this.button3Feladat.Size = new System.Drawing.Size(75, 23);
            this.button3Feladat.TabIndex = 2;
            this.button3Feladat.Text = "3. Feladat";
            this.button3Feladat.UseVisualStyleBackColor = true;
            this.button3Feladat.Click += new System.EventHandler(this.button3Feladat_Click);
            // 
            // button5Feladat
            // 
            this.button5Feladat.Location = new System.Drawing.Point(13, 140);
            this.button5Feladat.Name = "button5Feladat";
            this.button5Feladat.Size = new System.Drawing.Size(75, 23);
            this.button5Feladat.TabIndex = 3;
            this.button5Feladat.Text = "5. Feladat";
            this.button5Feladat.UseVisualStyleBackColor = true;
            // 
            // button7Feladat
            // 
            this.button7Feladat.Location = new System.Drawing.Point(13, 170);
            this.button7Feladat.Name = "button7Feladat";
            this.button7Feladat.Size = new System.Drawing.Size(75, 23);
            this.button7Feladat.TabIndex = 4;
            this.button7Feladat.Text = "7. Feladat";
            this.button7Feladat.UseVisualStyleBackColor = true;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(94, 13);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(694, 425);
            this.richTextBox1.TabIndex = 5;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(813, 456);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button7Feladat);
            this.Controls.Add(this.button5Feladat);
            this.Controls.Add(this.button3Feladat);
            this.Controls.Add(this.button2Feladat);
            this.Controls.Add(this.buttonBeolvas);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBeolvas;
        private System.Windows.Forms.Button button2Feladat;
        private System.Windows.Forms.Button button3Feladat;
        private System.Windows.Forms.Button button5Feladat;
        private System.Windows.Forms.Button button7Feladat;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

