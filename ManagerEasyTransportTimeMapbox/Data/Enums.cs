using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerEasyTransportTimeMapbox.Data
{

    /// <summary>
    /// Formas de transporte disponibles para un Transportita
    /// </summary>
    public enum TransportType
    {
        /// <summary>
        /// 
        /// </summary>
        Driving = 0,
        /// <summary>
        /// 
        /// </summary>
        Walking = 1,

        /// <summary>
        /// 
        /// </summary>
        DrivingWithTraffic = 2,

        /// <summary>
        /// 
        /// </summary>
        Cycling = 3
    }
}
