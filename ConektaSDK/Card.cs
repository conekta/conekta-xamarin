using System;

namespace ConektaSDK {

	public class Card {

		public string number { get; internal set; }
		public string name { get; internal set; }
		public string cvc { get; internal set; }
		public string exp_month { get; internal set; }
		public string exp_year { get; internal set; }

		public Card(string name, string number, string cvc, string exp_month, string exp_year) {
			this.name = name;
			this.number = number;
			this.cvc = cvc;
			this.exp_month = exp_month;
			this.exp_year = exp_year;
		}
	}
}
