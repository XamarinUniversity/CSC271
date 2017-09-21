using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ClosingHandles.Data;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace ClosingHandles
{
	public class App : Application
	{
		public App ()
		{
			// The root page of your application
			MainPage = new NavigationPage(new MainPage());
		}

		protected override async void OnStart ()
		{
			base.OnStart ();
			await Jokes.Initialize ();
		}
	}
}
