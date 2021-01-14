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

You can process queries using DbHelper with IDisposable implementation.

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

 
