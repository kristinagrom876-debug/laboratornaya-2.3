using System;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Lab1 {
  public partial class Form1 : Form {
    private Func<double, double> currentFunction;
    private double currentRoot;
    private bool hasResult;
    private double currentA;
    private double currentB;

    public Form1() {
      InitializeComponent();
      currentFunction = null;
      hasResult = false;
    }

    private void MenuItemCalculate_Click(object sender, EventArgs e) {
      double a;
      double b;
      double eps;

      if (!TryReadNumber(textBoxA.Text, "a", out a)) return;
      if (!TryReadNumber(textBoxB.Text, "b", out b)) return;
      if (!TryReadNumber(textBoxE.Text, "e", out eps)) return;

      if (eps <= 0) {
        MessageBox.Show("Точность e должна быть больше нуля.");
        return;
      }

      if (a >= b) {
        MessageBox.Show("Число a должно быть меньше b.");
        return;
      }

      Func<double, double> f;

      try {
        f = FunctionParser.Parse(textBoxFormula.Text);
      } catch (Exception ex) {
        MessageBox.Show("Ошибка в формуле: " + ex.Message);
        return;
      }

      double root;
      bool found = Dichotomy.FindRoot(f, a, b, eps, out root);

      currentFunction = f;
      currentA = a;
      currentB = b;
      hasResult = found;

      if (found) {
        currentRoot = root;
      } else {
        currentRoot = 0;
      }

      pictureBoxPlot.Invalidate();

      if (found) {
        int digits = CountDigits(eps);
        string answerText = root.ToString("F" + digits);
        string statusText = "Корень: x = " + answerText;

        textBoxAnswer.Text = answerText;
        statusLabel.Text = statusText;
        MessageBox.Show(statusText);
      } else {
        string statusText = "Корень на интервале [" + a + "; " + b + "] не найден.";

        textBoxAnswer.Text = "не найден";
        statusLabel.Text = statusText;
        MessageBox.Show(statusText);
      }
    }

    private void MenuItemClear_Click(object sender, EventArgs e) {
      textBoxA.Text = "";
      textBoxB.Text = "";
      textBoxE.Text = "";
      textBoxFormula.Text = "";
      textBoxAnswer.Text = "";
      statusLabel.Text = "Готово";

      currentFunction = null;
      hasResult = false;
      pictureBoxPlot.Invalidate();
    }

    private void MenuItemExit_Click(object sender, EventArgs e) {
      Close();
    }

    private int CountDigits(double value) {
      int digits = 0;
      double current = value;

      while (current < 1 && digits < 10) {
        current = current * 10;
        digits++;
      }

      if (digits < 1) digits = 1;

      return digits;
    }

    private bool TryReadNumber(string text, string name, out double value) {
      value = 0;

      if (string.IsNullOrWhiteSpace(text)) {
        MessageBox.Show("Поле " + name + " пустое.");
        return false;
      }

      string fixedText = text.Trim().Replace(',', '.');

      if (!double.TryParse(fixedText, NumberStyles.Float, CultureInfo.InvariantCulture, out value)) {
        MessageBox.Show("Поле " + name + " — не число.");
        return false;
      }

      return true;
    }

    private void PictureBoxPlot_Paint(object sender, PaintEventArgs e) {
      Graphics g = e.Graphics;

      if (currentFunction == null) {
        g.DrawString("Введите данные и нажмите «Рассчитать».",
            new Font("Arial", 12), Brushes.Gray, 20, 20);
        return;
      }

      int width = pictureBoxPlot.Width;
      int height = pictureBoxPlot.Height;

      int leftPad = 40;
      int rightPad = 20;
      int topPad = 20;
      int bottomPad = 30;

      int plotWidth = width - leftPad - rightPad;
      int plotHeight = height - topPad - bottomPad;

      if (plotWidth < 50 || plotHeight < 50) return;

      double margin = (currentB - currentA) * 0.1;
      double xMin = currentA - margin;
      double xMax = currentB + margin;

      double yMin = double.MaxValue;
      double yMax = double.MinValue;

      int steps = 500;
      double dx = (xMax - xMin) / steps;

      for (int i = 0; i <= steps; i++) {
        double x = xMin + i * dx;
        double y = Dichotomy.FunctionValue(currentFunction, x);

        if (double.IsNaN(y)) continue;

        if (y < yMin) yMin = y;
        if (y > yMax) yMax = y;
      }

      if (yMin == double.MaxValue || yMax == double.MinValue) return;

      double yMargin = (yMax - yMin) * 0.1;
      if (yMargin < 0.0001) yMargin = 1;

      yMin = yMin - yMargin;
      yMax = yMax + yMargin;

      Func<double, float> toX = x =>
          (float)(leftPad + (x - xMin) / (xMax - xMin) * plotWidth);

      Func<double, float> toY = y =>
          (float)(topPad + plotHeight - (y - yMin) / (yMax - yMin) * plotHeight);

      Pen axisPen = new Pen(Color.Black, 2);

      float axisY = toY(0);
      float axisX = toX(0);

      if (axisY < topPad) axisY = topPad;
      if (axisY > topPad + plotHeight) axisY = topPad + plotHeight;

      if (axisX < leftPad) axisX = leftPad;
      if (axisX > leftPad + plotWidth) axisX = leftPad + plotWidth;

      g.DrawLine(axisPen, leftPad, axisY, leftPad + plotWidth, axisY);
      g.DrawLine(axisPen, axisX, topPad, axisX, topPad + plotHeight);

      g.DrawString("x", new Font("Arial", 10), Brushes.Black,
          leftPad + plotWidth - 15, axisY + 5);
      g.DrawString("y", new Font("Arial", 10), Brushes.Black,
          axisX + 5, topPad - 15);

      Pen functionPen = new Pen(Color.Blue, 2);
      PointF? previous = null;

      for (int i = 0; i <= steps; i++) {
        double x = xMin + i * dx;
        double y = Dichotomy.FunctionValue(currentFunction, x);

        if (double.IsNaN(y)) {
          previous = null;
          continue;
        }

        PointF point = new PointF(toX(x), toY(y));

        if (previous != null) {
          g.DrawLine(functionPen, previous.Value, point);
        }

        previous = point;
      }

      if (hasResult) {
        float px = toX(currentRoot);
        float py = toY(0);

        g.FillEllipse(Brushes.Red, px - 5, py - 5, 10, 10);

        int digits = CountDigits(0.00001);

        g.DrawString("x = " + currentRoot.ToString("F" + digits),
            new Font("Arial", 9), Brushes.DarkRed, px + 8, py - 20);
      }
    }
  }
}