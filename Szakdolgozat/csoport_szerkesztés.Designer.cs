namespace Szakdolgozat
{
    partial class csoport_szerkesztés
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(csoport_szerkesztés));
            this.button1 = new System.Windows.Forms.Button();
            this.box_szerkesztes = new System.Windows.Forms.GroupBox();
            this.dolgozoneve_label = new System.Windows.Forms.Label();
            this.beosztas_label = new System.Windows.Forms.Label();
            this.telephely_Box = new System.Windows.Forms.ComboBox();
            this.csoport_label = new System.Windows.Forms.Label();
            this.csoportLetszam_Text = new System.Windows.Forms.TextBox();
            this.csoportNeve_Text = new System.Windows.Forms.TextBox();
            this.dolgozókToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.csoportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.intézményToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.szerkesztésToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kezdőlapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mentesButton = new System.Windows.Forms.Button();
            this.csoportok_View = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.box_szerkesztes.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("button1.BackgroundImage")));
            this.button1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.button1.Enabled = false;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Location = new System.Drawing.Point(156, 36);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 41);
            this.button1.TabIndex = 17;
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // box_szerkesztes
            // 
            this.box_szerkesztes.BackColor = System.Drawing.Color.Transparent;
            this.box_szerkesztes.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("box_szerkesztes.BackgroundImage")));
            this.box_szerkesztes.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.box_szerkesztes.Controls.Add(this.dolgozoneve_label);
            this.box_szerkesztes.Controls.Add(this.beosztas_label);
            this.box_szerkesztes.Controls.Add(this.telephely_Box);
            this.box_szerkesztes.Controls.Add(this.csoport_label);
            this.box_szerkesztes.Controls.Add(this.csoportLetszam_Text);
            this.box_szerkesztes.Controls.Add(this.csoportNeve_Text);
            this.box_szerkesztes.Enabled = false;
            this.box_szerkesztes.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.box_szerkesztes.Location = new System.Drawing.Point(150, 83);
            this.box_szerkesztes.Name = "box_szerkesztes";
            this.box_szerkesztes.Size = new System.Drawing.Size(467, 240);
            this.box_szerkesztes.TabIndex = 15;
            this.box_szerkesztes.TabStop = false;
            this.box_szerkesztes.Text = "Szerkesztés";
            // 
            // dolgozoneve_label
            // 
            this.dolgozoneve_label.AutoSize = true;
            this.dolgozoneve_label.Location = new System.Drawing.Point(77, 75);
            this.dolgozoneve_label.Name = "dolgozoneve_label";
            this.dolgozoneve_label.Size = new System.Drawing.Size(86, 13);
            this.dolgozoneve_label.TabIndex = 1;
            this.dolgozoneve_label.Text = "Csoport neve:";
            // 
            // beosztas_label
            // 
            this.beosztas_label.AutoSize = true;
            this.beosztas_label.Location = new System.Drawing.Point(77, 108);
            this.beosztas_label.Name = "beosztas_label";
            this.beosztas_label.Size = new System.Drawing.Size(100, 13);
            this.beosztas_label.TabIndex = 2;
            this.beosztas_label.Text = "Csoport létszám:";
            // 
            // telephely_Box
            // 
            this.telephely_Box.FormattingEnabled = true;
            this.telephely_Box.Items.AddRange(new object[] {
            " "});
            this.telephely_Box.Location = new System.Drawing.Point(188, 139);
            this.telephely_Box.Name = "telephely_Box";
            this.telephely_Box.Size = new System.Drawing.Size(121, 21);
            this.telephely_Box.TabIndex = 6;
            // 
            // csoport_label
            // 
            this.csoport_label.AutoSize = true;
            this.csoport_label.Location = new System.Drawing.Point(77, 142);
            this.csoport_label.Name = "csoport_label";
            this.csoport_label.Size = new System.Drawing.Size(70, 13);
            this.csoport_label.TabIndex = 3;
            this.csoport_label.Text = "Telephely: ";
            // 
            // csoportLetszam_Text
            // 
            this.csoportLetszam_Text.Location = new System.Drawing.Point(188, 108);
            this.csoportLetszam_Text.Name = "csoportLetszam_Text";
            this.csoportLetszam_Text.Size = new System.Drawing.Size(178, 20);
            this.csoportLetszam_Text.TabIndex = 5;
            // 
            // csoportNeve_Text
            // 
            this.csoportNeve_Text.Location = new System.Drawing.Point(188, 72);
            this.csoportNeve_Text.Name = "csoportNeve_Text";
            this.csoportNeve_Text.Size = new System.Drawing.Size(178, 20);
            this.csoportNeve_Text.TabIndex = 4;
            // 
            // dolgozókToolStripMenuItem
            // 
            this.dolgozókToolStripMenuItem.Name = "dolgozókToolStripMenuItem";
            this.dolgozókToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.dolgozókToolStripMenuItem.Text = "Dolgozók";
            this.dolgozókToolStripMenuItem.Click += new System.EventHandler(this.dolgozókToolStripMenuItem_Click);
            // 
            // csoportToolStripMenuItem
            // 
            this.csoportToolStripMenuItem.Name = "csoportToolStripMenuItem";
            this.csoportToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.csoportToolStripMenuItem.Text = "Csoport";
            // 
            // intézményToolStripMenuItem
            // 
            this.intézményToolStripMenuItem.Name = "intézményToolStripMenuItem";
            this.intézményToolStripMenuItem.Size = new System.Drawing.Size(129, 22);
            this.intézményToolStripMenuItem.Text = "Intézmény";
            this.intézményToolStripMenuItem.Click += new System.EventHandler(this.intézményToolStripMenuItem_Click);
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
            // kezdőlapToolStripMenuItem
            // 
            this.kezdőlapToolStripMenuItem.Name = "kezdőlapToolStripMenuItem";
            this.kezdőlapToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.kezdőlapToolStripMenuItem.Text = "Kezdőlap";
            this.kezdőlapToolStripMenuItem.Click += new System.EventHandler(this.kezdőlapToolStripMenuItem_Click);
            // 
            // mentesButton
            // 
            this.mentesButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("mentesButton.BackgroundImage")));
            this.mentesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.mentesButton.Enabled = false;
            this.mentesButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.mentesButton.Location = new System.Drawing.Point(542, 36);
            this.mentesButton.Name = "mentesButton";
            this.mentesButton.Size = new System.Drawing.Size(75, 41);
            this.mentesButton.TabIndex = 13;
            this.mentesButton.UseVisualStyleBackColor = true;
            this.mentesButton.Click += new System.EventHandler(this.mentesButton_Click);
            // 
            // csoportok_View
            // 
            this.csoportok_View.BackColor = System.Drawing.SystemColors.HotTrack;
            this.csoportok_View.HideSelection = false;
            this.csoportok_View.Location = new System.Drawing.Point(12, 36);
            this.csoportok_View.Name = "csoportok_View";
            this.csoportok_View.Size = new System.Drawing.Size(132, 287);
            this.csoportok_View.TabIndex = 12;
            this.csoportok_View.UseCompatibleStateImageBehavior = false;
            this.csoportok_View.View = System.Windows.Forms.View.Tile;
            this.csoportok_View.SelectedIndexChanged += new System.EventHandler(this.dolgozok_View_SelectedIndexChanged);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.kezdőlapToolStripMenuItem,
            this.szerkesztésToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(632, 24);
            this.menuStrip1.TabIndex = 14;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // csoport_szerkesztés
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(632, 360);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.box_szerkesztes);
            this.Controls.Add(this.mentesButton);
            this.Controls.Add(this.csoportok_View);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MaximumSize = new System.Drawing.Size(648, 399);
            this.MinimumSize = new System.Drawing.Size(648, 399);
            this.Name = "csoport_szerkesztés";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Csoport szerkesztése";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.csoport_szerkesztés_FormClosing);
            this.Load += new System.EventHandler(this.csoport_szerkesztés_Load);
            this.box_szerkesztes.ResumeLayout(false);
            this.box_szerkesztes.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox box_szerkesztes;
        private System.Windows.Forms.Label dolgozoneve_label;
        private System.Windows.Forms.Label beosztas_label;
        private System.Windows.Forms.ComboBox telephely_Box;
        private System.Windows.Forms.Label csoport_label;
        private System.Windows.Forms.TextBox csoportLetszam_Text;
        private System.Windows.Forms.TextBox csoportNeve_Text;
        private System.Windows.Forms.ToolStripMenuItem dolgozókToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem csoportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem intézményToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem szerkesztésToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kezdőlapToolStripMenuItem;
        private System.Windows.Forms.Button mentesButton;
        private System.Windows.Forms.ListView csoportok_View;
        private System.Windows.Forms.MenuStrip menuStrip1;
    }
}