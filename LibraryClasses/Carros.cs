﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrosGaleria
{
    public class Carros
    {
        public Guid CarroId { get; set; }
        public string ModeloCarro { get; set; }
        public bool Lancamento { get; set; }
        public int Portas { get; set; }
        public DateTime AnoDeFabricacao { get; set; }

        public Carros()
        {
            CarroId = Guid.NewGuid();
        }

        public void Exibir()
        {
            Console.WriteLine("Detalhes do carro:");
            Console.WriteLine("Modelo: " + ModeloCarro);
            Console.WriteLine("É Automatico ou manual ? : " + (Lancamento ? "Automatico" : "Manual"));
            Console.WriteLine("Número de portas: " + Portas);
            Console.WriteLine("Ano de fabricação: " + AnoDeFabricacao.Year);
            Console.WriteLine();
            Console.WriteLine("-----------------------------");
            Console.WriteLine();

        }
    }
}