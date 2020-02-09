using AutoMapper;
using estoque.DOMINIO;
using estoque.Model;


namespace estoque.INFRA.MAPPER
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
            CreateMap<ProdutoViewModel, Produto>();
        }
    }
}