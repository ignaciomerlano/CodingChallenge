using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    public class TrianguloEquilatero : IFormaGeometrica
    {
        private readonly TipoForma _tipo;
        private readonly decimal _lado;
        public TrianguloEquilatero(decimal lado, TipoForma tipo)
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
            return ((decimal)Math.Sqrt(3) / 4) * _lado * _lado;
        }

        public decimal Perimetro()
        {
            return _lado * 3;
        }
    }
}
