using ManagerEasyTransportTimeMapbox.Dto.Input;
using ManagerEasyTransportTimeMapbox.Dto.Output;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasyTransportTimeMapbox.Abstract
{
    /// <summary>
    /// Interfaz de definicion de metodos
    /// </summary>
    public interface IManagerEasyTransportTimeMapboxProvider
    {
        /// <summary>
        /// Calcula El tiempo de transporte entre dos ubicaciones origen y destino y una forma de transporte
        /// </summary>
        /// <param name="transportTimeInputDto"></param>
        /// <returns></returns>
        Task<TransportTimeOutputDto> CalculteTransportTime(TransportTimeInputDto transportTimeInputDto);
    }
}
