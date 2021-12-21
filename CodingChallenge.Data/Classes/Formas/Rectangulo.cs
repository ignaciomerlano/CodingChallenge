using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    public class Rectangulo : IFormaGeometrica
    {
        private readonly TipoForma _tipo;
        private readonly decimal _lado;
        private readonly decimal _alto;

        public Rectangulo(decimal lado, decimal alto, TipoForma tipo)
        {
            _lado = lado;
            _alto = alto;
            _tipo = tipo;
        }

        public TipoForma tipo
        {
            get { return _tipo; }
        }

        public decimal Area()
        {
            return _alto * _lado;
        }

        public decimal Perimetro()
        {
            return (2 * _alto) + (2 * _lado);
        }
    }
}
