namespace Server_Installer_Forms
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.Amx183DevBox = new System.Windows.Forms.CheckBox();
            this.buttonAccept = new System.Windows.Forms.Button();
            this.metamodBox = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageAmx = new System.Windows.Forms.TabPage();
            this.Amx182DevBox = new System.Windows.Forms.CheckBox();
            this.Amx182Box = new System.Windows.Forms.CheckBox();
            this.tabPageMetamod = new System.Windows.Forms.TabPage();
            this.tabControl1.SuspendLayout();
            this.tabPageAmx.SuspendLayout();
            this.tabPageMetamod.SuspendLayout();
            this.SuspendLayout();
            // 
            // Amx183DevBox
            // 
            this.Amx183DevBox.AutoSize = true;
            this.Amx183DevBox.Location = new System.Drawing.Point(13, 53);
            this.Amx183DevBox.Name = "Amx183DevBox";
            this.Amx183DevBox.Size = new System.Drawing.Size(131, 17);
            this.Amx183DevBox.TabIndex = 0;
            this.Amx183DevBox.Text = "AMX Mod X 1.8.3 dev";
            this.Amx183DevBox.UseVisualStyleBackColor = true;
            this.Amx183DevBox.CheckedChanged += new System.EventHandler(this.Amx183DevBox_CheckedChanged);
            // 
            // buttonAccept
            // 
            this.buttonAccept.Location = new System.Drawing.Point(21, 118);
            this.buttonAccept.Name = "buttonAccept";
            this.buttonAccept.Size = new System.Drawing.Size(124, 23);
            this.buttonAccept.TabIndex = 1;
            this.buttonAccept.Text = "Начать установку";
            this.buttonAccept.UseVisualStyleBackColor = true;
            this.buttonAccept.Click += new System.EventHandler(this.ButtonAccept_Click);
            // 
            // metamodBox
            // 
            this.metamodBox.AutoSize = true;
            this.metamodBox.Location = new System.Drawing.Point(8, 6);
            this.metamodBox.Name = "metamodBox";
            this.metamodBox.Size = new System.Drawing.Size(70, 17);
            this.metamodBox.TabIndex = 2;
            this.metamodBox.Text = "Metamod";
            this.metamodBox.UseVisualStyleBackColor = true;
            this.metamodBox.CheckedChanged += new System.EventHandler(this.MetamodBox_CheckedChanged);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageAmx);
            this.tabControl1.Controls.Add(this.tabPageMetamod);
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(171, 103);
            this.tabControl1.TabIndex = 3;
            // 
            // tabPageAmx
            // 
            this.tabPageAmx.Controls.Add(this.Amx182DevBox);
            this.tabPageAmx.Controls.Add(this.Amx182Box);
            this.tabPageAmx.Controls.Add(this.Amx183DevBox);
            this.tabPageAmx.Location = new System.Drawing.Point(4, 22);
            this.tabPageAmx.Name = "tabPageAmx";
            this.tabPageAmx.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAmx.Size = new System.Drawing.Size(163, 77);
            this.tabPageAmx.TabIndex = 0;
            this.tabPageAmx.Text = "AMX Mod X";
            this.tabPageAmx.UseVisualStyleBackColor = true;
            // 
            // Amx182DevBox
            // 
            this.Amx182DevBox.AutoSize = true;
            this.Amx182DevBox.Location = new System.Drawing.Point(13, 33);
            this.Amx182DevBox.Name = "Amx182DevBox";
            this.Amx182DevBox.Size = new System.Drawing.Size(131, 17);
            this.Amx182DevBox.TabIndex = 2;
            this.Amx182DevBox.Text = "AMX Mod X 1.8.2 dev";
            this.Amx182DevBox.UseVisualStyleBackColor = true;
            this.Amx182DevBox.CheckedChanged += new System.EventHandler(this.Amx182DevBox_CheckedChanged);
            // 
            // Amx182Box
            // 
            this.Amx182Box.AutoSize = true;
            this.Amx182Box.Location = new System.Drawing.Point(13, 13);
            this.Amx182Box.Name = "Amx182Box";
            this.Amx182Box.Size = new System.Drawing.Size(110, 17);
            this.Amx182Box.TabIndex = 1;
            this.Amx182Box.Text = "AMX Mod X 1.8.2";
            this.Amx182Box.UseVisualStyleBackColor = true;
            this.Amx182Box.CheckedChanged += new System.EventHandler(this.Amx182Box_CheckedChanged);
            // 
            // tabPageMetamod
            // 
            this.tabPageMetamod.Controls.Add(this.metamodBox);
            this.tabPageMetamod.Location = new System.Drawing.Point(4, 22);
            this.tabPageMetamod.Name = "tabPageMetamod";
            this.tabPageMetamod.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageMetamod.Size = new System.Drawing.Size(163, 77);
            this.tabPageMetamod.TabIndex = 1;
            this.tabPageMetamod.Text = "Metamod";
            this.tabPageMetamod.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(172, 158);
            this.Controls.Add(this.buttonAccept);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tabControl1.ResumeLayout(false);
            this.tabPageAmx.ResumeLayout(false);
            this.tabPageAmx.PerformLayout();
            this.tabPageMetamod.ResumeLayout(false);
            this.tabPageMetamod.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.CheckBox Amx183DevBox;
        private System.Windows.Forms.Button buttonAccept;
        private System.Windows.Forms.CheckBox metamodBox;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageAmx;
        private System.Windows.Forms.TabPage tabPageMetamod;
        private System.Windows.Forms.CheckBox Amx182Box;
        private System.Windows.Forms.CheckBox Amx182DevBox;
    }
}

