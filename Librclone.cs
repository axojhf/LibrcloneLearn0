using LibrcloneLearn0.RAW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LibrcloneLearn0;

internal class Librclone
{
    static Librclone()
    {
        Methods.RcloneInitialize();
    }

    ~Librclone()
    {
        Methods.RcloneFinalize();
    }

    public static RPCResult RPC(string method, string input)
    {
        unsafe
        {
            var p_method = Marshal.StringToCoTaskMemUTF8(method);
            var p_input = Marshal.StringToCoTaskMemUTF8(input);
            var result = Methods.RcloneRPC((sbyte*)p_method, (sbyte*)p_input);
            var ret = new RPCResult
            {
                Output = Marshal.PtrToStringUTF8((IntPtr)result.Output) ?? "",
                Status = result.Status
            };
            Methods.RcloneFreeString(result.Output);
            Marshal.FreeCoTaskMem(p_method);
            Marshal.FreeCoTaskMem(p_input);
            return ret;
        }
    }
}

public class RPCResult
{
    public string Output = "";

    public int Status;
}