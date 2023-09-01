using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;


// https://download.microsoft.com/download/9/0/7/907AD35F-9F9C-43A5-9789-52470555DB90/ENU/SqlLocalDB.msi


namespace DesafioBenner.Models
{
    public class ControleEstacionamento
    {
        public int Id { get; set; } 
        public string Placa { get; set; }
        public DateTime Tempo_entrada { get; set; }
        [AllowNull]
        public DateTime Tempo_saida { get; set; }
        public double HorasTotais 
        { 
            get => Tempo_saida < Tempo_entrada ? 0 : Math.Abs(Tempo_saida.Subtract(Tempo_entrada).TotalHours);
            set => _ = Tempo_saida < Tempo_entrada ? 0 : Math.Abs(Tempo_saida.Subtract(Tempo_entrada).TotalHours); 
        }
        public double Minutos
        {
            get => Tempo_saida < Tempo_entrada ? 0 : Tempo_saida.Subtract(Tempo_entrada).Minutes;
            set => _ = Tempo_saida < Tempo_entrada ? 0 : Tempo_saida.Subtract(Tempo_entrada).Minutes;
        }
        public double Valor_hora { get; set; }
        public double Valor_adicional { get; set; }
        public double? Valor_final 
        {
            get => Tempo_saida < Tempo_entrada ? 0 : CalculaValorFinal(this.Valor_hora, this.Valor_adicional, this.HorasTotais, this.Minutos);
            set => _ = Tempo_saida < Tempo_entrada ? 0 : CalculaValorFinal(this.Valor_hora, this.Valor_adicional, this.HorasTotais, this.Minutos); 
        }

        public ControleEstacionamento(string Placa, DateTime Tempo_entrada, DateTime Tempo_saida, double Valor_hora, double Valor_adicional)
        {
            this.Placa = Placa;
            this.Tempo_entrada = Tempo_entrada;
            this.Tempo_saida = Tempo_saida;
            this.Valor_hora = Valor_hora;
            this.Valor_adicional = Valor_adicional;
        }

        public ControleEstacionamento(string Placa, DateTime Tempo_entrada, double Valor_hora, double Valor_adicional)
        {
            this.Placa = Placa;
            this.Tempo_entrada = Tempo_entrada;
            this.Valor_hora = Valor_hora;
            this.Valor_adicional = Valor_adicional;
        }

        public ControleEstacionamento() { }

        public double? CalculaValorFinal(double Valor_hora, double Valor_adicional, double HorasTotais, double Minutos)
        {
            double calc_valor = new double();

            if (HorasTotais == 0 && Minutos <= 30)
            {
                calc_valor = Valor_hora / 2;
            }
            else
            {
                if (Minutos <= 10)
                {
                    calc_valor = Valor_hora + (HorasTotais == 1 ? 0 : Valor_adicional * (HorasTotais - 1)); 
                }
                else
                {
                    calc_valor = Valor_hora + (Valor_adicional * HorasTotais);
                }
            }
            return calc_valor;
        }
    }
}
