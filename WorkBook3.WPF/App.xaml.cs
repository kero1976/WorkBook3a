using Prism.Ioc;
using System.Windows;
using WorkBook3.WPF.ViewModels;
using WorkBook3.WPF.ViewModels.QuestionRegister;
using WorkBook3.WPF.Views;
using WorkBook3.WPF.Views.QuestionRegister;

namespace WorkBook3.WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        /// <summary>
        /// App.
        /// </summary>
        /// <returns>Window</returns>
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        /// <summary>
        /// Prism画面遷移用
        /// </summary>
        /// <param name="containerRegistry">containerRegistry</param>
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterDialog<QuestionList, QuestionListViewModel>();
            containerRegistry.RegisterDialog<QuestionRegisterMain, QuestionRegisterMainViewModel>();
            containerRegistry.RegisterDialog<FixDataCreate, FixDataCreateViewModel>();
        }
    }
}
