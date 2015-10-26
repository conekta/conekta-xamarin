using System;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ConektaXamarin {

	public class Token {
		public const string EndPoint = "/tokens";

		public Token() {
		}

		public async Task<string> Create(Card card) {
			Connection conn = new Connection (RuntimePlatform.Android);
			string responseString = await conn.request (card, EndPoint);
			return responseString;
			//var token = Newtonsoft.Json.Linq.JObject.Parse (responseString);
			//return token;
		}
	}
}
