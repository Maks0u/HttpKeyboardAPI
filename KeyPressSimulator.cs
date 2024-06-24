using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;

public static class KeyPressSimulator
{
  [DllImport("user32.dll")]
  private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, IntPtr dwExtraInfo);

  private const uint KEYEVENTF_KEYUP = 0x0002;
  private const uint KEYEVENTF_EXTENDEDKEY = 0x0001;

  public static void PressKeys(IEnumerable<byte> keyCodes)
  {
    // Press keys
    foreach (var keyCode in keyCodes)
    {
      keybd_event(keyCode, 0, KEYEVENTF_EXTENDEDKEY, IntPtr.Zero);
    }

    // Release keys in reverse order
    foreach (var keyCode in keyCodes.Reverse())
    {
      keybd_event(keyCode, 0, KEYEVENTF_EXTENDEDKEY | KEYEVENTF_KEYUP, IntPtr.Zero);
    }
  }
}