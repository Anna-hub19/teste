using System;
using System.Linq;
using System.Collections.Generic;
using Newtonsoft.Json;

class Program
{
    static void Main()
    {
        // 1) Cálculo da variável SOMA
        int INDICE = 13, SOMA = 0, K = 0;
        while (K < INDICE)
        {
            K += 1;
            SOMA += K;
        }
        Console.WriteLine($"1) O valor final de SOMA é: {SOMA}"); // Resultado: 91

        // 2) Verifica se um número pertence à sequência de Fibonacci
        Console.Write("Digite um número para verificar se pertence à sequência de Fibonacci: ");
        int num = int.Parse(Console.ReadLine());
        bool pertence = PertenceFibonacci(num);
        Console.WriteLine($"2) O número {num} pertence à sequência de Fibonacci? {(pertence ? "Sim" : "Não")}");

        // 3) Cálculo de faturamento diário
        string json = @"
        [
             {""dia"": 1, ""valor"": 22174.1664},
            {""dia"": 2, ""valor"": 24537.6698},
            {""dia"": 3, ""valor"": 26139.6134},
            {""dia"": 4, ""valor"": 0.0},
            {""dia"": 5, ""valor"": 0.0},
            {""dia"": 6, ""valor"": 26742.6612},
            {""dia"": 7, ""valor"": 0.0},
            {""dia"": 8, ""valor"": 42889.2258},
            {""dia"": 9, ""valor"": 46251.174},
            {""dia"": 10, ""valor"": 11191.4722},
            {""dia"": 11, ""valor"": 0.0},
            {""dia"": 12, ""valor"": 0.0},
            {""dia"": 13, ""valor"": 3847.4823},
            {""dia"": 14, ""valor"": 373.7838},
            {""dia"": 15, ""valor"": 2659.7563},
            {""dia"": 16, ""valor"": 48924.2448},
            {""dia"": 17, ""valor"": 18419.2614},
            {""dia"": 18, ""valor"": 0.0},
            {""dia"": 19, ""valor"": 0.0},
            {""dia"": 20, ""valor"": 35240.1826},
            {""dia"": 21, ""valor"": 43829.1667},
            {""dia"": 22, ""valor"": 18235.6852},
            {""dia"": 23, ""valor"": 4355.0662},
            {""dia"": 24, ""valor"": 13327.1025},
            {""dia"": 25, ""valor"": 0.0},
            {""dia"": 26, ""valor"": 0.0},
            {""dia"": 27, ""valor"": 25681.8318},
            {""dia"": 28, ""valor"": 1718.1221},
            {""dia"": 29, ""valor"": 13220.495},
            {""dia"": 30, ""valor"": 8414.61}
        ]";

        var faturamentos = JsonConvert.DeserializeObject<List<FaturamentoDiario>>(json);
        var diasValidos = faturamentos.Where(f => f.Valor > 0).ToList();

        double menorFaturamento = diasValidos.Min(f => f.Valor);
        double maiorFaturamento = diasValidos.Max(f => f.Valor);
        double mediaMensal = diasValidos.Average(f => f.Valor);
        int diasAcimaMedia = diasValidos.Count(f => f.Valor > mediaMensal);

        Console.WriteLine($"3) Menor faturamento: {menorFaturamento:F2}");
        Console.WriteLine($"   Maior faturamento: {maiorFaturamento:F2}");
        Console.WriteLine($"   Dias acima da média: {diasAcimaMedia}");

        // 4) Cálculo do percentual de representação por estado
        var faturamentoEstados = new Dictionary<string, double>
        {
            { "SP", 67836.43 },
            { "RJ", 36678.66 },
            { "MG", 29229.88 },
            { "ES", 27165.48 },
            { "Outros", 19849.53 }
        };

        double totalFaturamento = faturamentoEstados.Values.Sum();
        Console.WriteLine("4) Percentual de representação por estado:");
        foreach (var estado in faturamentoEstados)
        {
            double percentual = (estado.Value / totalFaturamento) * 100;
            Console.WriteLine($"   {estado.Key}: {percentual:F2}%");
        }

        // 5) Inverter uma string sem usar funções prontas
        Console.Write("Digite uma string para inverter: ");
        string texto = Console.ReadLine();
        string textoInvertido = InverterString(texto);
        Console.WriteLine($"5) String invertida: {textoInvertido}");
    }
// 2) Verifica se um número pertence à sequência de Fibonacci
    static bool PertenceFibonacci(int n)
    {
        int a = 0, b = 1;
        while (a < n)
        {
            int temp = a;
            a = b;
            b = temp + b;
        }
        return a == n;
    }
       // 5) Inverter uma string sem usar funções prontas
    static string InverterString(string s)
    {
        char[] invertida = new char[s.Length];
        for (int i = 0; i < s.Length; i++)
        {
            invertida[i] = s[s.Length - 1 - i];
        }
        return new string(invertida);
    }
}
       // 3) Cálculo de faturamento diário
class FaturamentoDiario
{
    public int Dia { get; set; }
    public double Valor { get; set; }
}
