using dotidapi.Controllers;
using dotidapi.Entity;
using dotidapi.Services;
using Microsoft.EntityFrameworkCore;
using Moq.EntityFrameworkCore;

namespace dotidapi_test
{
    public class AgeStructureServiceTests
    {


        [Fact]
        public async void AgeStructure_Should_have_one_data_row()
        {
            var testRegions = new List<RegionEntity>()
            {
                new RegionEntity
                {
                    Id = 102,
                    Name = "Central Coast",
                }
            };

            var testPopulation = new List<PopulationEntity>()
            {
                new PopulationEntity
                {
                     Id = 1,
                     Population = 200000,
                     Age = "TT",
                     Region = 102,
                     Sex = 1,
                     State = 1,
                     Year = 2016
                }
            }.AsQueryable();

            var ctx = new Moq.Mock<dotidapi.Context.DotIdContext>();

            ctx.Setup<DbSet<RegionEntity>>(x => x.Regions)
                .ReturnsDbSet(testRegions);

            ctx.Setup<DbSet<PopulationEntity>>(x => x.FactPopulations)
                .ReturnsDbSet(testPopulation);

            var service = new AgeStructureService(ctx.Object);

            AgeStructureController ctrl = new(service);

            var request = new dotidapi.Models.AgeStructureRequest { Code = 102, Sex = 1 };

            var data = (await ctrl.GetAgeStructure(request));

            Assert.NotNull(data);
            Assert.NotNull(data.Data);

            Assert.Equal("Central Coast", data.RegionName);
            Assert.Equal("102", data.RegionCode);

            Assert.NotEmpty(data.Data);
            Assert.Single(data.Data);

        }
    }
}