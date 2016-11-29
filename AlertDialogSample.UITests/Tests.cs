using System;
using System.IO;
using System.Linq;
using NUnit.Framework;
using Xamarin.UITest;
using Xamarin.UITest.Android;
using Xamarin.UITest.Queries;

namespace AlertDialogSample.UITests
{
	[TestFixture]
	public class Tests
	{
		AndroidApp app;

		[SetUp]
		public void BeforeEachTest()
		{
			app = ConfigureApp.Android.StartApp();
		}

		[Test]
		public void ReplTest()
		{
			app.Repl();
		}

		[Test]
		public void BackdoorTest()
		{
			app.Screenshot("Invoking Positive Backdoor");

			app.Invoke("PositiveBackdoor","hello");

			app.Screenshot("Invoking Negative Backdoor");

			app.Invoke("NegativeBackdoor");

		}



	}
}
