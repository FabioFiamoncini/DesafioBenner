using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DesafioBenner.Models
{
    public class Precos
    {
        public int Id { get; set; }
        public double Valor_inicial { get; set; }
        public double Valor_adicional { get; set; }
        public DateTime Data_inicial { get; set; }
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
