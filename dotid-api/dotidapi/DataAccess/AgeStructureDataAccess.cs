using Azure.Core;
using dotidapi.Context;
using dotidapi.Interfaces;
using dotidapi.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Dapper;
using System.Reflection.Metadata.Ecma335;

namespace dotidapi.DataAccess
{
    public class AgeStructureDataAccess : IAgeStructureDataAccess
    {
        private readonly DotIdContext _context;

        public AgeStructureDataAccess(DotIdContext context)
        {
            _context = context;
        }


        public async Task<IEnumerable<AgeDifferenceModel>> GetAgeDifferenceModelAsync(AgeStructureDiffRequest request)
        {
            var connection = new SqlConnection(this._context.Database.GetConnectionString());
            await connection.OpenAsync();

            var parameters = new { region = request.Code, sex = request.Sex, years = new[] { request.Year1, request.Year2 } };

            var difference = await connection.QueryAsync<AgeDifferenceModel>(
                "select Year, CONVERT(varchar, Age) + ' year old' as Age, Diff * -1 As Population from (select Year, Age, Population - LAG(Population, 1) OVER (PARTITION BY Age ORDER BY Year) as Diff from (select Year, Age, MAX(Population) as Population from FACTPopulation where sex = @sex and region = @region and Year IN @years group by Year, Age) totals) groups where Diff is not null"
                , parameters);

            return difference;

        }
    }
}
