using System.Data;
using CsvHelper.Configuration;
using CsvHelper;
using System.Globalization;
using Microsoft.Data.SqlClient;

namespace dotid_import;

class Program
{
    /*
     * Look I didn't fully implement this because to be honest with you, this is not something I have had to do very
     * often and honestly can't remember the last time I needed to do something like this
     * however the pattern below shows you how I would do it
     * 
     * I have used CsvHelper extensively in the past and I do not like to run insert statements for uploading bulk data
     * so I will always look to use bulk tools such as SqlBulkCopy especially because it integreates with CsvReader/Helper
     * which is an amazing library
     * 
     * The concept would be this app runs possibly checking a folder structure or is passed a specific file
     * the bulk uploader would create a new temporary/import table once that is complete
     * 
     * a series of queries would be run on the server that would populdate/append using MERGE statements the
     * specific tables that have been created ie. Dim's and Fact's and yes I realise these are data warehouse
     * terms as I did worked extensively with a data warehouse at SEW
     * 
     * So I think this gives a good overview of the pattern I would implement and shows that I am aware of the
     * nature of transferring/uploading bulk amounts of data in batches which SqlBulkCopy supports and streaming
     * 
     * This could even be made more efficient by uploading the import file to blob storage first and then
     * streaming the file from blob storage to an Azure sql database which means it would be even more
     * efficient
     * 
     */

    static async Task Main(string[] args)
    {
        var config = new CsvConfiguration(CultureInfo.InvariantCulture)
        {
            NewLine = Environment.NewLine,
        };

        using var reader = new StreamReader(".\\ABS_C16_T01_TS_SA_08062021164508583.xls");
        using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);

        using var csvDataReader = new CsvDataReader(csv);

        using var sql = new SqlConnection("Data Source=.;Initial Catalog=DotId;Integrated Security=True;TrustServerCertificate=True");
        await sql.OpenAsync();
        
        using var bc = new SqlBulkCopy(sql);

        bc.DestinationTableName = "Test";

        await bc.WriteToServerAsync(csvDataReader);

    }
}