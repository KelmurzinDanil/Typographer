namespace Tipograf
{
    partial class Typographer
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
            UserText = new RichTextBox();
            TypographerText = new RichTextBox();
            SuspendLayout();
            // 
            // UserText
            // 
            UserText.BorderStyle = BorderStyle.FixedSingle;
            UserText.Location = new Point(12, 12);
            UserText.Name = "UserText";
            UserText.Size = new Size(563, 677);
            UserText.TabIndex = 0;
            UserText.Text = "";
            UserText.TextChanged += UserText_TextChanged;
            // 
            // TypographerText
            // 
            TypographerText.BorderStyle = BorderStyle.FixedSingle;
            TypographerText.Location = new Point(642, 12);
            TypographerText.Name = "TypographerText";
            TypographerText.Size = new Size(563, 677);
            TypographerText.TabIndex = 1;
            TypographerText.Text = "";
            // 
            // Typographer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1217, 701);
            Controls.Add(TypographerText);
            Controls.Add(UserText);
            Name = "Typographer";
            Text = "Типограф";
            ResumeLayout(false);
        }

        #endregion

        private RichTextBox UserText;
        private RichTextBox TypographerText;
    }
}
