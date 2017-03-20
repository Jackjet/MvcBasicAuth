# MvcBasicAuth

HTTP Basic Authentication with ASP.NET MVC

## Installation

```PM> Install-Package MvcBasicAuth```

## Usage

* Make sure your project uses ASP.NET MVC Dependency Injection.
* Create authentication service by implementing *MvcBasicAuth.IHttpBasicAuthentication* interface.
* Register authentication service in the IoC container.
* Use *MvcBasicAuth.HttpBasicAuthenticationAttribute* attribute to annotate actions that require HTTP Basic Authentication.

Please take a look to [sample application source code](https://github.com/ilich/MvcBasicAuth/tree/master/src/SampeWebSite) to see HTTP Basic Authentication in action.
