using SimpleInjector;
using System.Diagnostics.CodeAnalysis;
using Zanella.MF7.Infra.ORM.Contexto;

namespace Zanella.MF7.WebAPI.IoC
{
    [ExcludeFromCodeCoverage]
    public static class SimpleInjectorContainer
    {
        public static Container ContainerInstance { get; private set; }

        /// <summary>
        /// Método que inicializa a injeção de depêndencia
        /// </summary>
        public static void Initialize()
        {
            ContainerInstance = new Container();

            RegisterServices();

            ContainerInstance.Verify();
        }

        /// <summary>
        /// Registra todos os serviços que podem ser injetados nos construtores
        /// </summary>
        /// <param name="container">É o contexto de injeção que deve conter as classes que podem ser injetadas</param>
        public static void RegisterServices()
        {
            //ContainerInstance.Register<IOrderService, OrderService>();
            //ContainerInstance.Register<IOrderRepository, OrderRepository>();
            //ContainerInstance.Register<IProductService, ProductService>();
            //ContainerInstance.Register<IProductRepository, ProductRepository>();

            //ContainerInstance.Register<IUserRepository, UserRepository>();
            //ContainerInstance.Register<IAuthenticationService, AuthenticationService>();

            // TODO: Por enquanto estaremos criando o contexto do EF por aqui. Precisaremos trocar por uma Factory
            ContainerInstance.Register(() => new ZanellaDbContext(), Lifestyle.Singleton);
        }
    }
}