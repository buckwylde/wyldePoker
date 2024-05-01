using System;
using System.Security.Cryptography;

namespace wyldeLOGIC {

   /// <summary>
   /// RNG using System.Security.Cryptography.RandomNumberGenerator.GetBytes
   /// for random byte generation instead of System.Random.
   /// Generates 8 bytes, converts to UInt64, div by UInt64.MaxValue to convert
   /// to double and scale 0-1, then scale min to max - [0->1]*(max-min)+min
   /// </summary>
   public class wyldeRNG {
      private readonly RandomNumberGenerator rng;
      //constructor
      public wyldeRNG() { rng = RandomNumberGenerator.Create(); }
      //destructor
      ~wyldeRNG() { rng.Dispose(); }

      // floating point functions
      public double getDbl(double max = 1.0, double min = 0.0) {
         byte[] b = new byte[8]; rng.GetBytes(b);
         return (max-min)*(( double )BitConverter.ToUInt64(b, 0) / ulong.MaxValue) + min;
      }
      public float getSgl(float max = 1, float min = 0) { return ( float )getDbl(max, min); }

      // String functions
      public string getString(int len, string allowChar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()/?,.;:[]_+-=") {
         string sTmp = string.Empty;
         for (int i = 0;i<len;i++)
            sTmp += allowChar[getUInt8(( byte )(allowChar.Length - 1))];
         return sTmp;
      }
      public string getGUID() { return getString(32, "0123456789ABCDEF"); }

      // UInt functions 8/16/32/64
      public byte getUInt8(byte max = 255, byte min = 0) { return (( byte )Math.Round((getDbl() * (max - min) + min))); }
      public ushort getUInt16(ushort max = 65535, ushort min = 0) { return (( ushort )Math.Round((getDbl() * (max - min) + min))); }
      public uint getUInt32(uint max = uint.MaxValue, uint min = 0) { return (( uint )Math.Round((getDbl() * (max - min) + min))); }
      public ulong getUInt64(ulong max = ulong.MaxValue, ulong min = 0) { return (( ulong )Math.Round((getDbl() * (max - min) + min))); }
   } // class wyldeRNG

   public class wyldeSETTINGS {

      // constructor
      public wyldeSETTINGS() {
         string fp = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
         if (fp==null) fp = "";
         string fn = System.IO.Path.GetFileNameWithoutExtension(System.Reflection.Assembly.GetExecutingAssembly().Location)+".wyldeinit";
         filename_ = System.IO.Path.Combine(fp, fn);
      } //constructor
      // destructor
      ~wyldeSETTINGS() { }

      private string filename_ = string.Empty;
      public string fileName {
         get => (filename_);
         set {
            if (System.IO.File.Exists(value)) {
               filename_ = value;
            }
         } // set
      } // filename property

   } // class wyldeSettings

} // namespace
