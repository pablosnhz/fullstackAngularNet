export interface IDataEmpleado {
  totalRegistros: number;
  totalPaginas: number;
  pageSize: number;
  statusCode: number;
  resultado: Empleado[];
  mensaje: string;
  isExitoso: boolean;
}

export interface Empleado {
  apellidos: string;
  nombres: string;
  cargo: string;
  compania: string;
}
