using System;
using Newtonsoft.Json;

namespace ConektaXamarin {

	public class Token {

		private string EndPoint = "/tokens";

		public Token() {
		}

		public async object Create(Card card) {
			Connection conn = new Connection (RuntimePlatform.Android);
			string responseString = await conn.request (card, this.EndPoint);
			return responseString;
			//var token = Newtonsoft.Json.Linq.JObject.Parse (responseString);
			//return token;
		}
	}
}
