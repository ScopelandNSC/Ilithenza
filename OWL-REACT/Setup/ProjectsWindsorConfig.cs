using Castle.Facilities.TypedFactory;
using Castle.Windsor;
using CommonServiceLocator.WindsorAdapter;

namespace ResDiary_CustomerRetentionLiveTestTool.Setup
{
    class ProjectsWindsorConfig
    {
        public static IWindsorContainer Configure(WindsorContainer container = null)
        {
            container = CreateContainerAndInstallComponents(container);
            return container;
        }

        private static WindsorContainer CreateContainerAndInstallComponents(WindsorContainer container)
        {
            container = container ?? new WindsorContainer();
            container.AddFacility<TypedFactoryFacility>();
            container.Install(new ProjectGeneralInstaller()); // Can list .. , .. , .. 
            return container;
        }

    }
}
