using System;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace ConektaXamarin {

	public class Token {
		public const string EndPoint = "/tokens";

		public Token() {
		}

		public async Task<JObject> Create(Card card) {
			Connection conn = new Connection ("IOS");
			string responseString = await conn.request (card, EndPoint);
			JObject result = JObject.Parse (responseString);
			System.Console.WriteLine(Conekta.DeviceFingerPrint ());

			return result;
		}
	}
}
