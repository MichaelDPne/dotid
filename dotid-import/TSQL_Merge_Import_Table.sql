merge DIMSex as target
using (
	SELECT DISTINCT SEX_ABS, SEX
	FROM ABS_C16_T01_TS_SA_08062021164508583
) as source
ON (target.Id = source.SEX_ABS)
WHEN NOT MATCHED THEN INSERT (Id, Name) VALUES (source.SEX_ABS, source.Sex);

merge DimRegion as target
using (
	SELECT DISTINCT ASGS_2016, Region
	FROM ABS_C16_T01_TS_SA_08062021164508583
) as source
ON (target.Id = source.ASGS_2016)
WHEN NOT MATCHED THEN INSERT (Id, Name) VALUES (source.ASGS_2016, source.Region);

merge DimState as target
using (
	SELECT DISTINCT [STATE], State2
	FROM ABS_C16_T01_TS_SA_08062021164508583
) as source
ON (target.Id = source.[STATE])
WHEN NOT MATCHED THEN INSERT (Id, Name) VALUES (source.[STATE], source.State2);

merge DimState as target
using (
	SELECT DISTINCT [STATE], State2
	FROM ABS_C16_T01_TS_SA_08062021164508583
) as source
ON (target.Id = source.[STATE])
WHEN NOT MATCHED THEN INSERT (Id, Name) VALUES (source.[STATE], source.State2);

merge DimAge as target
using (
	SELECT DISTINCT AGE, Age2
	FROM ABS_C16_T01_TS_SA_08062021164508583
) as source
ON (target.Id = source.AGE)
WHEN NOT MATCHED THEN INSERT (Id, Name) VALUES (source.AGE, source.Age2);

merge DimYear as target
using (
	SELECT DISTINCT [TIME], Census_year
	FROM ABS_C16_T01_TS_SA_08062021164508583
) as source
ON (target.Id = source.[TIME])
WHEN NOT MATCHED THEN INSERT (Id, Name) VALUES (source.[TIME], source.Census_year);

merge FactPopulation as target
using (
	SELECT 
		age.Id as Age,
		region.Id as Region,
		sex.Id as Sex,
		[state].Id as [State],
		[year].Id as [Year],
		Fact.Value as Population
	FROM
		ABS_C16_T01_TS_SA_08062021164508583 as Fact
		inner join DimAge age ON Fact.AGE = age.Id
		inner join DimRegion region On Fact.ASGS_2016 = region.Id
		inner join DimSex sex On Fact.SEX_ABS = sex.Id
		inner join DimState [state] On Fact.[STATE] = [state].Id
		inner join DimYear [year] On Fact.[TIME] = [year].Id
) as source
ON (
target.Age = source.Age AND 
target.Region = source.Region AND 
target.Sex = source.Sex AND 
target.[State] = source.[State] AND
target.[Year] = source.[Year])
WHEN NOT MATCHED THEN INSERT (Age, Region, Sex, [State], [Year], Population) VALUES (source.Age, source.Region, source.Sex, source.[State], source.[Year], source.[Population]);