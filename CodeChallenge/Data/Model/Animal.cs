using CodeChallenge.Data.Enums;
using System;

namespace CodeChallenge.Data.Model
{
    public class Animal
    {
        public int Id { get; set; }
        public AnimalType Tipo { get; set; }
        public string Especie { get; set; }
        public int Edad { get; set; }
        public string LugarOrigen { get; set; }
        public double Peso { get; set; }
        public double Porcentaje { get; set; }
        public double Kilos { get; set; }
        public int DiasCambioDePiel { get; set; }

        public double CalcularAlimento()
        {
            var total = 0D;
            int diasEnElMes = DateTime.DaysInMonth(
                                DateTime.UtcNow.Year, 
                                DateTime.UtcNow.Month);

            switch (Tipo)
            {
                case AnimalType.Carnívoro:
                    total += CalculoAlimentoNoHerviboro(diasEnElMes);
                    break;
                case AnimalType.Hervíboro:
                    total += CalculoAlimentoHerviboro(diasEnElMes);
                    break;
                case AnimalType.Reptil:
                    int canditadCambiosDePiel = diasEnElMes / DiasCambioDePiel;
                    int diasDeAyuno = 3 * canditadCambiosDePiel;
                    int diasSinAyuno = diasEnElMes - diasDeAyuno;

                    total += CalculoAlimentoNoHerviboro(diasSinAyuno);
                    break;
                default:
                    break;
            }

            total = Math.Round(total, 2, MidpointRounding.AwayFromZero);

            return total;
        }

        private double CalculoAlimentoHerviboro(int diasEnElMes)
        {
            var total = 0D;
            
            total += ((Peso * 2) + Kilos) * diasEnElMes;

            return total;
        }

        private double CalculoAlimentoNoHerviboro(int diasEnElMes)
        {
            var total = 0D;

            total += ((Peso * Porcentaje) / 100) * diasEnElMes;

            return total;
        }

    }
}