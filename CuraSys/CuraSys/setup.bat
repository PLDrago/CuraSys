cd CuraSys
dotnet restore
dotnet ef migrations remove
dotnet ef migrations add AutoInit
dotnet ef database update