using AutoMapper;
using Sidus.DotNet.Core.Entities.Test;
using Sidus.DotNet.Core.Models.System;
using Sidus.DotNet.Core.Models.Test;
using System;

namespace Sidus.DotNet.Core.Mapper
{
    public class DotNetModelMapper : AutoMapper.Profile
    {
        public DotNetModelMapper()
        {
            CreateMap<Test, TestModel>().ReverseMap();
            CreateMap<Entities.System.Action, ActionModel>().ReverseMap();
        }
    }

    /// <summary>
    /// The best implementation of AutoMapper for class libraries -> https://www.abhith.net/blog/using-automapper-in-a-net-core-class-library/ 
    /// </summary>
    /*
    public static class ObjectMapper
    {
        public static readonly IConfigurationProvider config = new MapperConfiguration(cfg =>
        {
            // This line ensures that internal properties are also mapped over.
            cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
            cfg.AddProfile<DotNetModelMapper>();
        });

        private static readonly Lazy<IMapper> Lazy = new Lazy<IMapper>(() => config.CreateMapper());

        public static IMapper Mapper => Lazy.Value;
    }
    */
}
