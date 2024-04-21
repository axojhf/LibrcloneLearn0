using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace LibrcloneLearn0.RAW
{
    public unsafe partial struct _GoString_
    {
        [NativeTypeName("const char *")]
        public sbyte* p;

        [NativeTypeName("ptrdiff_t")]
        public nint n;
    }

    public unsafe partial struct RcloneRPCResult
    {
        [NativeTypeName("char *")]
        public sbyte* Output;

        public int Status;
    }

    public unsafe partial struct GoInterface
    {
        public void* t;

        public void* v;
    }

    public unsafe partial struct GoSlice
    {
        public void* data;

        [NativeTypeName("GoInt")]
        public long len;

        [NativeTypeName("GoInt")]
        public long cap;
    }

    public static unsafe partial class Methods
    {
        [DllImport("librclone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void RcloneInitialize();

        [DllImport("librclone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void RcloneFinalize();

        [DllImport("librclone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        [return: NativeTypeName("struct RcloneRPCResult")]
        public static extern RcloneRPCResult RcloneRPC([NativeTypeName("char *")] sbyte* method, [NativeTypeName("char *")] sbyte* input);

        [DllImport("librclone", CallingConvention = CallingConvention.Cdecl, ExactSpelling = true)]
        public static extern void RcloneFreeString([NativeTypeName("char *")] sbyte* str);
    }

    /// <summary>Defines the type of a member as it was used in the native signature.</summary>
    [AttributeUsage(AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, AllowMultiple = false, Inherited = true)]
    [Conditional("DEBUG")]
    internal sealed partial class NativeTypeNameAttribute : Attribute
    {
        private readonly string _name;

        /// <summary>Initializes a new instance of the <see cref="NativeTypeNameAttribute" /> class.</summary>
        /// <param name="name">The name of the type that was used in the native signature.</param>
        public NativeTypeNameAttribute(string name)
        {
            _name = name;
        }

        /// <summary>Gets the name of the type that was used in the native signature.</summary>
        public string Name => _name;
    }
}
