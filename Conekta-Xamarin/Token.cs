using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace ConektaSDK {

	public class Token {
		public const string EndPoint = "/tokens";

		public Token() {
		}

		public async Task<JObject> Create(Card card) {
			string platform;
			#if __IOS__
				platform = "iOS";
			#elif __ANDROID__
				platform = "Android";
			#endif

			Connection conn = new Connection (platform);
			string responseString = await conn.request (card, EndPoint);
			JObject result = JObject.Parse (responseString);
			string uuid = Conekta.DeviceFingerPrint ();
			System.Console.WriteLine ("EL UUID:::::");
			System.Console.WriteLine (uuid);
			return result;
		}
	}
}
