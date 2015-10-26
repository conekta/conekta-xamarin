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

namespace ConektaXamarin {

	public abstract class Conekta {

		public static string ApiVersion { get; set; }
		public const string BaseUri = "https://api.conekta.io";
		public static string PublicKey { get; set; }

		public static string DeviceFingerPrint() {
			string uuidString = "";

			#if __IOS__
				NSUuid uuid = new NSUuid();
				uuidString = uuid.AsString();
			#endif

			#if __ANDROID__
			System.Console.WriteLine("=== ANDROID ===");
			//System.Console.WriteLine(Java.Util.UUID);
			//int josue = Java.Util.UUID;
			#endif
			return uuidString;
		}
	}
}
