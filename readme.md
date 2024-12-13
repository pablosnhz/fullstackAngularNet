// Fue importante generar la carpeta .vscode comando ctrl shift p y seleccionamos .net generate assets en el caso de no tenerlo

Infraestrutura va a depender de Core y Core de nadie, API si de core y Infraestrutura para eso
dotnet add reference ../Infraestructura

dotnet tool install --global dotnet-ef --version 6.0.7

<!-- Patron de repositorios -->

// realizamos la migracion y le damos lugar a una nueva carpeta
dotnet ef migrations add MigracionInicial -p Infraestructura -s API -o Data/Migrations
// realizamos el update al hacer cambios automaticamente
dotnet ef database update -p Infraestructura -s API
