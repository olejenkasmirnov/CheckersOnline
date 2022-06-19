using System.Windows;
using CheckersDesktop.View;
using DryIoc;

namespace CheckersDesktop
{
	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : Application
	{
		public static IContainer Container { get; set; }
		protected override void OnStartup(StartupEventArgs e)
		{
			base.OnActivated(e);
			Container = new Container();
			Container.Register<MainWindow>();
			//container.RegisterType<IDataServices, TextDataServices>();
			//container.RegisterType<ITextViewModel, TextViewModel>();

			var window = Container.Resolve<MainWindow>();
			window.Show();
		}
	}
}
