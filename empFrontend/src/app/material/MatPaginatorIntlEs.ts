import { Injectable } from "@angular/core";
import { MatPaginatorIntl } from "@angular/material/paginator";

@Injectable()
export class MatPaginatorIntlEs extends MatPaginatorIntl{
  // CON ESTO CAMBIAMOS EL NOMBRE DE LA TABLA QUE NOS ESPECIFICA CUAANTOS REGISTROS HAY POR PAGINA
  override itemsPerPageLabel: string = "Registros por Pagina";
}
