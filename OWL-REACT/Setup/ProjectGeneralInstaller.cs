using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace ResDiary_CustomerRetentionLiveTestTool.Setup
{
    public class ProjectGeneralInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            /*
            container.Register(
                    Component.For<IDateTimeProvider, IExtendedDateTimeProvider>()
                        .ImplementedBy<ExtendedDateTimeProvider>(),
                    Component.For(typeof(IMapper)).UsingFactoryMethod(x => Mapper.Instance),
                    Component.For<ISettingsManager>().ImplementedBy<SettingsManagerImpl>(),
                    Component.For<IPermissionCheckerFactory>().ImplementedBy<PermissionCheckerFactory>(),
                    Component.For<IBookingService>().ImplementedBy<BookingService>().LifestyleTransient())
                ;
                */
        }
    }
}