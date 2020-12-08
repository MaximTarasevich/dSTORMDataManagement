using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using dSTORMWeb.Client.Models;

namespace dSTORMWeb.Client.Services
{
    public class HTTPService
    {
        private readonly HttpClient _http;

        public HTTPService(HttpClient http)
        {
            _http = http;

        }
        public async Task<MicroscopeViewModel> GetMicroscope(int id)
        {

            string uri = "api/microscope/GetMicroscope/" + id;
            var request = await _http.GetFromJsonAsync<object>(uri);
            var req = await _http.GetFromJsonAsync<MicroscopeViewModel>(uri);


            return req;
        }

        public async Task<ResponseModel> SaveMicroscope(MicroscopeViewModel model)
        {

            string uri = "api/microscope/Save";
            var request = await _http.PostAsJsonAsync<MicroscopeViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;
        }

        public async Task<ResponseModel> DeleteMicroscope(MicroscopeViewModel model)
        {

            string uri = "api/microscope/Delete";
            var request = await _http.PostAsJsonAsync<MicroscopeViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;

        }


        public async Task<PhysicalPropertyViewModel> GetPhysicalProperty(int id)
        {

            string uri = "api/physicalproperty/GetPhysicalProperty/" + id;
            var request = await _http.GetFromJsonAsync<object>(uri);
            var req = await _http.GetFromJsonAsync<PhysicalPropertyViewModel>(uri);


            return req;
        }

        public async Task<ResponseModel> SaveGetPhysicalProperty(PhysicalPropertyViewModel model)
        {

            string uri = "api/physicalproperty/Save";
            var request = await _http.PostAsJsonAsync<PhysicalPropertyViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;
        }

        public async Task<ResponseModel> DeleteGetPhysicalProperty(PhysicalPropertyViewModel model)
        {

            string uri = "api/physicalproperty/Delete";
            var request = await _http.PostAsJsonAsync<PhysicalPropertyViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;

        }


        public async Task<ObjectiveViewModel> GetObjective(int id)
        {

            string uri = "api/objective/GetObjective/" + id;
            var request = await _http.GetFromJsonAsync<object>(uri);
            var req = await _http.GetFromJsonAsync<ObjectiveViewModel>(uri);


            return req;
        }

        public async Task<ResponseModel> SaveObjective(ObjectiveViewModel model)
        {

            string uri = "api/objective/Save";
            var request = await _http.PostAsJsonAsync<ObjectiveViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;
        }

        public async Task<ResponseModel> DeleteObjectiveItem(ObjectiveViewModel model)
        {

            string uri = "api/objective/Delete";
            var request = await _http.PostAsJsonAsync<ObjectiveViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;

        }


        public async Task<LaserViewModel> GetLaser(int id)
        {

            string uri = "api/laser/GetLaser/" + id;
            var request = await _http.GetFromJsonAsync<object>(uri);
            var req = await _http.GetFromJsonAsync<LaserViewModel>(uri);


            return req;
        }

        public async Task<ResponseModel> SaveLaser(LaserViewModel model)
        {

            string uri = "api/laser/Save";
            var request = await _http.PostAsJsonAsync<LaserViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;
        }

        public async Task<ResponseModel> DeleteLaser(LaserViewModel model)
        {

            string uri = "api/laser/Delete";
            var request = await _http.PostAsJsonAsync<LaserViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;

        }


        public async Task<CameraViewModel> GetCamera(int id)
        {

            string uri = "api/camera/GetCamera/" + id;
            var request = await _http.GetFromJsonAsync<object>(uri);
            var req = await _http.GetFromJsonAsync<CameraViewModel>(uri);


            return req;
        }

        public async Task<ResponseModel> SaveCamera(CameraViewModel model)
        {

            string uri = "api/camera/Save";
            var request = await _http.PostAsJsonAsync<CameraViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;
        }

        public async Task<ResponseModel> DeleteCamera(CameraViewModel model)
        {

            string uri = "api/camera/Delete";
            var request = await _http.PostAsJsonAsync<CameraViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;

        }
        public async Task<AOTFilterViewModel> GetFilter(int id)
        {

            string uri = "api/aotfilter/GetFilter/" + id;
            var request = await _http.GetFromJsonAsync<object>(uri);
            var req = await _http.GetFromJsonAsync<AOTFilterViewModel>(uri);


            return req;
        }

        public async Task<ResponseModel> SaveFilter(AOTFilterViewModel model)
        {

            string uri = "api/aotfilter/Save";
            var request = await _http.PostAsJsonAsync<AOTFilterViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;
        }

        public async Task<ResponseModel> DeleteFilter(AOTFilterViewModel model)
        {

            string uri = "api/aotfilter/Delete";
            var request = await _http.PostAsJsonAsync<AOTFilterViewModel>(uri, model);
            var response = await request.Content.ReadFromJsonAsync<ResponseModel>();

            return response;

        }
    }
}
