using CodingChallenge.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingChallenge.Data.Classes.Formas
{
    public class Trapecio : IFormaGeometrica
    {
        private readonly TipoForma _tipo;
        private readonly decimal _baseMayor;
        private readonly decimal _baseMenor;
        private readonly decimal _ladoA;
        private readonly decimal _ladoB;
        private readonly decimal _alto;

        public Trapecio(decimal baseMayor, decimal baseMenor, decimal ladoA, decimal ladoB, decimal alto, TipoForma tipo)
        {
            _baseMayor = baseMayor;
            _baseMenor = baseMenor;
            _ladoA = ladoA;
            _ladoB = ladoB;
            _alto = alto;
            _tipo = tipo;
        }

        public TipoForma tipo
        {
            get { return _tipo; }
        }

        public decimal Area()
        {
            return (_baseMayor + _baseMenor) / 2 * _alto;
        }

        public decimal Perimetro()
        {
            return _baseMayor + _baseMenor + _ladoA + _ladoB;
        }
    }
}
