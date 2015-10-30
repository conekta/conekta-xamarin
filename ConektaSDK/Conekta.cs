using System;
using System.Drawing;
using System.Diagnostics;

#if __IOS__
using Foundation;
using ObjectiveC;
using ObjCRuntime;
using UIKit;
#endif

#if __ANDROID__
using Android.Webkit;
#endif

namespace ConektaSDK {

	public abstract class Conekta {

		public static string ApiVersion { get; set; }
		public const string BaseUri = "https://api.conekta.io";
		public static string PublicKey { get; set; }
		private static string UriConektaJs = "https://conektaapi.s3.amazonaws.com/v0.3.2/js/conekta.js";

		#if __IOS__
		public static UIViewController _delegate { get; set; }
		#endif

		public static void collectDevice() {
			string SessionId = Conekta.DeviceFingerPrint ();
			string PublicKey = Conekta.PublicKey;

			string html = "<!DOCTYPE html><html><head></head><body style=\"background: blue;\">";
			html += "<script type=\"text/javascript\" src=\"https://conektaapi.s3.amazonaws.com/v0.5.0/js/conekta.js\" data-conekta-public-key=\"" + PublicKey + "\" data-conekta-session-id=\"" + SessionId + "\"></script>";
			html += "</body></html>";

			string contentPath = Environment.CurrentDirectory;

			#if __IOS__
			System.Console.WriteLine("Se va agregar webview en iOS");
			UIWebView web = new UIWebView(new RectangleF(new PointF(0,0), new SizeF(0, 0)));
			web.LoadHtmlString(html, new NSUrl(contentPath, true));
			web.ScalesPageToFit = true;
			Conekta._delegate.View.AddSubview(web);
			System.Console.WriteLine("Se agrego webview en iOS");
			#endif

			#if __ANDROID__
			WebView web_view = new WebView(Android.App.Application.Context);
			web_view.Settings.JavaScriptEnabled = true;
			web_view.Settings.AllowContentAccess = true;
			web_view.Settings.DomStorageEnabled = true;
			web_view.LoadDataWithBaseURL(Conekta.UriConektaJs, html, "text/html", "UTF-8", null);
			#endif
		}

		public static string DeviceFingerPrint() {
			string uuidString = "";

			#if __IOS__
				//NSUuid uuid = new NSUuid();
				//uuidString = uuid.AsString();
				uuidString = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
				uuidString = uuidString.Replace("-", "");
			#elif __ANDROID__
				uuidString = Android.OS.Build.Serial;
			#elif WINDOWS_PHONE
				uuidString = Windows.Phone.System.Analytics.HostInformation.PublisherHostId;
			#endif

			return uuidString;
		}
	}
}
