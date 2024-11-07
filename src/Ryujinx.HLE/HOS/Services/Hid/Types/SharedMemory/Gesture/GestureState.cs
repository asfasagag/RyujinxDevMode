using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
using System.Runtime.InteropServices;

namespace Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Gesture
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    struct GestureState : ISampledDataStruct
    {
        public ulong SamplingNumber;
        public ulong ContextNumber;
        public int Type;
        public int Direction;
        public int X;
        public int Y;
        public int DeltaX;
        public int DeltaY;
        public float VelocityX;
        public float VelocityY;
        public uint GestureAttributeSet;
        public float Scale;
        public float RotationAngle;
        public int PointCount;
        public ulong GesturePoint0;
        public ulong GesturePoint1;
        public ulong GesturePoint2;
        public ulong GesturePoint3;
    }
}
