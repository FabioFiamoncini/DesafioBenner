using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;


// https://download.microsoft.com/download/9/0/7/907AD35F-9F9C-43A5-9789-52470555DB90/ENU/SqlLocalDB.msi


namespace DesafioBenner.Models
{
    public class ControleEstacionamento
    {
        public int Id { get; set; } 
        public string Placa { get; set; }
        public DateTime Tempo_entrada { get; set; }
        public DateTime Tempo_saida { get; set; }
        public double Duracao { get; set; }
        public double Valor_hora { get; set; }
        public double Valor_adicional { get; set; }
        public double? Valor_final { get; set; }

        public ControleEstacionamento(int Id, string Placa, DateTime Tempo_entrada, DateTime Tempo_saida, double Valor_hora, double Valor_adicional)
        {
            this.Id = Id;
            this.Placa = Placa;
            this.Tempo_entrada = Tempo_entrada;
            this.Tempo_saida = Tempo_saida;
            this.Duracao = Tempo_entrada.Subtract(Tempo_saida).TotalHours;
           // this.Duracao = (new DateTime(2023,8,31,18,30,0)).Subtract(new DateTime(2023, 8, 31, 21, 30, 0)).TotalHours;
            this.Valor_hora = Valor_hora;
            this.Valor_adicional = Valor_adicional;
            this.Valor_final = CalculaValorFinal(this.Valor_hora, this.Valor_adicional, this.Duracao);
        }

        public ControleEstacionamento() { }

        public double? CalculaValorFinal(double Valor_hora, double Valor_adicional, double Duracao)
        {
            return (Valor_adicional * (Duracao - 1) + Valor_hora);
        }
    }
}
