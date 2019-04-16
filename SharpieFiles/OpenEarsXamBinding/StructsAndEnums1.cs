using System;
using System.Runtime.InteropServices;
using AudioToolbox;
using CoreAudio;

static class CFunctions
{
	// extern OSStatus ConverterDataCallback (AudioConverterRef inAudioConverter, UInt32 *ioNumberDataPackets, AudioBufferList *ioData, AudioStreamPacketDescription **outDataPacketDescription, void *inUserData);
	[DllImport ("__Internal")]
	[Verify (PlatformInvoke)]
	static extern unsafe int ConverterDataCallback (AudioConverterRef* inAudioConverter, uint* ioNumberDataPackets, AudioBufferList* ioData, AudioStreamPacketDescription** outDataPacketDescription, void* inUserData);
}

[StructLayout (LayoutKind.Explicit)]
public struct anytype_t
{
	[FieldOffset (0)]
	public unsafe void* ptr;

	[FieldOffset (0)]
	public nint i;

	[FieldOffset (0)]
	public nuint ui;

	[FieldOffset (0)]
	public double fl;
}
