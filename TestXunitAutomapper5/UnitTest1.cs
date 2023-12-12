using AutoMapper;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Xunit;

namespace TestXunitAutomapper5 {
    public class UnitTest1 {
        [Fact]
        public void TestingData() {
            var jsonString = File.ReadAllText("data.json");
            var data = JsonSerializer.Deserialize<List<ItemDeArbolDeActivosDeMedicion>>(jsonString);

            var sistemaDeMedicionCeliseoA = ItemDeArbolDeActivosDeMedicionUtils.Get(data, TipoDeItemDeArbol.SistemaDeMedicion, "celiseo a");
            
            var vazao = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionCeliseoA, TipoDeItemDeArbol.Variable, "vazão Bruta");
            Assert.Contains(vazao.SubItems, x => x.Nombre == "FE-4150-01113");
            Assert.Contains(vazao.SubItems, x => x.Nombre == "TM-4150-01113");

            var presionDif = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionCeliseoA, TipoDeItemDeArbol.Variable, "Pressão Diferencial");
            Assert.Contains(presionDif.SubItems, x => x.Nombre == "FIT-4150-01113");

            var temperatura = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionCeliseoA, TipoDeItemDeArbol.Variable, "temperatura");
            Assert.Contains(temperatura.SubItems, x => x.Nombre == "TE-4150.01113");
            Assert.Contains(temperatura.SubItems, x => x.Nombre == "TIT-4150.01113");


            var sistemaDeMedicionTaubateA = ItemDeArbolDeActivosDeMedicionUtils.Get(data, TipoDeItemDeArbol.SistemaDeMedicion, "taubate a");
            
            vazao = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionTaubateA, TipoDeItemDeArbol.Variable, "vazão Bruta");
            Assert.Contains(vazao.SubItems, x => x.Nombre == "PO-4300-38-122A");
            Assert.Contains(vazao.SubItems, x => x.Nombre == "TM-4300-38-122A");

            presionDif = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionTaubateA, TipoDeItemDeArbol.Variable, "Pressão Diferencial");
            Assert.Contains(presionDif.SubItems, x => x.Nombre == "FT-4300-38-122A");
            Assert.Contains(presionDif.SubItems, x => x.Nombre == "FTb-4300-38-122A");

            temperatura = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionTaubateA, TipoDeItemDeArbol.Variable, "temperatura");
            Assert.Contains(temperatura.SubItems, x => x.Nombre == "TE4300-38-122A");
            Assert.Contains(temperatura.SubItems, x => x.Nombre == "TT-4300-38-122A");
        }

        [Fact]
        public void TestingVm() {
            var jsonString = File.ReadAllText("data.json");
            var data = JsonSerializer.Deserialize<List<ItemDeArbolDeActivosDeMedicion>>(jsonString);

            var config = new MapperConfiguration(cfg => {
                cfg.AddProfile<ItemDeActivosDeMedicion_Vm__Profile>();
            });
            var mapper = config.CreateMapper();
            var dataVm = mapper.Map<IList<ItemDeArbolDeActivosDeMedicion>, List<ItemDeActivosDeMedicion_Vm>>(data);

            var sistemaDeMedicionCeliseoA = ItemDeArbolDeActivosDeMedicionUtils.Get(dataVm, TipoDeItemDeArbol.SistemaDeMedicion, "celiseo a");

            var vazao = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionCeliseoA, TipoDeItemDeArbol.Variable, "vazão Bruta");
            Assert.Contains(vazao.Items, x => x.Nombre == "FE-4150-01113");
            Assert.Contains(vazao.Items, x => x.Nombre == "TM-4150-01113");

            var presionDif = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionCeliseoA, TipoDeItemDeArbol.Variable, "Pressão Diferencial");
            Assert.Contains(presionDif.Items, x => x.Nombre == "FIT-4150-01113");

            var temperatura = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionCeliseoA, TipoDeItemDeArbol.Variable, "temperatura");
            Assert.Contains(temperatura.Items, x => x.Nombre == "TE-4150.01113");
            Assert.Contains(temperatura.Items, x => x.Nombre == "TIT-4150.01113");

            var sistemaDeMedicionTaubateA = ItemDeArbolDeActivosDeMedicionUtils.Get(dataVm, TipoDeItemDeArbol.SistemaDeMedicion, "taubate a");
            
            vazao = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionTaubateA, TipoDeItemDeArbol.Variable, "vazão Bruta");
            Assert.Contains(vazao.Items, x => x.Nombre == "PO-4300-38-122A");
            Assert.Contains(vazao.Items, x => x.Nombre == "TM-4300-38-122A");

            presionDif = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionTaubateA, TipoDeItemDeArbol.Variable, "Pressão Diferencial");
            Assert.Contains(presionDif.Items, x => x.Nombre == "FT-4300-38-122A");
            Assert.Contains(presionDif.Items, x => x.Nombre == "FTb-4300-38-122A");

            temperatura = ItemDeArbolDeActivosDeMedicionUtils.Get(sistemaDeMedicionTaubateA, TipoDeItemDeArbol.Variable, "temperatura");
            Assert.Contains(temperatura.Items, x => x.Nombre == "TE4300-38-122A");
            Assert.Contains(temperatura.Items, x => x.Nombre == "TT-4300-38-122A");
        }
    }

    public class ItemDeActivosDeMedicion_Vm__Profile : Profile {
        public ItemDeActivosDeMedicion_Vm__Profile() {
            // Dominio => Vista.
            this.CreateMap<ItemDeArbolDeActivosDeMedicion, ItemDeActivosDeMedicion_Vm>()
                .ForMember(vm => vm.Items, opt => opt.MapFrom(model => model.SubItems));
        }
    }
}
