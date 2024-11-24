using AuthServer.Service.Mappings.MappProfiles;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthServer.Service.Mappings
{
    public static class ObjectMapper
    {
        private static readonly Lazy<IMapper> lazy = new Lazy<IMapper>(() =>
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<DtoMapper>();
            });
            return configuration.CreateMapper();
        });


        /// <summary>
        /// ObjectMapper sınıfı, Service katmanında AutoMapper'ı yapılandırmak ve ona erişmek için merkezi bir yol sağlar.
        /// Daha iyi performans için tembel yükleme (lazy loading) kullanır ve Mapper örneğinin yalnızca ihtiyaç duyulduğunda oluşturulmasını sağlar.
        /// </summary>
        /// <returns> Lazy<IMapper> </returns>
        public static IMapper Mapper => lazy.Value;

    }
}
