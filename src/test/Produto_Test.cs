using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Moq;
using NUnit.Framework;
using ProjetoBase.DOMINIO;
using ProjetoBase.INFRA.MAPPER;
using ProjetoBase.INTERFACES;
using ProjetoBase.MODEL;

namespace test
{
    public class Tests
    {
        private IUnitOfWork _uow;
        private IProdutoRepositorio _repositorio;
        private IMapper _mapper;
        private IList<Produto> listProdutos = new List<Produto>();
        [SetUp]
        public void Setup()
        {

            listProdutos.Add(FactoryProduto.Constroi());

            var mapperConfig = new MapperConfiguration(mc => {
                mc.AddProfile(new MappingProfile());
            });

            _mapper = mapperConfig.CreateMapper();

            var mUnW = new Mock<IUnitOfWork>();
            mUnW.Setup(u => u.Commit())
                .Callback(() => {
                    Console.WriteLine("Teste Commited....");
                });

            _uow = mUnW.Object;

            var mRepositorio = new Mock<IProdutoRepositorio>();
            mRepositorio.Setup(u => u.Add(It.IsAny<Produto>()))
            .Callback((Produto i) => listProdutos.Add(i));

            mRepositorio.Setup(u => u.GetAll())
            .ReturnsAsync(listProdutos.AsEnumerable<Produto>());

            _repositorio = mRepositorio.Object;
        }

        [Test]
        public void Inclui_novo_produto_no_banco()
        {
            //Arrange
            var quantidadeAntes = listProdutos.Count();
            var produto = FactoryProduto.Constroi();

            // Act
            _repositorio.Add(produto);        

            // Assert
            var quantidadeDepois = listProdutos.Count();
            Assert.Greater(quantidadeDepois, quantidadeAntes, $"Quantidade antes {quantidadeAntes} e depois {quantidadeDepois}");
        }
        [Test]
        public async Task Consulta_produto_banco_de_dados() 
        {
            //Arragen
            var quantidadeLista = listProdutos.Count();
            //Act
            var produtos = await _repositorio.GetAll();
            //Assert
            Assert.AreEqual(quantidadeLista, produtos.Count());
            Assert.IsNotNull(produtos.FirstOrDefault().Codigo);

        }        
        
    }
}