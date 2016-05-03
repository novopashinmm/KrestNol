namespace Krestiki
{
    partial class KrestikiGame
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.менюToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.новаяИграToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.выходToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Pole = new System.Windows.Forms.PictureBox();
            this.режимИгрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.игрокаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.противКомпьютераToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pole)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.менюToolStripMenuItem,
            this.режимИгрыToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(345, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // менюToolStripMenuItem
            // 
            this.менюToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.новаяИграToolStripMenuItem,
            this.toolStripSeparator1,
            this.выходToolStripMenuItem});
            this.менюToolStripMenuItem.Name = "менюToolStripMenuItem";
            this.менюToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.менюToolStripMenuItem.Text = "Меню";
            // 
            // новаяИграToolStripMenuItem
            // 
            this.новаяИграToolStripMenuItem.Name = "новаяИграToolStripMenuItem";
            this.новаяИграToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.новаяИграToolStripMenuItem.Text = "Новая игра";
            this.новаяИграToolStripMenuItem.Click += new System.EventHandler(this.новаяИграToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // выходToolStripMenuItem
            // 
            this.выходToolStripMenuItem.Name = "выходToolStripMenuItem";
            this.выходToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.выходToolStripMenuItem.Text = "Выход";
            this.выходToolStripMenuItem.Click += new System.EventHandler(this.выходToolStripMenuItem_Click);
            // 
            // Pole
            // 
            this.Pole.BackgroundImage = global::Krestiki.Properties.Resources.Game;
            this.Pole.Location = new System.Drawing.Point(51, 47);
            this.Pole.Name = "Pole";
            this.Pole.Size = new System.Drawing.Size(240, 238);
            this.Pole.TabIndex = 0;
            this.Pole.TabStop = false;
            this.Pole.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Pole_MouseClick);
            // 
            // режимИгрыToolStripMenuItem
            // 
            this.режимИгрыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.игрокаToolStripMenuItem,
            this.противКомпьютераToolStripMenuItem});
            this.режимИгрыToolStripMenuItem.Name = "режимИгрыToolStripMenuItem";
            this.режимИгрыToolStripMenuItem.Size = new System.Drawing.Size(79, 20);
            this.режимИгрыToolStripMenuItem.Text = "Режим игры";
            // 
            // игрокаToolStripMenuItem
            // 
            this.игрокаToolStripMenuItem.Name = "игрокаToolStripMenuItem";
            this.игрокаToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.игрокаToolStripMenuItem.Text = "2 игрока";
            this.игрокаToolStripMenuItem.Click += new System.EventHandler(this.игрокаToolStripMenuItem_Click);
            // 
            // противКомпьютераToolStripMenuItem
            // 
            this.противКомпьютераToolStripMenuItem.Name = "противКомпьютераToolStripMenuItem";
            this.противКомпьютераToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.противКомпьютераToolStripMenuItem.Text = "Против компьютера";
            this.противКомпьютераToolStripMenuItem.Click += new System.EventHandler(this.противКомпьютераToolStripMenuItem_Click);
            // 
            // KrestikiGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(345, 329);
            this.Controls.Add(this.Pole);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(353, 356);
            this.MinimumSize = new System.Drawing.Size(353, 356);
            this.Name = "KrestikiGame";
            this.Text = "Крестики Нолики";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Pole)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox Pole;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem менюToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem новаяИграToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem выходToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem режимИгрыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem игрокаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem противКомпьютераToolStripMenuItem;
    }
}

