namespace Szakdolgozat
{
    partial class Szerkeszt
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Szerkeszt));
            this.dolgozok_View = new System.Windows.Forms.ListView();
            this.dolgozoneve_label = new System.Windows.Forms.Label();
            this.beosztas_label = new System.Windows.Forms.Label();
            this.csoport_label = new System.Windows.Forms.Label();
            this.dolgozoneve_Text = new System.Windows.Forms.TextBox();
            this.beosztas_Text = new System.Windows.Forms.TextBox();
            this.csoport_Box = new System.Windows.Forms.ComboBox();
            this.mentesButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.kezdőlapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szerkesztésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intézményToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csoportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dolgozókToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.box_szerkesztes = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.box_szerkesztes.SuspendLayout();
            this.SuspendLayout();
            // 
            // dolgozok_View
            // 
            this.dolgozok_View.BackColor = System.Drawing.SystemColors.HotTrack;
            this.dolgozok_View.HideSelection = false;
            this.dolgozok_View.Location = new System.Drawing.Point(12, 63);
            this.dolgozok_View.Name = "dolgozok_View";
            this.dolgozok_View.Size = new System.Drawing.Size(132, 269);
            this.dolgozok_View.TabIndex = 0;
            this.dolgozok_View.UseCompatibleStateImageBehavior = false;
            this.dolgozok_View.View = System.Windows.Forms.View.Tile;
            this.dolgozok_View.SelectedIndexChanged += new System.EventHandler(this.dolgozok_View_SelectedIndexChanged);
            // 
            // dolgozoneve_label
            // 
            this.dolgozoneve_label.AutoSize = true;
            this.dolgozoneve_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.dolgozoneve_label.Location = new System.Drawing.Point(61, 63);
            this.dolgozoneve_label.Name = "dolgozoneve_label";
            this.dolgozoneve_label.Size = new System.Drawing.Size(111, 16);
            this.dolgozoneve_label.TabIndex = 1;
            this.dolgozoneve_label.Text = "Dolgozó Neve:";
            // 
            // beosztas_label
            // 
            this.beosztas_label.AutoSize = true;
            this.beosztas_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.beosztas_label.Location = new System.Drawing.Point(61, 96);
            this.beosztas_label.Name = "beosztas_label";
            this.beosztas_label.Size = new System.Drawing.Size(85, 16);
            this.beosztas_label.TabIndex = 2;
            this.beosztas_label.Text = "Beosztása:";
            // 
            // csoport_label
            // 
            this.csoport_label.AutoSize = true;
            this.csoport_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.csoport_label.Location = new System.Drawing.Point(61, 130);
            this.csoport_label.Name = "csoport_label";
            this.csoport_label.Size = new System.Drawing.Size(70, 16);
            this.csoport_label.TabIndex = 3;
            this.csoport_label.Text = "Csoport: ";
            // 
            // dolgozoneve_Text
            // 
            this.dolgozoneve_Text.Location = new System.Drawing.Point(178, 62);
            this.dolgozoneve_Text.Name = "dolgozoneve_Text";
            this.dolgozoneve_Text.Size = new System.Drawing.Size(178, 20);
            this.dolgozoneve_Text.TabIndex = 4;
            // 
            // beosztas_Text
            // 
            this.beosztas_Text.Location = new System.Drawing.Point(178, 98);
            this.beosztas_Text.Name = "beosztas_Text";
            this.beosztas_Text.Size = new System.Drawing.Size(178, 20);
            this.beosztas_Text.TabIndex = 5;
            // 
            // csoport_Box
            // 
            this.csoport_Box.FormattingEnabled = true;
            this.csoport_Box.Items.AddRange(new object[] {
            " "});
            this.csoport_Box.Location = new System.Drawing.Point(178, 129);
            this.csoport_Box.Name = "csoport_Box";
            this.csoport_Box.Size = new System.Drawing.Size(121, 21);
            this.csoport_Box.TabIndex = 6;
            // 
            // mentesButton
            // 
            this.mentesButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mentesButton.BackgroundImage")));
            this.mentesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mentesButton.Enabled = false;
            this.mentesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mentesButton.Location = new System.Drawing.Point(525, 37);
            this.mentesButton.Name = "mentesButton";
            this.mentesButton.Size = new System.Drawing.Size(92, 49);
            this.mentesButton.TabIndex = 7;
            this.mentesButton.UseVisualStyleBackColor = true;
            this.mentesButton.Click += new System.EventHandler(this.mentesButton_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kezdőlapToolStripMenuItem,
            this.szerkesztésToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(629, 24);
            this.menuStrip1.TabIndex = 8;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // kezdőlapToolStripMenuItem
            // 
            this.kezdőlapToolStripMenuItem.Name = "kezdőlapToolStripMenuItem";
            this.kezdőlapToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.kezdőlapToolStripMenuItem.Text = "Kezdőlap";
            this.kezdőlapToolStripMenuItem.Click += new System.EventHandler(this.kezdőlapToolStripMenuItem_Click);
            // 
            // szerkesztésToolStripMenuItem
            // 
            this.szerkesztésToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.intézményToolStripMenuItem,
            this.csoportToolStripMenuItem,
            this.dolgozókToolStripMenuItem});
            this.szerkesztésToolStripMenuItem.Name = "szerkesztésToolStripMenuItem";
            this.szerkesztésToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.szerkesztésToolStripMenuItem.Text = "Szerkesztés";
            // 
            // intézményToolStripMenuItem
            // 
            this.intézményToolStripMenuItem.Name = "intézményToolStripMenuItem";
            this.intézményToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.intézményToolStripMenuItem.Text = "Intézmény";
            this.intézményToolStripMenuItem.Click += new System.EventHandler(this.intézményToolStripMenuItem_Click);
            // 
            // csoportToolStripMenuItem
            // 
            this.csoportToolStripMenuItem.Name = "csoportToolStripMenuItem";
            this.csoportToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.csoportToolStripMenuItem.Text = "Csoport";
            this.csoportToolStripMenuItem.Click += new System.EventHandler(this.csoportToolStripMenuItem_Click);
            // 
            // dolgozókToolStripMenuItem
            // 
            this.dolgozókToolStripMenuItem.Name = "dolgozókToolStripMenuItem";
            this.dolgozókToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.dolgozókToolStripMenuItem.Text = "Dolgozók";
            this.dolgozókToolStripMenuItem.Click += new System.EventHandler(this.dolgozókToolStripMenuItem_Click);
            // 
            // box_szerkesztes
            // 
            this.box_szerkesztes.BackColor = System.Drawing.Color.Transparent;
            this.box_szerkesztes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("box_szerkesztes.BackgroundImage")));
            this.box_szerkesztes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.box_szerkesztes.Controls.Add(this.dolgozoneve_label);
            this.box_szerkesztes.Controls.Add(this.beosztas_label);
            this.box_szerkesztes.Controls.Add(this.csoport_Box);
            this.box_szerkesztes.Controls.Add(this.csoport_label);
            this.box_szerkesztes.Controls.Add(this.beosztas_Text);
            this.box_szerkesztes.Controls.Add(this.dolgozoneve_Text);
            this.box_szerkesztes.Enabled = false;
            this.box_szerkesztes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.box_szerkesztes.Location = new System.Drawing.Point(150, 92);
            this.box_szerkesztes.Name = "box_szerkesztes";
            this.box_szerkesztes.Size = new System.Drawing.Size(467, 240);
            this.box_szerkesztes.TabIndex = 9;
            this.box_szerkesztes.TabStop = false;
            this.box_szerkesztes.Text = "Szerkesztés";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(12, 37);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(132, 20);
            this.textBox1.TabIndex = 10;
            this.textBox1.Text = "Keresés....";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // button1
            // 
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(156, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(97, 49);
            this.button1.TabIndex = 11;
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Szerkeszt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(629, 348);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.box_szerkesztes);
            this.Controls.Add(this.mentesButton);
            this.Controls.Add(this.dolgozok_View);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximumSize = new System.Drawing.Size(645, 387);
            this.MinimumSize = new System.Drawing.Size(645, 387);
            this.Name = "Szerkeszt";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Dolgozók szerkesztése";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Szerkeszt_FormClosing);
            this.Load += new System.EventHandler(this.Szerkeszt_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.box_szerkesztes.ResumeLayout(false);
            this.box_szerkesztes.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView dolgozok_View;
        private System.Windows.Forms.Label dolgozoneve_label;
        private System.Windows.Forms.Label beosztas_label;
        private System.Windows.Forms.Label csoport_label;
        private System.Windows.Forms.TextBox dolgozoneve_Text;
        private System.Windows.Forms.TextBox beosztas_Text;
        private System.Windows.Forms.ComboBox csoport_Box;
        private System.Windows.Forms.Button mentesButton;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem kezdőlapToolStripMenuItem;
        private System.Windows.Forms.GroupBox box_szerkesztes;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ToolStripMenuItem szerkesztésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intézményToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem csoportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dolgozókToolStripMenuItem;
    }
}