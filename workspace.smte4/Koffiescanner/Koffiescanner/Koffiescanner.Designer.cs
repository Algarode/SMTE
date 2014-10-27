namespace Koffiescanner
{
    partial class Koffiescanner
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.bestandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afsluitenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.top5OphalenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btFetchPlaces = new System.Windows.Forms.Button();
            this.btFetchLocations = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPlaces = new System.Windows.Forms.TabPage();
            this.lvPlaces = new System.Windows.Forms.ListView();
            this.Plaats = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabCoffeelocations = new System.Windows.Forms.TabPage();
            this.lvCoffeelocations = new System.Windows.Forms.ListView();
            this.Rank = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Naam = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adres = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Telefoonnr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cijfer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lstbxFeedback = new System.Windows.Forms.ListBox();
            this.Stad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.menuStrip1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPlaces.SuspendLayout();
            this.tabCoffeelocations.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bestandToolStripMenuItem,
            this.extraToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(978, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // bestandToolStripMenuItem
            // 
            this.bestandToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afsluitenToolStripMenuItem});
            this.bestandToolStripMenuItem.Name = "bestandToolStripMenuItem";
            this.bestandToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.bestandToolStripMenuItem.Text = "Bestand";
            // 
            // afsluitenToolStripMenuItem
            // 
            this.afsluitenToolStripMenuItem.Name = "afsluitenToolStripMenuItem";
            this.afsluitenToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.afsluitenToolStripMenuItem.Text = "Afsluiten";
            this.afsluitenToolStripMenuItem.Click += new System.EventHandler(this.afsluitenToolStripMenuItem_Click);
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.top5OphalenToolStripMenuItem});
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // top5OphalenToolStripMenuItem
            // 
            this.top5OphalenToolStripMenuItem.Name = "top5OphalenToolStripMenuItem";
            this.top5OphalenToolStripMenuItem.Size = new System.Drawing.Size(150, 22);
            this.top5OphalenToolStripMenuItem.Text = "Top 5 ophalen";
            this.top5OphalenToolStripMenuItem.Click += new System.EventHandler(this.top5OphalenToolStripMenuItem_Click);
            // 
            // btFetchPlaces
            // 
            this.btFetchPlaces.Location = new System.Drawing.Point(13, 38);
            this.btFetchPlaces.Name = "btFetchPlaces";
            this.btFetchPlaces.Size = new System.Drawing.Size(193, 23);
            this.btFetchPlaces.TabIndex = 1;
            this.btFetchPlaces.Text = "Haal plaatsen op";
            this.btFetchPlaces.UseVisualStyleBackColor = true;
            this.btFetchPlaces.Click += new System.EventHandler(this.btFetchPlaces_Click);
            // 
            // btFetchLocations
            // 
            this.btFetchLocations.Location = new System.Drawing.Point(13, 67);
            this.btFetchLocations.Name = "btFetchLocations";
            this.btFetchLocations.Size = new System.Drawing.Size(193, 23);
            this.btFetchLocations.TabIndex = 2;
            this.btFetchLocations.Text = "Haal koffielocaties op";
            this.btFetchLocations.UseVisualStyleBackColor = true;
            this.btFetchLocations.Click += new System.EventHandler(this.btFetchLocations_Click);
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPlaces);
            this.tabControl.Controls.Add(this.tabCoffeelocations);
            this.tabControl.Location = new System.Drawing.Point(212, 27);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(754, 469);
            this.tabControl.TabIndex = 3;
            // 
            // tabPlaces
            // 
            this.tabPlaces.Controls.Add(this.lvPlaces);
            this.tabPlaces.Location = new System.Drawing.Point(4, 22);
            this.tabPlaces.Name = "tabPlaces";
            this.tabPlaces.Padding = new System.Windows.Forms.Padding(3);
            this.tabPlaces.Size = new System.Drawing.Size(746, 443);
            this.tabPlaces.TabIndex = 0;
            this.tabPlaces.Text = "Plaatsen";
            this.tabPlaces.UseVisualStyleBackColor = true;
            // 
            // lvPlaces
            // 
            this.lvPlaces.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Plaats});
            this.lvPlaces.Location = new System.Drawing.Point(7, 7);
            this.lvPlaces.Name = "lvPlaces";
            this.lvPlaces.Size = new System.Drawing.Size(733, 430);
            this.lvPlaces.TabIndex = 0;
            this.lvPlaces.UseCompatibleStateImageBehavior = false;
            this.lvPlaces.View = System.Windows.Forms.View.Details;
            // 
            // Plaats
            // 
            this.Plaats.Text = "Plaats";
            this.Plaats.Width = 200;
            // 
            // tabCoffeelocations
            // 
            this.tabCoffeelocations.Controls.Add(this.lvCoffeelocations);
            this.tabCoffeelocations.Location = new System.Drawing.Point(4, 22);
            this.tabCoffeelocations.Name = "tabCoffeelocations";
            this.tabCoffeelocations.Padding = new System.Windows.Forms.Padding(3);
            this.tabCoffeelocations.Size = new System.Drawing.Size(746, 443);
            this.tabCoffeelocations.TabIndex = 1;
            this.tabCoffeelocations.Text = "Koffielocaties";
            this.tabCoffeelocations.UseVisualStyleBackColor = true;
            // 
            // lvCoffeelocations
            // 
            this.lvCoffeelocations.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Rank,
            this.Naam,
            this.Adres,
            this.Stad,
            this.Telefoonnr,
            this.Cijfer});
            this.lvCoffeelocations.Location = new System.Drawing.Point(7, 7);
            this.lvCoffeelocations.Name = "lvCoffeelocations";
            this.lvCoffeelocations.Size = new System.Drawing.Size(733, 430);
            this.lvCoffeelocations.TabIndex = 0;
            this.lvCoffeelocations.UseCompatibleStateImageBehavior = false;
            this.lvCoffeelocations.View = System.Windows.Forms.View.Details;
            // 
            // Rank
            // 
            this.Rank.Text = "Rank";
            // 
            // Naam
            // 
            this.Naam.Text = "Naam";
            this.Naam.Width = 150;
            // 
            // Adres
            // 
            this.Adres.Text = "Adres";
            this.Adres.Width = 180;
            // 
            // Telefoonnr
            // 
            this.Telefoonnr.Text = "Telefoonnr";
            this.Telefoonnr.Width = 150;
            // 
            // Cijfer
            // 
            this.Cijfer.Text = "Cijfer";
            this.Cijfer.Width = 50;
            // 
            // lstbxFeedback
            // 
            this.lstbxFeedback.FormattingEnabled = true;
            this.lstbxFeedback.Location = new System.Drawing.Point(13, 96);
            this.lstbxFeedback.Name = "lstbxFeedback";
            this.lstbxFeedback.Size = new System.Drawing.Size(193, 394);
            this.lstbxFeedback.TabIndex = 4;
            // 
            // Stad
            // 
            this.Stad.Text = "Stad";
            this.Stad.Width = 100;
            // 
            // Koffiescanner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 508);
            this.Controls.Add(this.lstbxFeedback);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.btFetchLocations);
            this.Controls.Add(this.btFetchPlaces);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Koffiescanner";
            this.Text = "Koffiescanner";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabPlaces.ResumeLayout(false);
            this.tabCoffeelocations.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem bestandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afsluitenToolStripMenuItem;
        private System.Windows.Forms.Button btFetchPlaces;
        private System.Windows.Forms.Button btFetchLocations;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPlaces;
        private System.Windows.Forms.TabPage tabCoffeelocations;
        private System.Windows.Forms.ListBox lstbxFeedback;
        private System.Windows.Forms.ListView lvPlaces;
        private System.Windows.Forms.ColumnHeader Plaats;
        private System.Windows.Forms.ListView lvCoffeelocations;
        private System.Windows.Forms.ColumnHeader Rank;
        private System.Windows.Forms.ColumnHeader Naam;
        private System.Windows.Forms.ColumnHeader Adres;
        private System.Windows.Forms.ColumnHeader Telefoonnr;
        private System.Windows.Forms.ColumnHeader Cijfer;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem top5OphalenToolStripMenuItem;
        private System.Windows.Forms.ColumnHeader Stad;
    }
}

