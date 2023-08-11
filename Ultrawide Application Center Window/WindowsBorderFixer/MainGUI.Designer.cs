namespace WindowsBorderFixer {
    partial class MainGUI {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.cbxWindows = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnBordered = new System.Windows.Forms.Button();
            this.btnBorderless = new System.Windows.Forms.Button();
            this.btnMoveYTop = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.cbxProcessName = new System.Windows.Forms.ComboBox();
            this.cbxResolution = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cbxWindows
            // 
            this.cbxWindows.FormattingEnabled = true;
            this.cbxWindows.Location = new System.Drawing.Point(11, 38);
            this.cbxWindows.Name = "cbxWindows";
            this.cbxWindows.Size = new System.Drawing.Size(352, 21);
            this.cbxWindows.TabIndex = 0;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(11, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(354, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Refresh";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnBordered
            // 
            this.btnBordered.Location = new System.Drawing.Point(11, 122);
            this.btnBordered.Name = "btnBordered";
            this.btnBordered.Size = new System.Drawing.Size(174, 23);
            this.btnBordered.TabIndex = 2;
            this.btnBordered.Text = "Make Bordered";
            this.btnBordered.UseVisualStyleBackColor = true;
            this.btnBordered.Click += new System.EventHandler(this.btnBordered_Click);
            // 
            // btnBorderless
            // 
            this.btnBorderless.Location = new System.Drawing.Point(191, 122);
            this.btnBorderless.Name = "btnBorderless";
            this.btnBorderless.Size = new System.Drawing.Size(174, 23);
            this.btnBorderless.TabIndex = 4;
            this.btnBorderless.Text = "Make Borderless";
            this.btnBorderless.UseVisualStyleBackColor = true;
            this.btnBorderless.Click += new System.EventHandler(this.btnBorderless_Click);
            // 
            // btnMoveYTop
            // 
            this.btnMoveYTop.Location = new System.Drawing.Point(12, 151);
            this.btnMoveYTop.Name = "btnMoveYTop";
            this.btnMoveYTop.Size = new System.Drawing.Size(174, 23);
            this.btnMoveYTop.TabIndex = 5;
            this.btnMoveYTop.Text = "Resize && Move to Top";
            this.btnMoveYTop.UseVisualStyleBackColor = true;
            this.btnMoveYTop.Click += new System.EventHandler(this.btnMoveYTop_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(191, 149);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(174, 23);
            this.button2.TabIndex = 6;
            this.button2.Text = "Get Window Flags";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.btnGetWindowFlags_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(102, 180);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(174, 23);
            this.btnReset.TabIndex = 7;
            this.btnReset.Text = "Reset";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(102, 201);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(174, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Debug Btn";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.btnDebug_Click);
            // 
            // cbxProcessName
            // 
            this.cbxProcessName.FormattingEnabled = true;
            this.cbxProcessName.Items.AddRange(new object[] {
            "EscapeFromTarkov",
            "AnomalyDX11AVX    // Stalker Anomaly",
            "HogwartsLegacy",
            "ffxiv_dx11.exe        // FFXIV - DX11",
            "ffxiv_dx9.exe          // FFXIV - DX9"});
            this.cbxProcessName.Location = new System.Drawing.Point(11, 12);
            this.cbxProcessName.Name = "cbxProcessName";
            this.cbxProcessName.Size = new System.Drawing.Size(352, 21);
            this.cbxProcessName.TabIndex = 9;
            this.cbxProcessName.Text = "EscapeFromTarkov";
            // 
            // cbxResolution
            // 
            this.cbxResolution.FormattingEnabled = true;
            this.cbxResolution.Items.AddRange(new object[] {
            "1920x1080",
            "2560x1440",
            "3440x1440"});
            this.cbxResolution.Location = new System.Drawing.Point(109, 95);
            this.cbxResolution.Name = "cbxResolution";
            this.cbxResolution.Size = new System.Drawing.Size(256, 21);
            this.cbxResolution.TabIndex = 10;
            this.cbxResolution.Text = "2560x1440";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 98);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Target Resolution";
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(383, 235);
            this.Controls.Add(this.cbxResolution);
            this.Controls.Add(this.cbxProcessName);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.btnReset);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btnMoveYTop);
            this.Controls.Add(this.btnBorderless);
            this.Controls.Add(this.btnBordered);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbxWindows);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.Name = "MainGUI";
            this.Text = "Windows Borderless Centre";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbxWindows;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnBordered;
        private System.Windows.Forms.Button btnBorderless;
        private System.Windows.Forms.Button btnMoveYTop;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnReset;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.ComboBox cbxProcessName;
        private System.Windows.Forms.ComboBox cbxResolution;
        private System.Windows.Forms.Label label1;
    }
}

