Conekta Xamarin v 0.0.1
======================

Wrapper to connect with https://api.conekta.io.

Conekta Xamarin SDK allow you create token with card details on iOS apps, by preventing sensitive card data from hitting your server(More information, read PCI compliance).

## Install

Via git:

```sh
$ git clone git@github.com:conekta/conekta-xamarin.git
```

## Configuration and Setup

### General setup

1. Move folder Conekta-Xamarin into your project folder.

2. Add existing folder from Xamarin Studio

3. Use package with namespace **ConektaSDK**

### App Transport Security

If you are compiling with iOS 9, please add on your application plist the lines below:

```xml
<key>NSAppTransportSecurity</key>
<dict>
  <key>NSExceptionDomains</key>
  <dict>
    <key>conekta.io</key>
    <dict>
      <key>NSIncludesSubdomains</key>
      <true/>
      <key>NSThirdPartyExceptionRequiresForwardSecrecy</key>
      <false/>
    </dict>
  </dict>
  <dict>
    <key>conektaapi.s3.amazonaws.com</key>
    <dict>
      <key>NSIncludesSubdomains</key>
      <true/>
      <key>NSThirdPartyExceptionRequiresForwardSecrecy</key>
      <false/>
    </dict>
  </dict>
</dict>
```

## Usage

```csharp
usage ConektaSDK

Conekta._delegate = this;
Conekta.PublicKey = "key_KJysdbf6PotS2ut2";
Conekta.collectDevice ();

Card card = new Card ("Julian Ceballos", "4242424242424242", "123", "10", "2018");
Token token = new Token ();

JObject response = await token.Create(card);
```

## Contribute

### Clone repo

```sh
$ git clone https://github.com/conekta/conekta-xamarin
$ cd conekta-xamarin
```

### Send pull requests

We love pull requests, send them from your fork to branch **dev** into **conekta/conekta-xamarin**

License
-------
Developed by [Conekta](https://www.conekta.io). Available with [MIT License](LICENSE).

We are hiring
-------------

If you are a comfortable working with a range of backend languages (Java, Python, Ruby, PHP, etc) and frameworks, you have solid foundation in data structures, algorithms and software design with strong analytical and debugging skills. 
Send your CV, github to quieroser@conekta.io
