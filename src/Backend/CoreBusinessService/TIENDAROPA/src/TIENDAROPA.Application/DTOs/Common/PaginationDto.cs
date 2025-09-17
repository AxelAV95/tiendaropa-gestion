using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TIENDAROPA.Application.DTOs.Common
{
    public class PaginationDto
    {
        // Número de página que se desea obtener (por defecto la primera)
        public int PageNumber { get; set; } = 1;

        // Tamaño de la página o cantidad de registros por página (por defecto 10)
        public int PageSize { get; set; } = 10;
    }
}
