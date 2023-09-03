using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore;


// https://download.microsoft.com/download/9/0/7/907AD35F-9F9C-43A5-9789-52470555DB90/ENU/SqlLocalDB.msi


namespace DesafioBenner.Models
{
    public class ControleEstacionamento
    {
        public int Id { get; set; } 
        public string Placa { get; set; }
        [DisplayName("Tempo Entrada")]
        public DateTime Tempo_entrada { get; set; }
        [DisplayName("Tempo Saída")]
        public DateTime? Tempo_saida { get; set; }
        [DisplayName("Total de Horas")]
        public double? HorasTotais { get; set; }
        public double? Minutos { get; set; }
        [DisplayName("Valor/Hora Inicial")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Valor_hora { get; set; }
        [DisplayName("Valor/Hora Adicional")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Valor_adicional { get; set; }
        [DisplayName("Valor Final")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double? Valor_final { get; set; }
        [ForeignKey("Precos")]
        public int? PrecosId { get; set; }

        public ControleEstacionamento(string Placa, DateTime Tempo_entrada, DateTime Tempo_saida, double Valor_hora, double Valor_adicional)
        {
            this.Placa = Placa;
            this.Tempo_entrada = Tempo_entrada;
            this.Tempo_saida = Tempo_saida;
            this.Valor_hora = Valor_hora;
            this.Valor_adicional = Valor_adicional;
        }

        public ControleEstacionamento(string Placa, DateTime Tempo_entrada, double? Valor_hora, double? Valor_adicional)
        {
            this.Placa = Placa;
            this.Tempo_entrada = Tempo_entrada;
            this.Valor_hora = Valor_hora;
            this.Valor_adicional = Valor_adicional;
        }

        public ControleEstacionamento() { }

    }
}
