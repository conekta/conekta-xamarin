using System;
using System.Drawing;
using System.Diagnostics;

using Xamarin.Forms;

#if __IOS__
using ObjCRuntime;
using Foundation;
using UIKit;
#endif

namespace ConektaXamarin
{

	public class DeviceCollector {

		#if __IOS__
		public UIViewController _delegate { get; set; }
		#endif
		public string PublicKey;

		public static void Collect(String SessionId)
		{
			string html = "<html style=\"background: blue;\"><head></head><body>";
			html += "<script type=\"text/javascript\" src=\"https://conektaapi.s3.amazonaws.com/v0.3.2/js/conekta.js\" data-public-key=\"" + this.PublicKey + "\" data-session-id=\"" + SessionId + "\"></script>";
			html += "</body></html>";

			string contentPath = Environment.CurrentDirectory;

			#if __IOS__
			UIWebView web = new UIWebView(new RectangleF(new PointF(0,0), new SizeF(0, 0)));
			web.LoadHtmlString(html, new NSUrl(contentPath, true));
			web.ScalesPageToFit = true;
			this._delegate.View.AddSubview(web);
			#endif

			#if __ANDROID__

			#endif
		}
	}
}
