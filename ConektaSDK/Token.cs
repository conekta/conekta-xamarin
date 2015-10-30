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

			string Content = string.Format (
				                 @"{{""card"":{{""name"":""{0}"",""number"":""{1}"",""cvc"":""{2}"",""exp_month"":""{3}"",""exp_year"":""{4}"", ""device_fingerprint"":""{5}""}}}}",
				card.name, card.number, card.cvc, card.exp_month, card.exp_year, Conekta.DeviceFingerPrint());

			Connection conn = new Connection (platform);
			string responseString = await conn.request (Content, EndPoint);
			JObject result = JObject.Parse (responseString);
			return result;
		}
	}
}
