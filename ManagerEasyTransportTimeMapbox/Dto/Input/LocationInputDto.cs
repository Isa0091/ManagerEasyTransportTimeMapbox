using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasyTransportTimeMapbox.Dto.Input
{
    /// <summary>
    /// Datos de ubicacion
    /// </summary>
    public class LocationInputDto
    {
        /// <summary>
        /// Latitud
        /// </summary>
        public double Latitude { get; set; } 

        /// <summary>
        /// Datos de longitud
        /// </summary>
        public double Longitude { get; set; }
    }
}
