using System;
using System.Globalization;

namespace Lab1 {
  public static class FunctionParser {
    public static Func<double, double> Parse(string formula) {
      if (string.IsNullOrWhiteSpace(formula)) {
        throw new Exception("Формула пустая.");
      }

      string prepared = formula.Replace(" ", "");

      return x =>
      {
        int position = 0;
        double value = ParseExpression(prepared, ref position, x);

        if (position < prepared.Length) {
          throw new Exception("Лишний символ: " + prepared[position]);
        }

        return value;
      };
    }

    private static double ParseExpression(string s, ref int i, double x) {
      double result = ParseTerm(s, ref i, x);

      while (i < s.Length) {
        char c = s[i];

        if (c == '+') {
          i++;
          result = result + ParseTerm(s, ref i, x);
        } else if (c == '-') {
          i++;
          result = result - ParseTerm(s, ref i, x);
        } else {
          break;
        }
      }

      return result;
    }

    private static double ParseTerm(string s, ref int i, double x) {
      double result = ParseFactor(s, ref i, x);

      while (i < s.Length) {
        char c = s[i];

        if (c == '*') {
          i++;
          result = result * ParseFactor(s, ref i, x);
        } else if (c == '/') {
          i++;
          double divisor = ParseFactor(s, ref i, x);

          if (divisor == 0) {
            throw new Exception("Деление на ноль.");
          }

          result = result / divisor;
        } else {
          break;
        }
      }

      return result;
    }

    private static double ParseFactor(string s, ref int i, double x) {
      double baseValue = ParseUnary(s, ref i, x);

      if (i < s.Length && s[i] == '^') {
        i++;
        double exponent = ParseFactor(s, ref i, x);
        return Math.Pow(baseValue, exponent);
      }

      return baseValue;
    }

    private static double ParseUnary(string s, ref int i, double x) {
      if (i < s.Length && s[i] == '-') {
        i++;
        return -ParseUnary(s, ref i, x);
      }

      if (i < s.Length && s[i] == '+') {
        i++;
        return ParseUnary(s, ref i, x);
      }

      return ParsePrimary(s, ref i, x);
    }

    private static double ParsePrimary(string s, ref int i, double x) {
      if (i >= s.Length) {
        throw new Exception("Неожиданный конец формулы.");
      }

      char c = s[i];

      if (c == '(') {
        i++;
        double value = ParseExpression(s, ref i, x);

        if (i >= s.Length || s[i] != ')') {
          throw new Exception("Нет закрывающей скобки.");
        }

        i++;
        return value;
      }

      if (char.IsDigit(c) || c == '.') {
        int start = i;

        while (i < s.Length && (char.IsDigit(s[i]) || s[i] == '.')) {
          i++;
        }

        string text = s.Substring(start, i - start);
        return double.Parse(text, CultureInfo.InvariantCulture);
      }

      if (char.IsLetter(c)) {
        int start = i;

        while (i < s.Length && char.IsLetter(s[i])) {
          i++;
        }

        string name = s.Substring(start, i - start).ToLower();

        if (name == "x") return x;
        if (name == "pi") return Math.PI;
        if (name == "e") return Math.E;

        if (i >= s.Length || s[i] != '(') {
          throw new Exception("После " + name + " ожидалась скобка.");
        }

        i++;
        double argument = ParseExpression(s, ref i, x);

        if (i >= s.Length || s[i] != ')') {
          throw new Exception("Нет закрывающей скобки у " + name);
        }

        i++;

        if (name == "sin") return Math.Sin(argument);
        if (name == "cos") return Math.Cos(argument);
        if (name == "tan") return Math.Tan(argument);
        if (name == "sqrt") return Math.Sqrt(argument);
        if (name == "abs") return Math.Abs(argument);
        if (name == "ln") return Math.Log(argument);
        if (name == "exp") return Math.Exp(argument);

        throw new Exception("Неизвестная функция: " + name);
      }

      throw new Exception("Непонятный символ: " + c);
    }
  }
}