// aplicamos el EmpleadoReadDto en el controller en las peticiones para traer solo el dato de la empresa y no todos los que estaban dentro de compania, o sea que la busqueda por id cuando haga el dotnet run cuando busque por empleado id me va a hacer la busqueda por la empresa numero 2, "nissan" digamos, en realidad! nos trae el empleado por id y solamente la empresa que su id depende del empleado

// para diferenciar del httpGet que ya tenemos y queremos aplicar un get mas, lo hacemos con el route,
para diferenciarlo del otro, aplicando el WHERE, como si fuera sql para sentenciar alguna consulta que me trae todos los empleados que pertenezcan a ese id de empresa
[Route("EmpleadosPorCompania/{companiaId}")]
