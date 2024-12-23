// aplicamos el EmpleadoReadDto en el controller en las peticiones para traer solo el dato de la empresa y no todos los que estaban dentro de compania, o sea que la busqueda por id cuando haga el dotnet run cuando busque por empleado id me va a hacer la busqueda por la empresa numero 2, "nissan" digamos, en realidad! nos trae el empleado por id y solamente la empresa que su id depende del empleado

// para diferenciar del httpGet que ya tenemos y queremos aplicar un get mas, lo hacemos con el route,
para diferenciarlo del otro, aplicando el WHERE, como si fuera sql para sentenciar alguna consulta que me trae todos los empleados que pertenezcan a ese id de empresa
[Route("EmpleadosPorCompania/{companiaId}")]

    <!-- Patron de repositorio -->

Permite no hacer uso del dbContext sino tener una capa adicional que haga uso de clases genericas, para tener
nuevos endpoints y no acceder al dbContext
Tambien podria decirse que utilizamos el patron de repositorio para hacer consultas sql y no hacerlas en sql server. para esto creamos la interface de IRepositorio y lo definimos en Repositorio.
Ests repositorios van a utilizarse como servicios en el program.cs y utilizamos cuando serian requeridos.

addScoped se crea uno por solicitud y luego se destruyen
addSingleton se crea por cada solicitud y se utilizara en cada instancia, queda en memoria
addTransient se crea cada vez que se solicita, para estados livianos y se crea cada vez que se solicita

reemplazamos en el CompaniaController los \_db por unidadTrabajo
