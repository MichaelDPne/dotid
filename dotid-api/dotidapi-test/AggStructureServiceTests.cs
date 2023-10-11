using dotidapi.Controllers;
using dotidapi.DataAccess;
using dotidapi.Entity;
using dotidapi.Interfaces;
using dotidapi.Models;
using dotidapi.Services;
using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data.Common;

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
                     Age = 1,
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

            var service = new AgeStructureService(
                new RegionRepository(ctx.Object),
                new FactRepository(ctx.Object));

            var diffService = new AgeStructureDiffService(
                new RegionRepository(ctx.Object),
                new AgeStructureDataAccess(ctx.Object)
                );

            AgeStructureController ctrl = new(service, diffService);

            var request = new dotidapi.Models.AgeStructureRequest { Code = 102, Sex = 1 };

            var data = (await ctrl.GetAgeStructure(request));

            Assert.NotNull(data);
            Assert.NotNull(data.Data);

            Assert.Equal("Central Coast", data.RegionName);
            Assert.Equal("102", data.RegionCode);

            Assert.NotEmpty(data.Data);
            Assert.Single(data.Data);

        }


        [Fact]
        public async void AgeStructure_Diff_Should_have_one_two_row()
        {
            var testRegions = new List<RegionEntity>()
            {
                new RegionEntity
                {
                    Id = 102,
                    Name = "Central Coast",
                }
            };

            var testDiff = new List<AgeDifferenceModel>()
            {
                new AgeDifferenceModel
                {
                     Population = 55,
                     Age = "0 years old",
                     Year = 2016
                },
                new AgeDifferenceModel
                {
                     Population = 78,
                     Age = "1 years old",
                     Year = 2016
                },
            }.AsQueryable();

            var connection = new Mock<DbConnection>();


            var ctx = new Moq.Mock<dotidapi.Context.DotIdContext>();

            ctx.Setup<DbSet<RegionEntity>>(x => x.Regions)
                .ReturnsDbSet(testRegions);

            var service = new AgeStructureService(
                new RegionRepository(ctx.Object),
                new FactRepository(ctx.Object));

            var diff = new Mock<IAgeStructureDataAccess>();
            diff.Setup<Task<IEnumerable<AgeDifferenceModel>>>(x =>
            x.GetAgeDifferenceModelAsync(It.IsAny<AgeStructureDiffRequest>()))
                .ReturnsAsync(testDiff);
                

            var diffService = new AgeStructureDiffService(
                new RegionRepository(ctx.Object),
                diff.Object);


            AgeStructureController ctrl = new(service, diffService);

            var request = new dotidapi.Models.AgeStructureDiffRequest { Code = 102, Sex = 1, Year1 = 2011, Year2 = 2016 };

            var data = (await ctrl.GetAgeStructureDiff(request));

            Assert.NotNull(data);
            Assert.NotNull(data.Data);

            Assert.Equal("Central Coast", data.RegionName);
            Assert.Equal("102", data.RegionCode);

            Assert.NotEmpty(data.Data);
            Assert.Equal(2, data.Data.Count());

        }





    }
}