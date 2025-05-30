using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using P3L_V1.Model;
using Plugin.Firebase.CloudMessaging;

namespace P3L_V1.Services
{
    public class ApiService
    {
        private HttpClient _httpClient;
        private const string BaseUrl = "http://10.0.2.2:8000/api";

        public ApiService()
        { 
            _httpClient= new HttpClient()
            {
                BaseAddress = new Uri(BaseUrl)
            };
        }

        public async Task SetFCMToken()
        {
#if  ANDROID || IOS
            await CrossFirebaseCloudMessaging.Current.CheckIfValidAsync();
            var token = await CrossFirebaseCloudMessaging.Current.GetTokenAsync();

            Preferences.Set("fcmtoken", token);
#endif
        }

        public async Task<string> Login(string username, string password)
        {
            var credential = new LoginCredential()
            {
                username = username,
                password = password
            };

            string role = "";

            var json = JsonConvert.SerializeObject(credential);

            var data = new StringContent(json, Encoding.UTF8, "application/json");
            await SetFCMToken();

            try
            {
                var response = await _httpClient.PostAsync(BaseUrl + "/auth/login", data);
                response.EnsureSuccessStatusCode();
                var result = await response.Content.ReadAsStringAsync();
                var jsonJObject = JObject.Parse(result);
                var penggunaData = jsonJObject["data"]?["pengguna"]?.ToString();
                role = jsonJObject["role"].ToString();
                var accessToken = jsonJObject["access_token"].ToString();


                if (penggunaData != null)
                {
                    var pengguna = JsonConvert.DeserializeObject<Pengguna>(penggunaData);
                    Preferences.Set("idPengguna", pengguna.id_pengguna.ToString());
                    Preferences.Set("token", accessToken, string.Empty);
                    var FCMToken = Preferences.Get("fcmtoken", string.Empty);


                    var tokenCredential = new TokenCredential()
                    {
                        fcm_token = Preferences.Get("fcmtoken", String.Empty),
                        id_pengguna = pengguna.id_pengguna.ToString()
                    };
                    var tokenJson = JsonConvert.SerializeObject(tokenCredential);
                    _httpClient.DefaultRequestHeaders.Authorization =
                        new AuthenticationHeaderValue("Bearer", Preferences.Get("token", string.Empty));
                    var tokenData = new StringContent(tokenJson, Encoding.UTF8, "application/json");
                    var tokenResponse = await _httpClient.PostAsync(BaseUrl + "/fcm-token", tokenData);
                    tokenResponse.EnsureSuccessStatusCode();



                    if (pengguna.id_pembeli != null)
                    {
                        Preferences.Set("idRole", pengguna.id_pembeli.ToString());
                        Preferences.Set("role", "pembeli");
                    }
                    else if (pengguna.id_pegawai != null)
                    {
                        Preferences.Set("idRole", pengguna.id_pegawai.ToString());
                        Preferences.Set("role", "pegawai");
                    }
                    else if (pengguna.id_organisasi != null)
                    {
                        Preferences.Set("idRole", pengguna.id_organisasi.ToString());
                        Preferences.Set("role", "organisasi");
                    }
                    else if (pengguna.id_hunter != null)
                    {
                        Preferences.Set("idRole", pengguna.id_hunter.ToString());
                        Preferences.Set("role", "hunter");
                    }
                    else if (pengguna.id_penitip != null)
                    {
                        Preferences.Set("idRole", pengguna.id_penitip.ToString());
                        Preferences.Set("role", "penitip");
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Login Gagal";
            }
            return role;
        }

        //logout
        public async Task<string> Logout()
        {
            try
            {
                var accessToken = Preferences.Get("token", string.Empty);

                if (string.IsNullOrEmpty(accessToken))
                {
                    return "Token tidak ditemukan";
                }
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", accessToken);

                var response = await _httpClient.PostAsync(BaseUrl + "/auth/logout", null);

                response.EnsureSuccessStatusCode();

                Preferences.Remove("token");
                Preferences.Remove("idRole");
                Preferences.Remove("role");
                Preferences.Remove("idPengguna");
                Preferences.Remove("username");

                return "Logout berhasil";
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return "Logout gagal";
            }
        }

        public async Task<Penitip> getPenitipById(string id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                    new AuthenticationHeaderValue("Bearer", Preferences.Get("token", String.Empty));
                var response = await _httpClient.GetAsync($"{BaseUrl}/penitip/{id}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Penitip>>(json);
                return apiResponse.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Pembeli> getPembeliById(string id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("token", string.Empty));

                var response = await _httpClient.GetAsync($"{BaseUrl}/pembeli/{id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Pembeli>>(json);
                return apiResponse.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Kurir> getKurirByIdPegawai(string id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("token", string.Empty));

                var response = await _httpClient.GetAsync($"{BaseUrl}/kurir/{id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Kurir>>(json);
                return apiResponse.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<Hunter> getHunterById(string id)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("token", string.Empty));
                var response = await _httpClient.GetAsync($"{BaseUrl}/hunter/{id}");
                response.EnsureSuccessStatusCode();
                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<Hunter>>(json);
                return apiResponse.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Alamat>> getAlamatByIdPembeli(string id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/alamat/{id}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var apiResponse = JsonConvert.DeserializeObject<ApiResponse<List<Alamat>>>(json);
                return apiResponse.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Kategori>> getAllKategori()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/kategori");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject <ApiResponse<List<Kategori>>>(json);
                return result.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<SubKategori>> getAllSubKategoriByIdKategori(string id)
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/subkategori/{id}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();

                var result = JsonConvert.DeserializeObject<ApiResponse<List<SubKategori>>>(json);
                return result.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Barang>> getAllBarang()
        {
            try
            {
                var response = await _httpClient.GetAsync($"{BaseUrl}/barang");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponsePaginated<Barang>>(json);
                return result.Data.Items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<Barang>> getBarangByIdKategori(int idKategori)
        {
            try
            {
                string id = idKategori.ToString();
                var response = await _httpClient.GetAsync($"{BaseUrl}/barangByCategory/" + id);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponsePaginated<Barang>>(json);
                return result.Data.Items;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<BarangByKodeProduk> getBarangByKodeProduk(int kodeProduk)
        {
            try
            {
                string kode = kodeProduk.ToString();
                var response = await _httpClient.GetAsync($"{BaseUrl}/barang/" + kode);
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponse<BarangByKodeProduk>>(json);
                return result.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<MerchandisePlusFoto>> getAllMerchandise()
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("token", string.Empty));
                var response = await _httpClient.GetAsync($"{BaseUrl}/merchandise");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponse<List<Merchandise>>>(json);
                var data = result.Data;
                List<MerchandisePlusFoto> returnData = new List<MerchandisePlusFoto>();
                int counter = 0;
                foreach (var item in data)
                {
                    counter++;
                    var merchandise = new MerchandisePlusFoto
                    {
                        id_merchandise = item.id_merchandise,
                        foto = "m"+counter.ToString()+".jpg",
                        nama_merchandise = item.nama_merchandise,
                        poin = item.poin,
                        stok = item.stok
                    };
                    returnData.Add(merchandise);
                }
                return returnData;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task<List<PenjualanPlusAlamat>> getPenjualanByIdKurir(string id_kurir)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Preferences.Get("token", string.Empty));
                var response = await _httpClient.GetAsync($"{BaseUrl}/penjualan/kurir/{id_kurir}");
                response.EnsureSuccessStatusCode();

                var json = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ApiResponse<List<PenjualanPlusAlamat>>>(json);
                return result.Data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public async Task VerifikasiPengiriman(string nota_penjualan)
        {
            try
            {
                VerifiPengirimanKurir data = new VerifiPengirimanKurir
                {
                    id_pegawai = Preferences.Get("idRole", String.Empty),
                    nota_penjualan = nota_penjualan
                };

                var json = JsonConvert.SerializeObject(data);

                var postStringContent = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(BaseUrl + "/penjualan/kurir", postStringContent);
                response.EnsureSuccessStatusCode();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
