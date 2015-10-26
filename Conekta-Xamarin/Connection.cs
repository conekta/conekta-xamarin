using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ConektaXamarin {

	public class Connection {

		public RuntimePlatform Platform { get; set; }

		public Connection (RuntimePlatform platform) {
			this.Platform = platform;
		}

		public async Task<string> request(Card card, string EndPoint) {
			if(card.Equals(null))
				throw new ArgumentException("card");
			if(string.IsNullOrEmpty(EndPoint))
				throw new ArgumentException("endPoint");

			if(string.IsNullOrEmpty(Conekta.ApiVersion))
				Conekta.ApiVersion = "0.3.0";

			HttpClient client = new HttpClient ();

			HttpRequestMessage requestMessage = new HttpRequestMessage (HttpMethod.Post, Conekta.BaseUri + EndPoint);

			requestMessage.Headers.Authorization = new AuthenticationHeaderValue ("Basic", Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:", Conekta.PublicKey))));
			//requestMessage.Headers.Add ("", "application/vnd.conekta-v" + Conekta.ApiVersion + "+json");

			if(Platform == RuntimePlatform.Android)
				requestMessage.Headers.Add ("Conekta-Client-User-Agent", @"{""agent"": ""Conekta Android SDK""}");
			else if(Platform == RuntimePlatform.iOS)
				requestMessage.Headers.Add ("Conekta-Client-User-Agent", @"{""agent"": ""Conekta iOS SDK""}");

			requestMessage.Content =
				new StringContent (string.Format (
					@"{{""card"":{{""name"":""{0}"",""number"":{1},""cvc"":{2},""exp_month"":{3},""exp_year"":{4}}}}}", card.name,
					card.number, card.cvc, card.expiry.Month, card.expiry.Year), Encoding.UTF8, "application/json");


			HttpResponseMessage response = await client.SendAsync (requestMessage); //.ConfigureAwait(false);

			string responseString = await response.Content.ReadAsStringAsync();
			return responseString;
		}
	}
}

