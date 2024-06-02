using gradinaTema1.Model.Repository;
using gradinaTema1.Model;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework.Legacy;

namespace gradinaTema1.Teste
{
    public class PlantRepositoryTest
    {
        [Test]
        public void AddPlant_Success()
        {
            // Arrange
            PlantRepository plantRepository = new PlantRepository("GradinaB");
            Plant plant = new Plant("1", "Test Plant", "Flower", "Species", "no", "Location");

            // Act
            bool result = plantRepository.AddPlant(plant);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void UpdatePlant_Success()
        {
            // Arrange
            PlantRepository plantRepository = new PlantRepository("GradinaB");
            Plant plant = new Plant("1", "Updated Plant", "Shrub", "Species", "yes", "New Location");

            // Act
            bool result = plantRepository.UpdatePlant("1", plant);

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void DeletePlant_Success()
        {
            // Arrange
            PlantRepository plantRepository = new PlantRepository("GradinaB");

            // Act
            bool result = plantRepository.DeletePlant("1");

            // Assert
            ClassicAssert.IsTrue(result);
        }

        [Test]
        public void SearchPlant_Returns_Plant()
        {
            // Arrange
            PlantRepository plantRepository = new PlantRepository("GradinaB");

            // Act
            Plant result = plantRepository.SearchPlant("2");

            // Assert
            ClassicAssert.IsNotNull(result);
        }
    }
}
