import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { IDataEmpleado, Empleado } from './interfaces/IDataEmpleado';

@Injectable({
  providedIn: 'root'
})
export class EmpleadoService {

  baseUrl: string = environment.apiUrl;
  empleadoUrl: string = `${this.baseUrl}/empleado`;
  resultados: Empleado[] = [];
  totalRegistros: number = 0;
  registrosPorPagina: number = 4;

  constructor(private http: HttpClient) { }

  listarEmpleados(pagina: number = 1, size: number = 4) {
    const params = new HttpParams()
      .set('PageNumber', pagina.toString())
      .set('PageSize', size.toString());

    this.http.get<IDataEmpleado>(this.empleadoUrl, {params: params})
    .subscribe(resp => {
      this.resultados = resp.resultado;
      this.totalRegistros = resp.totalRegistros;
      this.totalRegistros = resp.totalPaginas;
    });
  }

}
