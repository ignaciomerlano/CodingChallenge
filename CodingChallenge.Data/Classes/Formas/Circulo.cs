using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    public class Circulo : IFormaGeometrica
    {
        private readonly TipoForma _tipo;
        private readonly decimal _lado;

        public Circulo(decimal lado, TipoForma tipo)
        {
            _lado = lado;
            _tipo = tipo;
        }

        public TipoForma tipo
        {
            get { return _tipo; }
        }

        public decimal Area()
        {
            return Convert.ToDecimal(Math.PI) * (_lado / 2) * (_lado / 2);
        }

        public decimal Perimetro()
        {
            return Convert.ToDecimal(Math.PI) * _lado;
        }
    }
}
