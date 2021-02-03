using CodeChallenge.Data;
using CodeChallenge.Data.Enums;
using CodeChallenge.Data.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CodeChallengeTest
{
    public class Tests
    {
        private List<Animal> _animales;
        private ZoologicoServicio _zoologicoServicio;

        [SetUp]
        public void Setup()
        {
            _animales = new List<Animal>();
            _zoologicoServicio = new ZoologicoServicio();
        }

        [Test]
        public void CalcularAlimentoSinAnimales()
        {
            var result = _animales.Sum(a => a.CalcularAlimento());
            Assert.AreEqual(result, 0);
        }

        [Test]
        public void CalcularAlimentoSoloCarnivoros()
        {
            _animales.AddRange(MockFactoryCarnivoros());
            _zoologicoServicio.AgregarAnimales(MockFactoryCarnivoros());
            var result = _animales.Sum(a => a.CalcularAlimento());
            var resultServicio = _zoologicoServicio.CalcularConsumoMensualCarne();
            Assert.AreEqual(result, resultServicio);
        }

        [Test]
        public void CalcularAlimentoSoloHerviboros()
        {
            _animales.AddRange(MockFactoryHerivboros());
            _zoologicoServicio.AgregarAnimales(MockFactoryHerivboros());
            var result = _animales.Sum(a => a.CalcularAlimento());
            var resultServicio = _zoologicoServicio.CalcularConsumoMensualHierbas();
            Assert.AreEqual(result, resultServicio);
        }        

        [Test]
        public void CalcularAlimentoTodos()
        {
            _animales.AddRange(MockFactoryTodos());
            _zoologicoServicio.AgregarAnimales(MockFactoryTodos());
            var result = _animales.Sum(a => a.CalcularAlimento());
            var resultServicioCarne = _zoologicoServicio.CalcularConsumoMensualCarne();
            var resultServicioHierba = _zoologicoServicio.CalcularConsumoMensualHierbas();
            var resultServicio = resultServicioCarne + resultServicioHierba;
            Assert.AreEqual(result, resultServicio);
        }

        #region Mock Factory
        private List<Animal> MockFactoryCarnivoros()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = AnimalType.Carnívoro,
                    Peso = 100,
                    Porcentaje = 0.05
                },
                new Animal{
                    Tipo = AnimalType.Carnívoro,
                    Peso = 80,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = AnimalType.Carnívoro,
                    Peso = 95,
                    Porcentaje = 0.1
                }
            };
        }

        private List<Animal> MockFactoryReptiles()
        {
            return new List<Animal>
            {
                new Animal{
                    Tipo = AnimalType.Reptil,
                    Peso = 30,
                    DiasCambioDePiel = 7,
                    Kilos = 10,
                    Porcentaje = 10
                },
                new Animal{
                    Tipo = AnimalType.Reptil,
                    Peso = 50,
                    DiasCambioDePiel = 5,
                    Kilos = 15,
                    Porcentaje = 5
                }
            };
        }

        private List<Animal> MockFactoryHerivboros()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = AnimalType.Carnívoro,
                    Peso = 30,
                    Kilos = 10
                },
                new Animal{
                    Tipo = AnimalType.Hervíboro,
                    Peso = 50,
                    Kilos = 15
                }
            };
        }

        private List<Animal> MockFactoryTodos()
        {
            return new List<Animal>() {
                new Animal{
                    Tipo = AnimalType.Carnívoro,
                    Peso = 100,
                    Porcentaje = 0.05
                },
                new Animal{
                    Tipo = AnimalType.Carnívoro,
                    Peso = 80,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = AnimalType.Carnívoro,
                    Peso = 95,
                    Porcentaje = 0.1
                },
                new Animal{
                    Tipo = AnimalType.Hervíboro,
                    Peso = 30,
                    Kilos = 10
                },
                new Animal{
                    Tipo = AnimalType.Hervíboro,
                    Peso = 50,
                    Kilos = 15
                },
                new Animal{
                    Tipo = AnimalType.Reptil,
                    Peso = 30,
                    DiasCambioDePiel = 7,
                    Kilos = 10,
                    Porcentaje = 10
                },
                new Animal{
                    Tipo = AnimalType.Reptil,
                    Peso = 50,
                    DiasCambioDePiel = 5,
                    Kilos = 15,
                    Porcentaje = 5
                }
            };
        }
        #endregion
    }
}