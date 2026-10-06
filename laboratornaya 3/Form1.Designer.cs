namespace Lab1 {
  partial class Form1 {
    private System.ComponentModel.IContainer components = null;

    private System.Windows.Forms.MenuStrip menuStrip;
    private System.Windows.Forms.ToolStripMenuItem menuItemCalculate;
    private System.Windows.Forms.ToolStripMenuItem menuItemClear;
    private System.Windows.Forms.ToolStripMenuItem menuItemExit;

    private System.Windows.Forms.Label labelA;
    private System.Windows.Forms.Label labelB;
    private System.Windows.Forms.Label labelE;
    private System.Windows.Forms.Label labelFormula;
    private System.Windows.Forms.Label labelAnswerTitle;

    private System.Windows.Forms.TextBox textBoxA;
    private System.Windows.Forms.TextBox textBoxB;
    private System.Windows.Forms.TextBox textBoxE;
    private System.Windows.Forms.TextBox textBoxFormula;
    private System.Windows.Forms.TextBox textBoxAnswer;

    private System.Windows.Forms.PictureBox pictureBoxPlot;
    private System.Windows.Forms.StatusStrip statusStrip;
    private System.Windows.Forms.ToolStripStatusLabel statusLabel;

    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    private void InitializeComponent() {
      this.components = new System.ComponentModel.Container();

      this.menuStrip = new System.Windows.Forms.MenuStrip();
      this.menuItemCalculate = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemClear = new System.Windows.Forms.ToolStripMenuItem();
      this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();

      this.labelA = new System.Windows.Forms.Label();
      this.labelB = new System.Windows.Forms.Label();
      this.labelE = new System.Windows.Forms.Label();
      this.labelFormula = new System.Windows.Forms.Label();
      this.labelAnswerTitle = new System.Windows.Forms.Label();

      this.textBoxA = new System.Windows.Forms.TextBox();
      this.textBoxB = new System.Windows.Forms.TextBox();
      this.textBoxE = new System.Windows.Forms.TextBox();
      this.textBoxFormula = new System.Windows.Forms.TextBox();
      this.textBoxAnswer = new System.Windows.Forms.TextBox();

      this.pictureBoxPlot = new System.Windows.Forms.PictureBox();
      this.statusStrip = new System.Windows.Forms.StatusStrip();
      this.statusLabel = new System.Windows.Forms.ToolStripStatusLabel();

      this.menuStrip.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).BeginInit();
      this.statusStrip.SuspendLayout();
      this.SuspendLayout();

      this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.menuItemCalculate,
                this.menuItemClear,
                this.menuItemExit});
      this.menuStrip.Location = new System.Drawing.Point(0, 0);
      this.menuStrip.Name = "menuStrip";
      this.menuStrip.Size = new System.Drawing.Size(900, 24);
      this.menuStrip.TabIndex = 0;

      this.menuItemCalculate.Name = "menuItemCalculate";
      this.menuItemCalculate.Text = "Рассчитать";
      this.menuItemCalculate.Click += new System.EventHandler(this.MenuItemCalculate_Click);

      this.menuItemClear.Name = "menuItemClear";
      this.menuItemClear.Text = "Очистить";
      this.menuItemClear.Click += new System.EventHandler(this.MenuItemClear_Click);

      this.menuItemExit.Name = "menuItemExit";
      this.menuItemExit.Text = "Выход";
      this.menuItemExit.Click += new System.EventHandler(this.MenuItemExit_Click);

      this.labelA.AutoSize = true;
      this.labelA.Location = new System.Drawing.Point(15, 40);
      this.labelA.Name = "labelA";
      this.labelA.Size = new System.Drawing.Size(17, 13);
      this.labelA.Text = "a:";

      this.textBoxA.Location = new System.Drawing.Point(45, 37);
      this.textBoxA.Name = "textBoxA";
      this.textBoxA.Size = new System.Drawing.Size(100, 20);
      this.textBoxA.TabIndex = 1;
      this.textBoxA.Text = "0";

      this.labelB.AutoSize = true;
      this.labelB.Location = new System.Drawing.Point(165, 40);
      this.labelB.Name = "labelB";
      this.labelB.Size = new System.Drawing.Size(17, 13);
      this.labelB.Text = "b:";

      this.textBoxB.Location = new System.Drawing.Point(195, 37);
      this.textBoxB.Name = "textBoxB";
      this.textBoxB.Size = new System.Drawing.Size(100, 20);
      this.textBoxB.TabIndex = 2;
      this.textBoxB.Text = "3";

      this.labelE.AutoSize = true;
      this.labelE.Location = new System.Drawing.Point(315, 40);
      this.labelE.Name = "labelE";
      this.labelE.Size = new System.Drawing.Size(17, 13);
      this.labelE.Text = "e:";

      this.textBoxE.Location = new System.Drawing.Point(345, 37);
      this.textBoxE.Name = "textBoxE";
      this.textBoxE.Size = new System.Drawing.Size(100, 20);
      this.textBoxE.TabIndex = 3;
      this.textBoxE.Text = "0,0001";

      this.labelAnswerTitle.AutoSize = true;
      this.labelAnswerTitle.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
      this.labelAnswerTitle.ForeColor = System.Drawing.Color.Purple;
      this.labelAnswerTitle.Location = new System.Drawing.Point(480, 40);
      this.labelAnswerTitle.Name = "labelAnswerTitle";
      this.labelAnswerTitle.Size = new System.Drawing.Size(65, 15);
      this.labelAnswerTitle.Text = "Корень:";

      this.textBoxAnswer.BackColor = System.Drawing.Color.LightYellow;
      this.textBoxAnswer.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
      this.textBoxAnswer.ForeColor = System.Drawing.Color.DarkRed;
      this.textBoxAnswer.Location = new System.Drawing.Point(550, 37);
      this.textBoxAnswer.Name = "textBoxAnswer";
      this.textBoxAnswer.ReadOnly = true;
      this.textBoxAnswer.Size = new System.Drawing.Size(160, 22);
      this.textBoxAnswer.TabIndex = 4;
      this.textBoxAnswer.TabStop = false;
      this.textBoxAnswer.Text = "";

      this.labelFormula.AutoSize = true;
      this.labelFormula.Location = new System.Drawing.Point(15, 75);
      this.labelFormula.Name = "labelFormula";
      this.labelFormula.Size = new System.Drawing.Size(37, 13);
      this.labelFormula.Text = "f(x) =";

      this.textBoxFormula.Location = new System.Drawing.Point(60, 72);
      this.textBoxFormula.Name = "textBoxFormula";
      this.textBoxFormula.Size = new System.Drawing.Size(650, 20);
      this.textBoxFormula.TabIndex = 5;
      this.textBoxFormula.Text = "x^2+2*x-6";

      this.pictureBoxPlot.BackColor = System.Drawing.Color.White;
      this.pictureBoxPlot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBoxPlot.Location = new System.Drawing.Point(15, 105);
      this.pictureBoxPlot.Name = "pictureBoxPlot";
      this.pictureBoxPlot.Size = new System.Drawing.Size(860, 405);
      this.pictureBoxPlot.TabIndex = 6;
      this.pictureBoxPlot.TabStop = false;
      this.pictureBoxPlot.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxPlot_Paint);

      this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
                this.statusLabel});
      this.statusStrip.Location = new System.Drawing.Point(0, 520);
      this.statusStrip.Name = "statusStrip";
      this.statusStrip.Size = new System.Drawing.Size(900, 22);
      this.statusStrip.TabIndex = 7;

      this.statusLabel.Name = "statusLabel";
      this.statusLabel.Text = "Готово";

      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(900, 550);
      this.Controls.Add(this.menuStrip);
      this.Controls.Add(this.labelA);
      this.Controls.Add(this.textBoxA);
      this.Controls.Add(this.labelB);
      this.Controls.Add(this.textBoxB);
      this.Controls.Add(this.labelE);
      this.Controls.Add(this.textBoxE);
      this.Controls.Add(this.labelAnswerTitle);
      this.Controls.Add(this.textBoxAnswer);
      this.Controls.Add(this.labelFormula);
      this.Controls.Add(this.textBoxFormula);
      this.Controls.Add(this.pictureBoxPlot);
      this.Controls.Add(this.statusStrip);
      this.MainMenuStrip = this.menuStrip;
      this.Name = "Form1";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Лабораторная работа №3. Метод дихотомии";

      this.menuStrip.ResumeLayout(false);
      this.menuStrip.PerformLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPlot)).EndInit();
      this.statusStrip.ResumeLayout(false);
      this.statusStrip.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();
    }
  }
}