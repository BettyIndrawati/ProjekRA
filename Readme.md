buat migration -->
```
dotnet ef migrations add "initialDB" --startup-project RAS.Bootcamp.RumahAqiqah.Cms -o "Migrations" --project RAS.Bootcamp.RumahAqiqah.Data
```
buat database update commandnya --> 
```
dotnet ef database update --startup-project RAS.Bootcamp.RumahAqiqah.Cms  --project RAS.Bootcamp.RumahAqiqah.Data
```
