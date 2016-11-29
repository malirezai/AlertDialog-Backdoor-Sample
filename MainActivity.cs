using Android.App;
using Android.Widget;
using Android.OS;
using Java.Interop;

namespace AlertDialogSample
{
	[Activity(Label = "AlertDialogSample", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{
		int count = 1;
		TextView view;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			view = FindViewById<TextView>(Resource.Id.myText);

			Button button = FindViewById<Button>(Resource.Id.myButton);
			button.Click += (s, e) =>
			{
				AlertDialog.Builder builder = new AlertDialog.Builder(this);
				builder.SetTitle("Alert!");
				builder.SetMessage("Plese click on Yes or No.");
				builder.SetCancelable(false);
				builder.SetPositiveButton("OK", (sender, arg) =>
				{
					HandlePositiveClicked();
				});

				builder.SetNegativeButton("Cancel", (sender, arg) =>
				{
					HandleNegativeClicked();
				});

				builder.Show();
			};

		}

		public void HandlePositiveClicked()
		{
			view.Text = "Positive Button Clicked!";
		}

		public void HandleNegativeClicked()
		{
			view.Text = "Negative Button Clicked!";
		}

		#region BACKDOOR METHODS

		[Export("PositiveBackdoor")]
		public void PositiveBackdoor(string param1)
		{
			HandlePositiveClicked();
		}

		[Export("NegativeBackdoor")]
		public void NegativeBackdoor()
		{
			HandleNegativeClicked();
		}

		#endregion

	}
}

