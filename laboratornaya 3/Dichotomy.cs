using System;

namespace Lab1 {
  public static class Dichotomy {
    public static double FunctionValue(Func<double, double> f, double x) {
      try {
        double value = f(x);

        if (double.IsNaN(value) || double.IsInfinity(value)) {
          return double.NaN;
        }

        return value;
      } catch {
        return double.NaN;
      }
    }

    public static bool FindRoot(
        Func<double, double> f,
        double a,
        double b,
        double e,
        out double root) {
      root = 0;

      double fa = FunctionValue(f, a);
      double fb = FunctionValue(f, b);

      if (double.IsNaN(fa) || double.IsNaN(fb)) {
        return false;
      }

      if (fa * fb > 0) {
        return false;
      }

      double left = a;
      double right = b;
      double fLeft = fa;
      double fRight = fb;
      double middle = 0;
      double fMiddle = 0;

      int counter = 0;

      while ((right - left) > e && counter < 10000) {
        middle = (left + right) / 2.0;
        fMiddle = FunctionValue(f, middle);

        if (double.IsNaN(fMiddle)) {
          return false;
        }

        if (Math.Abs(fMiddle) < e) {
          root = middle;
          return true;
        }

        if (fLeft * fMiddle < 0) {
          right = middle;
          fRight = fMiddle;
        } else {
          left = middle;
          fLeft = fMiddle;
        }

        counter++;
      }

      root = (left + right) / 2.0;
      return true;
    }
  }
}