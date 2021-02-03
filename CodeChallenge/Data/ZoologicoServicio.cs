using CodeChallenge.Data.Enums;
using CodeChallenge.Data.Model;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using static CodeChallenge.Data.Enums.EnumExtensions;

namespace CodeChallenge.Data
{
    public class ZoologicoServicio
    {
        public List<Animal> _animales;
        public ZoologicoServicio()
        {
            _animales = new List<Animal>();
        }
        public List<EnumValue> TiposAnimales => EnumExtensions.GetValues<AnimalType>();

        public void AgregarAnimal(Animal animal)
        {
            var totalHierbasYCarnesActual = CalcularTotalHierbasYCarnes();
            var totalIncluyendoNuevoAnimal = totalHierbasYCarnesActual + animal.CalcularAlimento();

            if (totalIncluyendoNuevoAnimal > 1500)
                throw new Exception("No es posible agregar este nuevo animal al listado, superaria el total mensual de alimentos requerido");

            _animales.Add(animal);
        }

        public List<Animal> GetAnimals()
        {
            return _animales;
        }

        public double CalcularConsumoMensualHierbas()
        {
            var total = 0D;

            var totalHerviboros = CalcularTotalDeAlimentos(CargarListadoDeAnimalesPorTipo(AnimalType.Hervíboro));
            var totalReptiles = CalcularTotalDeAlimentos(CargarListadoDeAnimalesPorTipo(AnimalType.Reptil)) / 2;

            total += totalHerviboros + totalReptiles;
            return total;
        }

        public double CalcularConsumoMensualCarne()
        {
            var total = 0D;

            var totalCarnivoros = CalcularTotalDeAlimentos(CargarListadoDeAnimalesPorTipo(AnimalType.Carnívoro));
            var totalReptiles = CalcularTotalDeAlimentos(CargarListadoDeAnimalesPorTipo(AnimalType.Reptil)) / 2;

            total += totalCarnivoros + totalReptiles;
            return total;
        }

        public string LoadAnimalType(Animal animal)
        {
            return animal.Tipo.GetDescription();
        }

        public List<Animal> CargarListadoDeAnimalesPorTipo(AnimalType animalType)
        {
            return _animales.Where(x => x.Tipo == animalType).ToList();
        }

        public void AgregarAnimales(List<Animal> animals)
        {
            _animales.AddRange(animals);
        }

        private double CalcularTotalHierbasYCarnes()
        {
            var total = 0D;

            total += CalcularConsumoMensualCarne();
            total += CalcularConsumoMensualHierbas();

            return total;
        }

        private double CalcularTotalDeAlimentos(List<Animal> animals)
        {
            var total = 0D;

            if (animals != null && animals.Count > 0) {
                total += animals.Sum(x => x.CalcularAlimento());
            }

            return total;
        }
    }
}
