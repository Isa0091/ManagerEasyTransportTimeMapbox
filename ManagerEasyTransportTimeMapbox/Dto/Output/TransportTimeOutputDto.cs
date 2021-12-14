using ManagerEasyTransportTimeMapbox.Data;
using ManagerEasyTransportTimeMapbox.Dto.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasyTransportTimeMapbox.Dto.Output
{
    /// <summary>
    /// Maneja el resultado de el tiemp ode transporte
    /// </summary>
    public class TransportTimeOutputDto
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

        /// <summary>
        /// Distancia en metros calculada
        /// </summary>
        public double DistanceInMeters { get; set; }

        /// <summary>
        /// Tiempo de viaje estimado
        /// </summary>
        public TimeSpan TravelTime { get; set; }
    }
}
