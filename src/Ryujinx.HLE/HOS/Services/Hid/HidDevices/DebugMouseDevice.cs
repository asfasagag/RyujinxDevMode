using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.Common;
using Ryujinx.HLE.HOS.Services.Hid.Types.SharedMemory.DebugMouse;

namespace Ryujinx.HLE.HOS.Services.Hid
{
    public class DebugMouseDevice : BaseDevice
    {
        public DebugMouseDevice(Switch device, bool active) : base(device, active) { }

        public void Update(int mouseX, int mouseY, uint buttons = 0, int scrollX = 0, int scrollY = 0, bool connected = false)
        {
            ref RingLifo<DebugMouseState> lifo = ref _device.Hid.SharedMemory.DebugMouse;

            ref DebugMouseState previousEntry = ref lifo.GetCurrentEntryRef();

            DebugMouseState newState = new()
            {
                SamplingNumber = previousEntry.SamplingNumber + 1,
            };

            if (Active)
            {
                newState.Buttons = (DebugMouseButton)buttons;
                newState.X = mouseX;
                newState.Y = mouseY;
                newState.DeltaX = mouseX - previousEntry.X;
                newState.DeltaY = mouseY - previousEntry.Y;
                newState.WheelDeltaX = scrollX;
                newState.WheelDeltaY = scrollY;
                newState.Attributes = connected ? DebugMouseAttribute.IsConnected : DebugMouseAttribute.None;
            }

            lifo.Write(ref newState);
        }
    }
}
