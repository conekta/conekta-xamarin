using System;

namespace Conekta {

	public class Card {

		public string number { get; internal set; }
		public string name { get; internal set; }
		public int cvc { get; internal set; }
		public DateTime expiry { get; internal set; }

		public Card(string name, string number, int cvc, DateTime expiry) {
			if (string.IsNullOrEmpty(name))
				throw new ArgumentException ("name");
			if (string.IsNullOrEmpty(number))
				throw new ArgumentException ("number");
			if (cvc < 1)
				throw new ArgumentException ("cvc");

			this.name = name;
			this.number = number;
			this.cvc = cvc;
			this.expiry = expiry;
		}

		public Card(string name, string number, int cvc, int year, int month) {
			if (year <= 0)
				throw new ArgumentOutOfRangeException("year");

			if (month <= 0 || month > 12)
				throw new ArgumentOutOfRangeException("month");

			if (string.IsNullOrEmpty(number))
				throw new ArgumentNullException("cardNumber");

			if (string.IsNullOrEmpty(name))
				throw new ArgumentNullException("name");

			if (cvc < 1)
				throw new ArgumentNullException("cvc");

			this.name = name;
			this.number = number;
			this.cvc = cvc;
			this.expiry = new DateTime (year, month, 1);
		}
	}
}
