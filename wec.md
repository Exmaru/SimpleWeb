# Window Command for SimpleWeb.NET 

[![GitHub License](https://img.shields.io/badge/license-MIT-lightgrey.svg)](https://github.com/Exmaru/SimpleWeb)
[![contributions welcome](https://img.shields.io/badge/contributions-welcome-brightgreen.svg?style=flat)](https://github.com/Exmaru/SimpleWeb/issues)

Open Source WebSite for SimpleWeb.Net are a collection of open source components created by Razor Website and others in the community.

 - [WebEngine Command](#wec)
    - [About](#about)
	- [Config](#config)
    - [Options](#options)
    - [Wec Update](#wec-update)
    - [Wec Module](#wec-module)
 - [SimpleWeb](#simpleweb)
    - [a relative link](https://github.com/Exmaru/SimpleWeb/blob/main/README.md)

---

### About

Console commands that make it easier to install and manage the Simple Web.

```cmd
C:\>wec
```

\/? command to see how to use it.

```cmd
C:\>wec /?
```

---

### Config

The wec command generates a default environment file.

The folder where wec is installed must be added to `Path` in your computer configuration.

---

### Options

Options can be specified in the following formats:

```cmd
C:\>wec -{option} {option-value} -{option} {option-value}
```


The following options are available:

 - `-i {path}`,`-install {path}`  Install the latest version of WebEngine.
 - `-u`,`-update` update the latest version of WEC-Function Files.
 - `-u {path}`,`-update {path}` update the latest version of WebEngine.
 - `-v {version}`,`-version {version}` install or update with specific version.
 - `-d {project root}`,`-database {project root}` initialize Database.
 
---


### WEC Update

First, install the function with the installed WEC command.

```cmd
C:\>wec -u
```

You can update the wc with the wc-update command.

```cmd
C:\>wec-update
```
 
 ---


### WEC Module

Various types of `Modules` can be installed.

```cmd
C:\>WEC-Module -i {module name} -p {project root} -v {version}
```

---

