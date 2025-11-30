using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculadoraProyect
{
    public  class stringConversion
    {

        public double EvaluarExpresion(string expr)
        {
            // Reemplazar √ por función sqrt

            expr = expr.Replace("√", "sqrt");
            expr = expr.Replace("x", "*");

            // Tokenizar
            var tokens = Tokenizar(expr);
            var postfix = ConvertirAPostfijo(tokens);
            return EvaluarPostfijo(postfix);
        }


        static List<string> Tokenizar(string expr)
        {
            var tokens = new List<string>();
            string numero = "";
            for (int i = 0; i < expr.Length; i++)
            {
                char c = expr[i];

                if (char.IsDigit(c) || c == '.')
                {
                    numero += c;
                }
                else
                {
                    // Si encontramos un '-' y es un signo unario
                    if (c == '-' && (i == 0 || expr[i - 1] == '(' || "+-*/^".Contains(expr[i - 1])))
                    {
                        numero += c; // lo agregamos al número
                    }
                    else
                    {
                        if (numero != "")
                        {
                            tokens.Add(numero);
                            numero = "";
                        }

                        if ("+-*/^()".Contains(c))
                            tokens.Add(c.ToString());
                        else if (char.IsLetter(c))
                        {
                            string func = "";
                            while (i < expr.Length && char.IsLetter(expr[i]))
                            {
                                func += expr[i];
                                i++;
                            }
                            i--;
                            tokens.Add(func);
                        }
                    }
                }
            }
            if (numero != "")
                tokens.Add(numero);

            return tokens;
        }


        static List<string> ConvertirAPostfijo(List<string> tokens)
        {
            var salida = new List<string>();
            var pila = new Stack<string>();
            var precedencia = new Dictionary<string, int> { { "+", 1 }, { "-", 1 }, { "*", 2 }, { "/", 2 }, { "^", 3 } };

            foreach (var token in tokens)
            {
                if (double.TryParse(token, out _))
                    salida.Add(token);
                else if (token == "sqrt")
                    pila.Push(token);
                else if (precedencia.ContainsKey(token))
                {
                    while (pila.Count > 0 && precedencia.ContainsKey(pila.Peek()) && precedencia[pila.Peek()] >= precedencia[token])
                        salida.Add(pila.Pop());
                    pila.Push(token);
                }
                else if (token == "(")
                    pila.Push(token);
                else if (token == ")")
                {
                    while (pila.Count > 0 && pila.Peek() != "(")
                        salida.Add(pila.Pop());
                    pila.Pop();
                    if (pila.Count > 0 && pila.Peek() == "sqrt")
                        salida.Add(pila.Pop());
                }
            }
            while (pila.Count > 0)
                salida.Add(pila.Pop());
            return salida;
        }

        static double EvaluarPostfijo(List<string> postfix)
        {
            var pila = new Stack<double>();
            foreach (var token in postfix)
            {
                if (double.TryParse(token, NumberStyles.Any, CultureInfo.InvariantCulture, out double num))
                    pila.Push(num);
                else if (token == "+") pila.Push(pila.Pop() + pila.Pop());
                else if (token == "-") { double b = pila.Pop(); double a = pila.Pop(); pila.Push(a - b); }
                else if (token == "*") pila.Push(pila.Pop() * pila.Pop());
                else if (token == "/") { double b = pila.Pop(); double a = pila.Pop(); pila.Push(a / b); }
                else if (token == "^") { double b = pila.Pop(); double a = pila.Pop(); pila.Push(Math.Pow(a, b)); }
                else if (token == "sqrt") pila.Push(Math.Sqrt(pila.Pop()));
            }
            return pila.Pop();
        }
    }

}

