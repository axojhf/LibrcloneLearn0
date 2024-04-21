using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LibrcloneLearn0;

struct CONFIG_SETPATH
{
    public string path { get; set; }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(CONFIG_SETPATH))]
internal partial class CONFIG_SETPATHContext : JsonSerializerContext
{
}

struct OPERATIONS_LIST
{
    public string fs { get; set; }
    public string remote { get; set; }
    public string opt { get; set; }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(OPERATIONS_LIST))]
internal partial class OPERATIONS_LISTContext : JsonSerializerContext
{
}


public class LIST_REMOTES
{
    public string[] remotes { get; set; }
}

[JsonSourceGenerationOptions(WriteIndented = true)]
[JsonSerializable(typeof(LIST_REMOTES))]
internal partial class LIST_REMOTESContext : JsonSerializerContext
{
}