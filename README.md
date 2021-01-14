# Open Source WebSite for .NET

[![GitHub License](https://img.shields.io/badge/license-MIT-lightgrey.svg)](https://github.com/Exmaru/SimpleWeb)
[![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/Exmaru/SimpleWeb/issues)

Open Source WebSite for SimpleWeb.Net are a collection of open source components created by Razor Website and others in the community.

 - [Building](#building)
    - [Prerequisites](#prerequisites)
    - [Basic Coding](#basic-coding)
    - [Web.Config](#web-config)
    - [Database](#database)
    - [Ajax](#ajax)

---

### Release

[![v1.0.0](https://img.shields.io/badge/release-v1.0-579ACA.svg?logo=data:image/png;base64,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)](https://github.com/Exmaru/SimpleWeb/releases/download/1.0.0/release_v1.0.zip)

---

### Prerequisites

See Only WebEngine.

```cs
using WebEngine;
```

The naming convention for the namespace in the `cs` file that is added to `App_Code` is to attach the WebEngine before it.

```cs
using System;

namespace WebEngine.Extension
{
    public class WebEngineExtension
    {
        public static string SampleFunc()
        {
            return "Welcome";
        }
    }
}
```

---

### Basic Coding

Please call the layout after the declaration of the discharge.

```php
@using WebEngine;
@{
    Global.Init(this);

    Layout = "~/Layout/_Bootstrap.cshtml";
}
<h3>Hello, World</h3>
```

Or, you can specify the shape to be returned.

```cs
Global.Init(this, "xml");
```

The expanded Request makes it easier to acquire values.

```cs
    int Amount = Request.GetInt("Amount");
    long SampleSeq = Request.GetLong("SampleSeq", -1);
```

The following targets can be specified using the `Request.<target-name>(name, default-value?)`:

 - `GetString` Returns the value from Request to String.
 - `GetInt` Returns the value from Request to Int.
 - `GetFloat` Returns the value from Request to Float.
 - `GetLong` Returns the value from Request to Long.
 - `GetBoolean` Returns the value from Request to Boolean.
 - `GetDateTime` Returns the value from Request to DateTime.

---


### Web Config

You must set the connection syntax for connecting to the database.
(The name must be set to `DBconn`)

```xml
<connectionStrings>
<add name="DBConn" connectionString="Data Source=localhost;Initial Catalog=SimpleWeb;User ID=userid;Password=password;Application Name=SimpleWeb" providerName="System.Data.SqlClient" />
</connectionStrings>
```

The current version(v.1.0) does not support multiple connections, only `MSSQL` is available.

You can set the following options:
 - `LogLevel` You can set it from 1 to 5. If you set it to 5, all logs will be recorded. If you set it to 1, only errors will be recorded.
 - `AppID` The name of the application used to classify `Log` or to use the key names.
 - `IsBundle` Minify all files in the `Scripts` folder.
 - `CookieVar` The name of the cookie that is saved at login.
 - `title` The title of the website. Using in `SEO`.
 - `siteurl` The Representative URL of the website. Using in `SEO`.
 - `mobileurl` The Mobile URL of the website. Do not enter unless you need a separate URL.
 - `description` The description of the website. Using in `SEO`.
 - `keywords` The search keyword to use when the search engine exposes this site. Using in `SEO`.
 - `image` This is a thumbnail image used on SNS.
 - `XML` Set up when you want to use a separate XML dataset. The configured file is automatically created. You can specify multiple files separated by `.`.
 
 
 ---


### Database

You can process queries using `DbHelper` with IDisposable implementation.

```cs
DbResult result = new DbResult();
DateTime serverTime = new DateTime();
DbRow detail = new DbRow();

using(var db  = new DbHelper())
{
	var query1 = db.ExecuteQuery("select * from Sample with (nolock) where Amount > @Amount order by SampleSeq desc");
	query1.AddInput("@Amount", "int", Amount);
	result = query1.ExecuteDbResult();
	var query2 = db.ExecuteQuery("select getdate()");
	serverTime = Convert.ToDateTime(query2.ExecuteScalar());
	if (SampleSeq > 0)
	{
		detail = result.Find("SampleSeq", SampleSeq);
	}
	else
	{
		detail = result.First;
	}
}
```

You can perform a `foreach` statement using the `List` Property.


```php
@foreach(var item in result.List)
{
	<tr style="cursor:pointer" onclick="location.href='sample?SampleSeq=@(item.GetLong("SampleSeq"))&Amount=@(Amount)'">
		<td>@(item.GetLong("SampleSeq"))</td>
		<td>@(item.GetString("Title"))</td>
		<td>@(item.GetInt("Amount"))</td>
		<td>@(item.GetDateTime("RegistDate").ToString("yyyy-MM-dd"))</td>
		<td>@(item.GetBoolean("IsEnabled"))</td>
	</tr>
}
```

The following targets can be specified using the `DbRow`:

 - `GetString` Returns the value from DbRow to String.
 - `GetInt` Returns the value from DbRow to Int.
 - `GetFloat` Returns the value from DbRow to Float.
 - `GetLong` Returns the value from DbRow to Long.
 - `GetBoolean` Returns the value from DbRow to Boolean.
 - `GetDateTime` Returns the value from DbRow to DateTime.


---


### Ajax

Use the `Response.Json` command to easily return objects to Json.

```php
@using WebEngine;
@{
    Global.Init(this);

    int Amount = Request.GetInt("Amount", 50);
    ReturnValue result = new ReturnValue();

    if (IsPost)
    {
        result.Success(Amount);
        result.Value = "Hello, Ajax";
    }
    else
    {
        result.Error("do not working");
    }
}
@Response.Json(result)
```

Values can be returned using Javascript or JQuery.
 
```javascript
function onAjaxTest() {
	$.post("/ajax", { amount : "@(Amount)" }, function(rst) {
		console.log(rst);

		if (rst.Check) {
			$("#ajaxLayer").html(rst.Value);
		} else {
			alert(rst.Message);
		}
	});
};
```

---

### Javascript minify

If the `IsBundle` value is true, minify all files in the `Scripts` folder.

```php
@using System.Web.Optimization;
@Scripts.Render("~/Scripts/all")
```

