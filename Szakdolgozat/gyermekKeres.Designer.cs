namespace Szakdolgozat
{
    partial class gyermekKeres
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
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem("");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(gyermekKeres));
            this.sugóToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menüToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.kezdőlapToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listView1 = new System.Windows.Forms.ListView();
            this.csoportSelectCombo = new System.Windows.Forms.ComboBox();
            this.gyermekKereseseButton = new System.Windows.Forms.Button();
            this.gyermekFelveteleButton = new System.Windows.Forms.Button();
            this.csoportHozzaadButton = new System.Windows.Forms.Button();
            this.intHozzaadButton = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mentesButton = new System.Windows.Forms.Button();
            this.HHHvagyHHErvenyesText = new System.Windows.Forms.MaskedTextBox();
            this.hhVAGYhhhText = new System.Windows.Forms.MaskedTextBox();
            this.gyVervenyesText = new System.Windows.Forms.MaskedTextBox();
            this.szulIdoText = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.csoportKivalaszCombo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.gyVErvenyesLabel = new System.Windows.Forms.Label();
            this.HHvagyHHHCheck = new System.Windows.Forms.CheckBox();
            this.gyVHatTextBox = new System.Windows.Forms.MaskedTextBox();
            this.anyjaNeveTextBox = new System.Windows.Forms.TextBox();
            this.omAzonMask = new System.Windows.Forms.MaskedTextBox();
            this.gyermekNeveTextBox = new System.Windows.Forms.TextBox();
            this.HervenyesLabel = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.szerkesztButton = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // sugóToolStripMenuItem
            // 
            this.sugóToolStripMenuItem.Name = "sugóToolStripMenuItem";
            this.sugóToolStripMenuItem.Size = new System.Drawing.Size(101, 22);
            this.sugóToolStripMenuItem.Text = "Sugó";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menüToolStripMenuItem,
            this.kezdőlapToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(974, 24);
            this.menuStrip1.TabIndex = 32;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // menüToolStripMenuItem
            // 
            this.menüToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sugóToolStripMenuItem});
            this.menüToolStripMenuItem.Name = "menüToolStripMenuItem";
            this.menüToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.menüToolStripMenuItem.Text = "Menü";
            // 
            // kezdőlapToolStripMenuItem
            // 
            this.kezdőlapToolStripMenuItem.Name = "kezdőlapToolStripMenuItem";
            this.kezdőlapToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.kezdőlapToolStripMenuItem.Text = "Kezdőlap";
            this.kezdőlapToolStripMenuItem.Click += new System.EventHandler(this.kezdőlapToolStripMenuItem_Click);
            // 
            // listView1
            // 
            this.listView1.HideSelection = false;
            this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.listView1.Location = new System.Drawing.Point(12, 137);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(196, 317);
            this.listView1.TabIndex = 12;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Tile;
            this.listView1.SelectedIndexChanged += new System.EventHandler(this.listView1_SelectedIndexChanged);
            // 
            // csoportSelectCombo
            // 
            this.csoportSelectCombo.FormattingEnabled = true;
            this.csoportSelectCombo.Location = new System.Drawing.Point(12, 110);
            this.csoportSelectCombo.Name = "csoportSelectCombo";
            this.csoportSelectCombo.Size = new System.Drawing.Size(196, 21);
            this.csoportSelectCombo.TabIndex = 11;
            this.csoportSelectCombo.SelectedIndexChanged += new System.EventHandler(this.csoportSelectCombo_SelectedIndexChanged);
            // 
            // gyermekKereseseButton
            // 
            this.gyermekKereseseButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gyermekKereseseButton.BackColor = System.Drawing.Color.Transparent;
            this.gyermekKereseseButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gyermekKereseseButton.BackgroundImage")));
            this.gyermekKereseseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gyermekKereseseButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.gyermekKereseseButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gyermekKereseseButton.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gyermekKereseseButton.ForeColor = System.Drawing.Color.Aquamarine;
            this.gyermekKereseseButton.Location = new System.Drawing.Point(717, 30);
            this.gyermekKereseseButton.Name = "gyermekKereseseButton";
            this.gyermekKereseseButton.Size = new System.Drawing.Size(150, 50);
            this.gyermekKereseseButton.TabIndex = 16;
            this.gyermekKereseseButton.Text = "GYERMEK KERESÉSE";
            this.gyermekKereseseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.gyermekKereseseButton.UseVisualStyleBackColor = false;
            this.gyermekKereseseButton.Click += new System.EventHandler(this.gyermekKereseseButton_Click);
            // 
            // gyermekFelveteleButton
            // 
            this.gyermekFelveteleButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gyermekFelveteleButton.BackColor = System.Drawing.Color.Transparent;
            this.gyermekFelveteleButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("gyermekFelveteleButton.BackgroundImage")));
            this.gyermekFelveteleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.gyermekFelveteleButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.gyermekFelveteleButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.gyermekFelveteleButton.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gyermekFelveteleButton.ForeColor = System.Drawing.Color.Aquamarine;
            this.gyermekFelveteleButton.Location = new System.Drawing.Point(539, 30);
            this.gyermekFelveteleButton.Name = "gyermekFelveteleButton";
            this.gyermekFelveteleButton.Size = new System.Drawing.Size(150, 50);
            this.gyermekFelveteleButton.TabIndex = 15;
            this.gyermekFelveteleButton.Text = "GYERMEK FELVÉTELE";
            this.gyermekFelveteleButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.gyermekFelveteleButton.UseVisualStyleBackColor = false;
            this.gyermekFelveteleButton.Click += new System.EventHandler(this.gyermekFelveteleButton_Click);
            // 
            // csoportHozzaadButton
            // 
            this.csoportHozzaadButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.csoportHozzaadButton.BackColor = System.Drawing.Color.Transparent;
            this.csoportHozzaadButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("csoportHozzaadButton.BackgroundImage")));
            this.csoportHozzaadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.csoportHozzaadButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.csoportHozzaadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.csoportHozzaadButton.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.csoportHozzaadButton.ForeColor = System.Drawing.Color.Aquamarine;
            this.csoportHozzaadButton.Location = new System.Drawing.Point(326, 30);
            this.csoportHozzaadButton.Name = "csoportHozzaadButton";
            this.csoportHozzaadButton.Size = new System.Drawing.Size(190, 50);
            this.csoportHozzaadButton.TabIndex = 14;
            this.csoportHozzaadButton.Text = "CSOPORTOK HOZZÁADÁSA";
            this.csoportHozzaadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.csoportHozzaadButton.UseVisualStyleBackColor = false;
            this.csoportHozzaadButton.Click += new System.EventHandler(this.csoportHozzaadButton_Click);
            // 
            // intHozzaadButton
            // 
            this.intHozzaadButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.intHozzaadButton.BackColor = System.Drawing.Color.Transparent;
            this.intHozzaadButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("intHozzaadButton.BackgroundImage")));
            this.intHozzaadButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.intHozzaadButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.intHozzaadButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.intHozzaadButton.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.intHozzaadButton.ForeColor = System.Drawing.Color.Aquamarine;
            this.intHozzaadButton.Location = new System.Drawing.Point(112, 30);
            this.intHozzaadButton.Name = "intHozzaadButton";
            this.intHozzaadButton.Size = new System.Drawing.Size(190, 50);
            this.intHozzaadButton.TabIndex = 13;
            this.intHozzaadButton.Text = "INTÉZMÉNY HOZZÁADÁSA";
            this.intHozzaadButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.intHozzaadButton.UseVisualStyleBackColor = false;
            this.intHozzaadButton.Click += new System.EventHandler(this.intHozzaadButton_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.groupBox1.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.groupBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("groupBox1.BackgroundImage")));
            this.groupBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.groupBox1.Controls.Add(this.mentesButton);
            this.groupBox1.Controls.Add(this.HHHvagyHHErvenyesText);
            this.groupBox1.Controls.Add(this.hhVAGYhhhText);
            this.groupBox1.Controls.Add(this.gyVervenyesText);
            this.groupBox1.Controls.Add(this.szulIdoText);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.csoportKivalaszCombo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.gyVErvenyesLabel);
            this.groupBox1.Controls.Add(this.HHvagyHHHCheck);
            this.groupBox1.Controls.Add(this.gyVHatTextBox);
            this.groupBox1.Controls.Add(this.anyjaNeveTextBox);
            this.groupBox1.Controls.Add(this.omAzonMask);
            this.groupBox1.Controls.Add(this.gyermekNeveTextBox);
            this.groupBox1.Controls.Add(this.HervenyesLabel);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.groupBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.groupBox1.Location = new System.Drawing.Point(228, 98);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 406);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            // 
            // mentesButton
            // 
            this.mentesButton.Location = new System.Drawing.Point(636, 311);
            this.mentesButton.Name = "mentesButton";
            this.mentesButton.Size = new System.Drawing.Size(75, 23);
            this.mentesButton.TabIndex = 36;
            this.mentesButton.Text = "MENTÉS";
            this.mentesButton.UseVisualStyleBackColor = true;
            this.mentesButton.Visible = false;
            // 
            // HHHvagyHHErvenyesText
            // 
            this.HHHvagyHHErvenyesText.Location = new System.Drawing.Point(293, 310);
            this.HHHvagyHHErvenyesText.Name = "HHHvagyHHErvenyesText";
            this.HHHvagyHHErvenyesText.Size = new System.Drawing.Size(125, 20);
            this.HHHvagyHHErvenyesText.TabIndex = 10;
            this.HHHvagyHHErvenyesText.Visible = false;
            // 
            // hhVAGYhhhText
            // 
            this.hhVAGYhhhText.Location = new System.Drawing.Point(214, 284);
            this.hhVAGYhhhText.Name = "hhVAGYhhhText";
            this.hhVAGYhhhText.Size = new System.Drawing.Size(154, 20);
            this.hhVAGYhhhText.TabIndex = 9;
            this.hhVAGYhhhText.Visible = false;
            // 
            // gyVervenyesText
            // 
            this.gyVervenyesText.Location = new System.Drawing.Point(573, 224);
            this.gyVervenyesText.Name = "gyVervenyesText";
            this.gyVervenyesText.Size = new System.Drawing.Size(138, 20);
            this.gyVervenyesText.TabIndex = 7;
            this.gyVervenyesText.Visible = false;
            // 
            // szulIdoText
            // 
            this.szulIdoText.Location = new System.Drawing.Point(214, 114);
            this.szulIdoText.Name = "szulIdoText";
            this.szulIdoText.Size = new System.Drawing.Size(100, 20);
            this.szulIdoText.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.label8.ForeColor = System.Drawing.Color.Red;
            this.label8.Location = new System.Drawing.Point(323, 115);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(12, 16);
            this.label8.TabIndex = 35;
            this.label8.Text = "!";
            this.label8.Visible = false;
            // 
            // csoportKivalaszCombo
            // 
            this.csoportKivalaszCombo.FormattingEnabled = true;
            this.csoportKivalaszCombo.Location = new System.Drawing.Point(497, 78);
            this.csoportKivalaszCombo.Name = "csoportKivalaszCombo";
            this.csoportKivalaszCombo.Size = new System.Drawing.Size(135, 21);
            this.csoportKivalaszCombo.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(423, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 24);
            this.label7.TabIndex = 33;
            this.label7.Text = "CSOPORT:";
            // 
            // gyVErvenyesLabel
            // 
            this.gyVErvenyesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.gyVErvenyesLabel.AutoSize = true;
            this.gyVErvenyesLabel.BackColor = System.Drawing.Color.Transparent;
            this.gyVErvenyesLabel.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gyVErvenyesLabel.Location = new System.Drawing.Point(495, 224);
            this.gyVErvenyesLabel.Name = "gyVErvenyesLabel";
            this.gyVErvenyesLabel.Size = new System.Drawing.Size(77, 24);
            this.gyVErvenyesLabel.TabIndex = 31;
            this.gyVErvenyesLabel.Text = "ÉRVÉNYES:";
            this.gyVErvenyesLabel.Visible = false;
            // 
            // HHvagyHHHCheck
            // 
            this.HHvagyHHHCheck.AutoSize = true;
            this.HHvagyHHHCheck.Location = new System.Drawing.Point(214, 261);
            this.HHvagyHHHCheck.Name = "HHvagyHHHCheck";
            this.HHvagyHHHCheck.Size = new System.Drawing.Size(15, 14);
            this.HHvagyHHHCheck.TabIndex = 8;
            this.HHvagyHHHCheck.UseVisualStyleBackColor = true;
            // 
            // gyVHatTextBox
            // 
            this.gyVHatTextBox.Location = new System.Drawing.Point(323, 224);
            this.gyVHatTextBox.Name = "gyVHatTextBox";
            this.gyVHatTextBox.Size = new System.Drawing.Size(161, 20);
            this.gyVHatTextBox.TabIndex = 6;
            // 
            // anyjaNeveTextBox
            // 
            this.anyjaNeveTextBox.Location = new System.Drawing.Point(214, 185);
            this.anyjaNeveTextBox.Name = "anyjaNeveTextBox";
            this.anyjaNeveTextBox.Size = new System.Drawing.Size(179, 20);
            this.anyjaNeveTextBox.TabIndex = 5;
            // 
            // omAzonMask
            // 
            this.omAzonMask.Location = new System.Drawing.Point(214, 152);
            this.omAzonMask.Mask = "00000000000";
            this.omAzonMask.Name = "omAzonMask";
            this.omAzonMask.Size = new System.Drawing.Size(179, 20);
            this.omAzonMask.TabIndex = 4;
            // 
            // gyermekNeveTextBox
            // 
            this.gyermekNeveTextBox.Location = new System.Drawing.Point(214, 79);
            this.gyermekNeveTextBox.Name = "gyermekNeveTextBox";
            this.gyermekNeveTextBox.Size = new System.Drawing.Size(179, 20);
            this.gyermekNeveTextBox.TabIndex = 1;
            // 
            // HervenyesLabel
            // 
            this.HervenyesLabel.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.HervenyesLabel.AutoSize = true;
            this.HervenyesLabel.BackColor = System.Drawing.Color.Transparent;
            this.HervenyesLabel.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.HervenyesLabel.Location = new System.Drawing.Point(210, 310);
            this.HervenyesLabel.Name = "HervenyesLabel";
            this.HervenyesLabel.Size = new System.Drawing.Size(77, 24);
            this.HervenyesLabel.TabIndex = 21;
            this.HervenyesLabel.Text = "ÉRVÉNYES:";
            this.HervenyesLabel.Visible = false;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(80, 258);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 24);
            this.label6.TabIndex = 19;
            this.label6.Text = "HH vagy HHH:";
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(80, 224);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(237, 24);
            this.label5.TabIndex = 17;
            this.label5.Text = "GYV HATÁROZAT SZÁMA (HA VAN):";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(80, 79);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(110, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "GYERMEK NEVE:";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(80, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(108, 24);
            this.label2.TabIndex = 1;
            this.label2.Text = "SZÜLETÉSI IDŐ:";
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(80, 152);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 24);
            this.label3.TabIndex = 2;
            this.label3.Text = "OM AZONOSÍTÓ:";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(80, 185);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(93, 24);
            this.label4.TabIndex = 3;
            this.label4.Text = "ANYJA NEVE:";
            // 
            // szerkesztButton
            // 
            this.szerkesztButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.szerkesztButton.BackColor = System.Drawing.Color.Transparent;
            this.szerkesztButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("szerkesztButton.BackgroundImage")));
            this.szerkesztButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.szerkesztButton.Cursor = System.Windows.Forms.Cursors.Default;
            this.szerkesztButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.szerkesztButton.Font = new System.Drawing.Font("Myanmar Text", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.szerkesztButton.ForeColor = System.Drawing.Color.Aquamarine;
            this.szerkesztButton.Location = new System.Drawing.Point(12, 460);
            this.szerkesztButton.Name = "szerkesztButton";
            this.szerkesztButton.Size = new System.Drawing.Size(196, 44);
            this.szerkesztButton.TabIndex = 33;
            this.szerkesztButton.Text = "SZERKESZTÉS";
            this.szerkesztButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.szerkesztButton.UseVisualStyleBackColor = false;
            this.szerkesztButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // gyermekKeres
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(974, 516);
            this.Controls.Add(this.szerkesztButton);
            this.Controls.Add(this.csoportSelectCombo);
            this.Controls.Add(this.listView1);
            this.Controls.Add(this.gyermekKereseseButton);
            this.Controls.Add(this.gyermekFelveteleButton);
            this.Controls.Add(this.csoportHozzaadButton);
            this.Controls.Add(this.intHozzaadButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(990, 555);
            this.MinimumSize = new System.Drawing.Size(990, 555);
            this.Name = "gyermekKeres";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gyermek Keresése / Szerkesztése";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.gyermekKeres_FormClosing);
            this.Load += new System.EventHandler(this.gyermekKeres_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button gyermekKereseseButton;
        private System.Windows.Forms.Button gyermekFelveteleButton;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button csoportHozzaadButton;
        private System.Windows.Forms.Button intHozzaadButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox csoportKivalaszCombo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label gyVErvenyesLabel;
        private System.Windows.Forms.CheckBox HHvagyHHHCheck;
        private System.Windows.Forms.MaskedTextBox gyVHatTextBox;
        private System.Windows.Forms.TextBox anyjaNeveTextBox;
        private System.Windows.Forms.MaskedTextBox omAzonMask;
        private System.Windows.Forms.TextBox gyermekNeveTextBox;
        private System.Windows.Forms.Label HervenyesLabel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ToolStripMenuItem sugóToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menüToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem kezdőlapToolStripMenuItem;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.TextBox szulIdoText;
        private System.Windows.Forms.MaskedTextBox HHHvagyHHErvenyesText;
        private System.Windows.Forms.MaskedTextBox hhVAGYhhhText;
        private System.Windows.Forms.MaskedTextBox gyVervenyesText;
        private System.Windows.Forms.ComboBox csoportSelectCombo;
        private System.Windows.Forms.Button szerkesztButton;
        private System.Windows.Forms.Button mentesButton;
    }
}