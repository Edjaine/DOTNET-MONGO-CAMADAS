using System;
using AutoMapper;
using ProjetoBase.DOMINIO;
using ProjetoBase.MODEL;

namespace ProjetoBase.INFRA.MAPPER
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<ProdutoViewModel, Produto>()
                .ForMember(p => p.Id, opt => opt.Ignore());


            CreateMap<Serial, SerialViewModel>();   
            CreateMap<SerialViewModel, Serial>()
                .ForMember(s=> s.Id, opt => opt.Ignore());             
        }
    }
}