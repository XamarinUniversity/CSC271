using System;
using Xamarin.Forms;
using System.IO;
using ClosingHandles.Data;

namespace ClosingHandles
{
	public partial class MainPage : ContentPage
	{
		public MainPage ()
		{
			InitializeComponent ();
		}

		async void OnReadFile(object sender, EventArgs e)
		{
			const int Lines = 12;

			try
			{
				string line;
				var fs = new FileStream (Jokes.FileName, FileMode.Open, FileAccess.Read, FileShare.None);
				var sr = new StreamReader (fs);
				var RNG = new Random ();
				var randomLineNumber = RNG.Next (0, Lines);
				do {
					line = sr.ReadLine ();
				} while (--randomLineNumber > 0);

				await DisplayAlert ("Joke of the day", line, "OK");
			}
			catch (Exception ex)
			{
				await DisplayAlert ("Error reading file", ex.Message, "OK");
			}
		}
	}
}
