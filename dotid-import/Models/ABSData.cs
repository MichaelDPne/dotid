using System.Globalization;
using CsvHelper.Configuration.Attributes;


public record ABSData {

    [Index(0)]
    public int SEX_ABS {get;set;}
    [Index(1)]
    public string Sex {get;set;} = string.Empty;
    [Index(2)]
    public string AGE {get;set;} = string.Empty;
    [Index(3)]
    public string Age {get;set;} = string.Empty;
    [Index(4)]
    public int STATE {get;set;}

    [Index(5)]
    public string State {get;set;} = string.Empty;
    
    [Index(6)]
    public string REGIONTYPE {get;set;} = string.Empty;

    [Index(7)]
    public string GeographyLevel {get;set;} = string.Empty;

    [Index(8)]
    public int ASGS_2016 {get;set;}

    [Index(9)]
    public string Region {get;set;} = string.Empty;

    [Index(10)]
    public int Time {get;set;}

    [Index(11)]
    public string CensusYear {get;set;} = string.Empty;

    [Index(12)]
    public int Value {get;set;}

    [Index(13)]
    public string FlagCodes {get;set;} = string.Empty;

    [Index(14)]
    public string Flags {get;set;} = string.Empty;


}