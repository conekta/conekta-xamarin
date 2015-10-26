using System;
using System.Diagnostics;

#if __IOS__
using ObjectiveC;
using Foundation;
using SharpSwift;
#endif

#if __ANDROID__
using Android;
#endif

namespace Conekta {

	public abstract class Conekta {

		public static string ApiVersion { get; set; }
		public const string BaseUri = "https://api.conekta.io";
		public static string PublicKey { get; set; }

		public static string DeviceFingerPrint() {
			string uuidString = "";

			#if __IOS__
				//NSUuid uuid = new NSUuid();
				//uuidString = uuid.AsString();
				uuidString = UIKit.UIDevice.CurrentDevice.IdentifierForVendor.AsString();
			#elif __ANDROID__
				uuidString = Android.OS.Build.Serial;
			#elif WINDOWS_PHONE
				uuidString = Windows.Phone.System.Analytics.HostInformation.PublisherHostId;
			#endif

			return uuidString;
		}
	}
}
