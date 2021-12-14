using ManagerEasyTransportTimeMapbox.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasyTransportTimeMapbox.Dto.Input
{
    /// <summary>
    /// Datos para calcular el tiemp ode transporte
    /// </summary>
    public class TransportTimeInputDto
    {
        /// <summary>
        /// Datos de ubicacion origen
        /// </summary>
        public LocationInputDto OriginLocation { get; set; }

        /// <summary>
        /// Datos de ubicacion del  destino
        /// </summary>
        public LocationInputDto DestinationLocation { get; set; }

        /// <summary>
        /// Indica el tipo de transporte con el cual se calculara el tiempo desde el origen al destino
        /// </summary>
        public TransportType TransportType { get; set; }
    }
}
