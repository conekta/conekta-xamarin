using System;
using System.Text;
using System.Net.Http;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace ConektaSDK {

	public class Connection {

		public string Platform { get; set; }

		public Connection (string platform) {
			Platform = platform;
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
			requestMessage.Headers.Add ("Acept", "application/vnd.conekta-v" + Conekta.ApiVersion + "+json");

			if(Platform == "Android")
				requestMessage.Headers.Add ("Conekta-Client-User-Agent", @"{""agent"": ""Conekta Android SDK""}");
			else if(Platform == "iOS")
				requestMessage.Headers.Add ("Conekta-Client-User-Agent", @"{""agent"": ""Conekta iOS SDK""}");

			requestMessage.Content =
				new StringContent (string.Format (
					@"{{""card"":{{""name"":""{0}"",""number"":""{1}"",""cvc"":""{2}"",""exp_month"":""{3}"",""exp_year"":""{4}""}}}}", card.name,
					card.number, card.cvc, card.exp_month, card.exp_year), Encoding.UTF8, "application/json");

			HttpResponseMessage response = await client.SendAsync (requestMessage); //.ConfigureAwait(false);

			string responseString = await response.Content.ReadAsStringAsync();
			return responseString;
		}
	}
}

