namespace SAD_APLIKASI_BEBEK_LUMER_FITUR_PAYMENT_AND_INVOICE
{
    partial class FormPayment
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPayment));
            this.imageListFormPayment = new System.Windows.Forms.ImageList(this.components);
            this.panelPayment = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.panelPayment.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageListFormPayment
            // 
            this.imageListFormPayment.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFormPayment.ImageStream")));
            this.imageListFormPayment.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFormPayment.Images.SetKeyName(0, "T_BACKGROUND.png");
            // 
            // panelPayment
            // 
            this.panelPayment.Controls.Add(this.label1);
            this.panelPayment.ForeColor = System.Drawing.SystemColors.ControlText;
            this.panelPayment.Location = new System.Drawing.Point(0, 299);
            this.panelPayment.Name = "panelPayment";
            this.panelPayment.Size = new System.Drawing.Size(1920, 781);
            this.panelPayment.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Montserrat", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(77, 341);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(102, 40);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage_1);
            // 
            // FormPayment
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panelPayment);
            this.Name = "FormPayment";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panelPayment.ResumeLayout(false);
            this.panelPayment.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ImageList imageListFormPayment;
        private System.Windows.Forms.Panel panelPayment;
        private System.Windows.Forms.Label label1;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}

