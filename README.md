<hr/>
<h1 align="center">
	Weeb.net
</h1>
<p align="center">
    A fast and easy to use weeb.sh API wrapper.
    <br>
	Originally build with Discord bots in mind like <a href='https://github.com/Daniele122898/SoraBot-v2'>Sora-v2</a>
	<br>
	Join his Discord Server for support on the wrapper.
	<br>
    <a href="https://discord.gg/Pah4yj5">
        <img src="https://discordapp.com/api/guilds/281589163659362305/widget.png?style=banner2">
    </a>
</p>
<hr/>
[![NuGet](https://img.shields.io/nuget/vpre/Weeb.net.svg?maxAge=2592000?style=plastic)](https://www.nuget.org/packages/Weeb.net/)
# Installation
## Nuget
Frequently updated on Nuget. Versioning follows Semver. 
- [Weeb.net nuget](https://www.nuget.org/packages/Weeb.net/)

### Dependencies
- .NETStandard 2.0
- [Newtonsoft.Json (>=10.0.3)](https://www.nuget.org/packages/Newtonsoft.Json/)

# Usage
### Creating a client and Authentication
Example: 
```csharp
//...
	WeebClient weebClient = new WeebClient();
	string token = "YOUR TOKEN";
	
	public async Task InitializeAsync()
	{
		//Will print current weeb.sh API version and Weeb.net wrapper version
		await weebClient.Authenticate(token);
	}

```