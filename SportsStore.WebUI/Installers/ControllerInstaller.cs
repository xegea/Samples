using SportsStore.Domain.Abstract;
using SportsStore.Domain.Concrete;

namespace SportsStore.WebUI.Installers
{
    using Castle.MicroKernel.Registration;
    using Castle.MicroKernel.SubSystems.Configuration;
    using Castle.Windsor;
    using System.Web.Mvc;

    public class ControllersInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IProductRepository>().ImplementedBy<ProductRepository>().LifestylePerWebRequest());

            container.Register(Classes.FromThisAssembly().BasedOn<IController>().LifestyleTransient());
        }
    }
}