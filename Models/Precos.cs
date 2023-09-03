using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace DesafioBenner.Models
{
    public class Precos
    {
        public int Id { get; set; }
        [DisplayName("Valor/Hora Inicial")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Valor_inicial { get; set; }
        [DisplayName("Valor/Hora Adicional")]
        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Valor_adicional { get; set; }
        [DisplayName("Data Inicial")]
        public DateTime Data_inicial { get; set; }
        [DisplayName("Data Final")]
        public DateTime Data_final { get; set; }

        public Precos(int Id, double Valor_inicial, double Valor_adicional, DateTime Data_inicial, DateTime Data_final)
        {
            this.Id = Id;
            this.Valor_inicial = Valor_inicial;
            this.Valor_adicional = Valor_adicional;
            this.Data_inicial = Data_inicial;
            this.Data_final = Data_final;
        }

        public Precos() { }
    }
}
