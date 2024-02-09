using ManagerEasyTransportTimeMapbox.Abstract;
using ManagerEasyTransportTimeMapbox.Data;
using ManagerEasyTransportTimeMapbox.Dto.Input;
using ManagerEasyTransportTimeMapbox.Dto.Output;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ManagerEasyTransportTimeMapbox
{
    public class ManagerEasyTransportTimeMapboxProvider : IManagerEasyTransportTimeMapboxProvider
    {
        private readonly HttpClient _httpClient;
        private readonly string _MapboxToken;

        public ManagerEasyTransportTimeMapboxProvider(string mapboxToken, HttpClient httpClient)
        {
            _httpClient = httpClient;
            _MapboxToken = mapboxToken;
        }

        public async Task<TransportTimeOutputDto> CalculteTransportTime(TransportTimeInputDto transportTimeInputDto)
        {

            string travelMode = "driving";
            switch (transportTimeInputDto.TransportType)
            {
                case TransportType.Walking: { travelMode = "walking"; break; }
                case TransportType.Driving: { travelMode = "driving"; break; }
                case TransportType.DrivingWithTraffic: { travelMode = "driving-traffic"; break; }
                case TransportType.Cycling: { travelMode = "cycling"; break; }
            }

            NameValueCollection nv = new NameValueCollection
            {
                ["approaches"] = "curb;curb",
                ["access_token"] = _MapboxToken,
                ["sources"] = "0",
                ["annotations"] = "distance,duration"
            };

            Uri urlMapboxMatrix = new Uri("https://api.mapbox.com/directions-matrix/v1/mapbox/" + travelMode + "/"
                + transportTimeInputDto.OriginLocation.Longitude.ToString() + "," + transportTimeInputDto.OriginLocation.Latitude.ToString() + ";" 
                + transportTimeInputDto.DestinationLocation.Longitude.ToString() + "," + transportTimeInputDto.DestinationLocation.Latitude.ToString());

            UriBuilder uriBuilder = new UriBuilder(urlMapboxMatrix.ToString());
            NameValueCollection query = HttpUtility.ParseQueryString(uriBuilder.Query);
            query.Add(nv);
            uriBuilder.Query = query.ToString();

            HttpResponseMessage resp = await _httpClient.GetAsync(uriBuilder.Uri).ConfigureAwait(false);

            if (resp.StatusCode == System.Net.HttpStatusCode.OK)
            {
                string data = resp.Content.ReadAsStringAsync().Result;
                MapboxResult response = JsonConvert.DeserializeObject<MapboxResult>(data);

                if (response.Code == "Ok")
                {
                    TransportTimeOutputDto transportTimeOutputDto = new TransportTimeOutputDto()
                    {
                         DestinationLocation= transportTimeInputDto.DestinationLocation,
                         OriginLocation= transportTimeInputDto.OriginLocation,
                         TransportType= transportTimeInputDto.TransportType,
                         DistanceInMeters = response.Distances.First().Last(),
                         TravelTime= TimeSpan.FromSeconds(response.Durations.First().Last())
                    };

                    return transportTimeOutputDto;
                }
                else
                    throw new ArgumentException("Error al procesar los datos de Api Mapbox distance Matrix  code " + response.Code.ToString() + " Data compelta :" + JsonConvert.SerializeObject(response));
            }
            else
                throw new ArgumentException(" Ocurrio un error al consultar Api Mapbox distance Matrix response code "+ resp.StatusCode.ToString() );

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

    }

    #region Clases Privadas
    /// <summary>
    /// Datos de ubicaciones
    /// </summary>
    public class DatosUbicacion
    {
        [JsonProperty("distance")]
        public double Distance { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("location")]
        public List<double> Location { get; set; }
    }

    public class MapboxResult
    {
        [JsonProperty("code")]
        public string Code { get; set; }

        [JsonProperty("durations")]
        public List<List<double>> Durations { get; set; }

        [JsonProperty("destinations")]
        public List<DatosUbicacion> Destinations { get; set; }

        [JsonProperty("sources")]
        public List<DatosUbicacion> Sources { get; set; }

        [JsonProperty("distances")]
        public List<List<double>> Distances { get; set; }

    }

    #endregion

}

