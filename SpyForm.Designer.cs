
namespace SPY
{
    partial class SpyForm
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
            this.tvChildHwnd = new System.Windows.Forms.TreeView();
            this.btnSend = new System.Windows.Forms.Button();
            this.txtHwndId = new System.Windows.Forms.TextBox();
            this.txtClass = new System.Windows.Forms.TextBox();
            this.txtCaption = new System.Windows.Forms.TextBox();
            this.txtCommander = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lvSaveList = new System.Windows.Forms.ListView();
            this.label2 = new System.Windows.Forms.Label();
            this.lvCommands = new System.Windows.Forms.ListView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoCaption = new System.Windows.Forms.RadioButton();
            this.rdoForeground = new System.Windows.Forms.RadioButton();
            this.label3 = new System.Windows.Forms.Label();
            this.lblRamp = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvChildHwnd
            // 
            this.tvChildHwnd.Location = new System.Drawing.Point(12, 78);
            this.tvChildHwnd.Name = "tvChildHwnd";
            this.tvChildHwnd.Size = new System.Drawing.Size(579, 344);
            this.tvChildHwnd.TabIndex = 0;
            this.tvChildHwnd.DoubleClick += new System.EventHandler(this.tvChildHwnd_DoubleClick);
            // 
            // btnSend
            // 
            this.btnSend.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSend.Location = new System.Drawing.Point(497, 542);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(94, 29);
            this.btnSend.TabIndex = 1;
            this.btnSend.Text = "Send";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // txtHwndId
            // 
            this.txtHwndId.Location = new System.Drawing.Point(12, 12);
            this.txtHwndId.Name = "txtHwndId";
            this.txtHwndId.Size = new System.Drawing.Size(125, 27);
            this.txtHwndId.TabIndex = 2;
            // 
            // txtClass
            // 
            this.txtClass.Location = new System.Drawing.Point(143, 12);
            this.txtClass.Name = "txtClass";
            this.txtClass.Size = new System.Drawing.Size(230, 27);
            this.txtClass.TabIndex = 2;
            // 
            // txtCaption
            // 
            this.txtCaption.Location = new System.Drawing.Point(12, 45);
            this.txtCaption.Name = "txtCaption";
            this.txtCaption.Size = new System.Drawing.Size(361, 27);
            this.txtCaption.TabIndex = 2;
            this.txtCaption.TextChanged += new System.EventHandler(this.txtCaption_TextChanged);
            // 
            // txtCommander
            // 
            this.txtCommander.Location = new System.Drawing.Point(12, 459);
            this.txtCommander.Multiline = true;
            this.txtCommander.Name = "txtCommander";
            this.txtCommander.Size = new System.Drawing.Size(579, 77);
            this.txtCommander.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("나눔스퀘어 ExtraBold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 439);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "Native Method";
            // 
            // lvSaveList
            // 
            this.lvSaveList.HideSelection = false;
            this.lvSaveList.Location = new System.Drawing.Point(597, 12);
            this.lvSaveList.Name = "lvSaveList";
            this.lvSaveList.Size = new System.Drawing.Size(471, 410);
            this.lvSaveList.TabIndex = 5;
            this.lvSaveList.UseCompatibleStateImageBehavior = false;
            this.lvSaveList.DoubleClick += new System.EventHandler(this.lvSaveList_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("나눔스퀘어", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(597, 425);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Save - {Shift} + {A} ";
            // 
            // lvCommands
            // 
            this.lvCommands.HideSelection = false;
            this.lvCommands.Location = new System.Drawing.Point(597, 459);
            this.lvCommands.Name = "lvCommands";
            this.lvCommands.Size = new System.Drawing.Size(471, 77);
            this.lvCommands.TabIndex = 6;
            this.lvCommands.UseCompatibleStateImageBehavior = false;
            this.lvCommands.DoubleClick += new System.EventHandler(this.lvCommands_DoubleClick);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdoCaption);
            this.groupBox1.Controls.Add(this.rdoForeground);
            this.groupBox1.Location = new System.Drawing.Point(379, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(212, 60);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Type";
            // 
            // rdoCaption
            // 
            this.rdoCaption.AutoSize = true;
            this.rdoCaption.Location = new System.Drawing.Point(118, 26);
            this.rdoCaption.Name = "rdoCaption";
            this.rdoCaption.Size = new System.Drawing.Size(84, 24);
            this.rdoCaption.TabIndex = 0;
            this.rdoCaption.TabStop = true;
            this.rdoCaption.Text = "Caption";
            this.rdoCaption.UseVisualStyleBackColor = true;
            this.rdoCaption.CheckedChanged += new System.EventHandler(this.rdoCaption_CheckedChanged);
            // 
            // rdoForeground
            // 
            this.rdoForeground.AutoSize = true;
            this.rdoForeground.Location = new System.Drawing.Point(6, 26);
            this.rdoForeground.Name = "rdoForeground";
            this.rdoForeground.Size = new System.Drawing.Size(109, 24);
            this.rdoForeground.TabIndex = 0;
            this.rdoForeground.TabStop = true;
            this.rdoForeground.Text = "Foreground";
            this.rdoForeground.UseVisualStyleBackColor = true;
            this.rdoForeground.CheckedChanged += new System.EventHandler(this.rdoCaption_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("나눔스퀘어", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(597, 554);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 17);
            this.label3.TabIndex = 4;
            this.label3.Text = "or {Enter}";
            // 
            // lblRamp
            // 
            this.lblRamp.AutoSize = true;
            this.lblRamp.BackColor = System.Drawing.Color.LightGray;
            this.lblRamp.Location = new System.Drawing.Point(114, 15);
            this.lblRamp.Name = "lblRamp";
            this.lblRamp.Size = new System.Drawing.Size(19, 20);
            this.lblRamp.TabIndex = 8;
            this.lblRamp.Text = "  ";
            // 
            // SpyForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1080, 583);
            this.Controls.Add(this.lblRamp);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvCommands);
            this.Controls.Add(this.lvSaveList);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCommander);
            this.Controls.Add(this.txtCaption);
            this.Controls.Add(this.txtClass);
            this.Controls.Add(this.txtHwndId);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.tvChildHwnd);
            this.Name = "SpyForm";
            this.Text = "SPY";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvChildHwnd;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.TextBox txtHwndId;
        private System.Windows.Forms.TextBox txtClass;
        private System.Windows.Forms.TextBox txtCaption;
        private System.Windows.Forms.TextBox txtCommander;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView lvSaveList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListView lvCommands;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoCaption;
        private System.Windows.Forms.RadioButton rdoForeground;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblRamp;
    }
}

