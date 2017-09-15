<hr/>
<h1 align="center">
	Weeb.net
</h1>
<p align="center">
    A fast and easy to use weeb.sh API wrapper.
    <br>
	Originally build with Discord bots in mind like <a href='https://github.com/Daniele122898/SoraBot-v2'>Sora-v2</a>!
	<br>
	Join his Discord Server for support on the wrapper.
	<br>
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
### Creating a client and authentication
```csharp
//...
	WeebClient weebClient = new WeebClient();
	string token = "YOUR TOKEN";
	
	public async Task InitializeAsync()
	{
		//Will print current weeb.sh API version and Weeb.net wrapper version
		await weebClient.Authenticate(token);
	}
//...
```

### Getting all available tags
```csharp
//...
	public async Task<TagsData> GetTagsAsync(bool hidden)
	{
		return await weebClient.GetTagsAsync(hidden); //hidden is always defaulted to false
	}
//...
```

### Getting all available types
```csharp
//...
	public async Task<TypesData> GetTypesAsync(bool hidden)
	{
		return await weebClient.GetTypesAsync(hidden); //hidden is always defaulted to false
	}
//...
```

### Getting Random image with type and or tags
You must have at least either type or tags!
```csharp
//...
	public async Task<RandomData> GetTypesAsync(string type, IEnumerable<string> tags ,bool hidden, bool nsfw)
	{
		var result = await weebClient.GetRandomAsync(type, tags, hidden, nsfw); //hidden and nsfw are always defaulted to false

		if (result == null)
		{
			//Nothing was found do smth...
			//...
			return null
		}
		return result
	}
//...
```

## Models
### TagsData
```csharp
    public class TagsData
    {
        internal string Status { get; set; } //cannot be used in your program. only used for internal wrapper things :P
        public List<string> Tags { get; set; }
    }

```

### TypesData
```csharp
    public class TypesData    
    {
        internal string Status { get; set; } //cannot be used in your program. only used for internal wrapper things :P
        public List<string> Types { get; set; }
    }
```

### RandomData
```csharp
	public class RandomData
    {
        public string Id { get; set; }
        public string BaseType { get; set; }
        public string FileType { get; set; }
        public string MimeType { get; set; }
        public string Account { get; set; }
        public bool Hidden { get; set; }
        public bool Nsfw { get; set; }
        public List<Tags> Tags { get; set; }
        public string Url { get; set; }
    }

    public class Tags
    {
        public string Name { get; set; }
        public bool Hidden { get; set; }
        public string User { get; set; }
    }
```