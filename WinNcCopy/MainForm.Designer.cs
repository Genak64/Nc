
namespace WinNcCopy
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.pb2DGrafics = new System.Windows.Forms.PictureBox();
            this.btnDraw = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialogLoad = new System.Windows.Forms.OpenFileDialog();
            this.lblCopyByX = new System.Windows.Forms.Label();
            this.lblCopyByY = new System.Windows.Forms.Label();
            this.numByX = new System.Windows.Forms.NumericUpDown();
            this.numByY = new System.Windows.Forms.NumericUpDown();
            this.groupCopyXY = new System.Windows.Forms.GroupBox();
            this.numOffset = new System.Windows.Forms.NumericUpDown();
            this.lblOffset = new System.Windows.Forms.Label();
            this.btnCopyApply = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb2DGrafics)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numByX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numByY)).BeginInit();
            this.groupCopyXY.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).BeginInit();
            this.SuspendLayout();
            // 
            // pb2DGrafics
            // 
            this.pb2DGrafics.Location = new System.Drawing.Point(188, 49);
            this.pb2DGrafics.Name = "pb2DGrafics";
            this.pb2DGrafics.Size = new System.Drawing.Size(778, 515);
            this.pb2DGrafics.TabIndex = 0;
            this.pb2DGrafics.TabStop = false;
            // 
            // btnDraw
            // 
            this.btnDraw.Location = new System.Drawing.Point(12, 12);
            this.btnDraw.Name = "btnDraw";
            this.btnDraw.Size = new System.Drawing.Size(75, 23);
            this.btnDraw.TabIndex = 1;
            this.btnDraw.Text = "Load file";
            this.btnDraw.UseVisualStyleBackColor = true;
            this.btnDraw.Click += new System.EventHandler(this.btnDraw_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(188, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // openFileDialogLoad
            // 
            this.openFileDialogLoad.FileName = "openFileDialogLoad";
            // 
            // lblCopyByX
            // 
            this.lblCopyByX.AutoSize = true;
            this.lblCopyByX.Location = new System.Drawing.Point(20, 24);
            this.lblCopyByX.Name = "lblCopyByX";
            this.lblCopyByX.Size = new System.Drawing.Size(14, 15);
            this.lblCopyByX.TabIndex = 3;
            this.lblCopyByX.Text = "X";
            // 
            // lblCopyByY
            // 
            this.lblCopyByY.AutoSize = true;
            this.lblCopyByY.Location = new System.Drawing.Point(20, 55);
            this.lblCopyByY.Name = "lblCopyByY";
            this.lblCopyByY.Size = new System.Drawing.Size(14, 15);
            this.lblCopyByY.TabIndex = 4;
            this.lblCopyByY.Text = "Y";
            // 
            // numByX
            // 
            this.numByX.Location = new System.Drawing.Point(40, 22);
            this.numByX.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numByX.Name = "numByX";
            this.numByX.Size = new System.Drawing.Size(55, 23);
            this.numByX.TabIndex = 5;
            this.numByX.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // numByY
            // 
            this.numByY.Location = new System.Drawing.Point(40, 53);
            this.numByY.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numByY.Name = "numByY";
            this.numByY.Size = new System.Drawing.Size(55, 23);
            this.numByY.TabIndex = 6;
            this.numByY.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // groupCopyXY
            // 
            this.groupCopyXY.Controls.Add(this.numOffset);
            this.groupCopyXY.Controls.Add(this.lblOffset);
            this.groupCopyXY.Controls.Add(this.btnCopyApply);
            this.groupCopyXY.Controls.Add(this.numByX);
            this.groupCopyXY.Controls.Add(this.numByY);
            this.groupCopyXY.Controls.Add(this.lblCopyByX);
            this.groupCopyXY.Controls.Add(this.lblCopyByY);
            this.groupCopyXY.Location = new System.Drawing.Point(12, 49);
            this.groupCopyXY.Name = "groupCopyXY";
            this.groupCopyXY.Size = new System.Drawing.Size(128, 169);
            this.groupCopyXY.TabIndex = 7;
            this.groupCopyXY.TabStop = false;
            this.groupCopyXY.Text = "Copy by X or/and Y";
            // 
            // numOffset
            // 
            this.numOffset.DecimalPlaces = 2;
            this.numOffset.Location = new System.Drawing.Point(24, 102);
            this.numOffset.Name = "numOffset";
            this.numOffset.Size = new System.Drawing.Size(71, 23);
            this.numOffset.TabIndex = 9;
            // 
            // lblOffset
            // 
            this.lblOffset.AutoSize = true;
            this.lblOffset.Location = new System.Drawing.Point(20, 84);
            this.lblOffset.Name = "lblOffset";
            this.lblOffset.Size = new System.Drawing.Size(39, 15);
            this.lblOffset.TabIndex = 8;
            this.lblOffset.Text = "Offset";
            // 
            // btnCopyApply
            // 
            this.btnCopyApply.Location = new System.Drawing.Point(24, 140);
            this.btnCopyApply.Name = "btnCopyApply";
            this.btnCopyApply.Size = new System.Drawing.Size(75, 23);
            this.btnCopyApply.TabIndex = 7;
            this.btnCopyApply.Text = "Apply";
            this.btnCopyApply.UseVisualStyleBackColor = true;
            this.btnCopyApply.Click += new System.EventHandler(this.btnCopyApply_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 576);
            this.Controls.Add(this.groupCopyXY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDraw);
            this.Controls.Add(this.pb2DGrafics);
            this.Name = "MainForm";
            this.Text = "NC";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb2DGrafics)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numByX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numByY)).EndInit();
            this.groupCopyXY.ResumeLayout(false);
            this.groupCopyXY.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numOffset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pb2DGrafics;
        private System.Windows.Forms.Button btnDraw;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.OpenFileDialog openFileDialogLoad;
        private System.Windows.Forms.Label lblCopyByX;
        private System.Windows.Forms.Label lblCopyByY;
        private System.Windows.Forms.NumericUpDown numByX;
        private System.Windows.Forms.NumericUpDown numByY;
        private System.Windows.Forms.GroupBox groupCopyXY;
        private System.Windows.Forms.NumericUpDown numOffset;
        private System.Windows.Forms.Label lblOffset;
        private System.Windows.Forms.Button btnCopyApply;
    }
}

