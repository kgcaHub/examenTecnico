using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Threading.Tasks;

namespace OrdenPago.test
{
    [TestClass]
    public class OrdenPagoServiceTest
    {
        private readonly HttpClient _cliente = new HttpClient();

        [TestMethod]
        public void TestMethod1()
        {
            CallApi().Wait();
        }

        private async Task CallApi()
        {
            this._cliente.DefaultRequestHeaders.Accept.Clear();
            var serializer = new DataContractJsonSerializer(typeof(List<lib.vm.Sucursal>));
            var streamTask = this._cliente.GetStreamAsync("http://localhost:57588/ordenPago/filtrar/BN%20Centro%20de%20Lima/DOLARES");
            var repositories = serializer.ReadObject(await streamTask) as List<lib.vm.Sucursal>;
        }
    }
}
