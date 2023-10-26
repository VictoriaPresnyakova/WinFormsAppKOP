using DataBaseImplements.Implements;
using StudentContracts.BusinessLogicContracts;
using StudentContracts.StorageContracts;
using Unity;
using Unity.Lifetime;

namespace WinFormsApp
{
    internal static class Program
    {
        private static IUnityContainer container = null;
        public static IUnityContainer Container { get { if (container == null) { container = BuildUnityContainer(); } return container; } }
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.SetHighDpiMode(HighDpiMode.SystemAware);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(Container.Resolve<FormEducation>());
        }
        private static IUnityContainer BuildUnityContainer()
        {
            var currentContainer = new UnityContainer();


            currentContainer.RegisterType<IStudentStorage, StudentStorage>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEducationStorage, EducationStorage>(new HierarchicalLifetimeManager());

            currentContainer.RegisterType<IStudentLogic, BusinessLogics.StudentLogic>(new HierarchicalLifetimeManager());
            currentContainer.RegisterType<IEducationLogic, BusinessLogics.EducationLogic>(new HierarchicalLifetimeManager());

            return currentContainer;
        }
    }
}