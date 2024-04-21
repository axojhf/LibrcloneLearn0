using LibrcloneLearn0;
using System.Text.Json;

//获取程序当前目录
var currentDirectory = Directory.GetCurrentDirectory();
//拼接rclone.conf
var rcloneConf = Path.Combine(currentDirectory, "rclone.conf");
var setPathStr = JsonSerializer.Serialize(new CONFIG_SETPATH { path = rcloneConf }, CONFIG_SETPATHContext.Default.CONFIG_SETPATH);
Librclone.RPC("config/setpath", setPathStr);
var list_remotes_result = Librclone.RPC("config/listremotes", "");
var list_remotes = JsonSerializer.Deserialize(list_remotes_result.Output, LIST_REMOTESContext.Default.LIST_REMOTES);
if (list_remotes is null || list_remotes.remotes.Length == 0)
{
    Console.WriteLine("no remotes");
    return;
}
var remote = list_remotes.remotes[0];
var operationsListStr = JsonSerializer.Serialize(new OPERATIONS_LIST { fs = $"{remote}:", remote = "" }, OPERATIONS_LISTContext.Default.OPERATIONS_LIST);
var operations_list = Librclone.RPC("operations/list", operationsListStr);
Console.WriteLine(operations_list.Output);
