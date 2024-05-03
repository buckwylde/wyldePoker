using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Security.Cryptography;
using System.Text.Json;

namespace wyldeLOGIC {

   /// <summary>
   /// RNG using System.Security.Cryptography.RandomNumberGenerator.GetBytes
   /// for random byte generation instead of System.Random.
   /// 
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
         //the only function that really does anything random, all the
         //other numeric types call getDbl and convert to what they need
         byte[] b = new byte[8]; rng.GetBytes(b);
         return (max-min)*(( double )BitConverter.ToUInt64(b, 0) / ulong.MaxValue) + min;
      }
      public float getSgl(float max = 1, float min = 0) { return ( float )getDbl(max, min); }

      // String functions
      public string getString(int len, string allowChar = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()/?,.;:[]_+-=") {
         string sTmp = string.Empty;// where we build our random string
         for (int i = 0;i<len;i++)
            sTmp += allowChar[getUInt16(( byte )(allowChar.Length - 1))];// pick a random byte from our allowed characters
         return sTmp;
      }
      public string getGUID() { return getString(32, "0123456789ABCDEF"); }

      // UInt functions 8/16/32/64
      public byte getUInt8(byte max = 255, byte min = 0) { return (( byte )Math.Round((getDbl() * (max - min) + min))); }
      public ushort getUInt16(ushort max = 65535, ushort min = 0) { return (( ushort )Math.Round((getDbl() * (max - min) + min))); }
      public uint getUInt32(uint max = uint.MaxValue, uint min = 0) { return (( uint )Math.Round((getDbl() * (max - min) + min))); }
      public ulong getUInt64(ulong max = ulong.MaxValue, ulong min = 0) { return (( ulong )Math.Round((getDbl() * (max - min) + min))); }

   } // class wyldeRNG

   public class wyldeFILEINFO {
      private string fp = string.Empty;// path only
      private string fn = string.Empty;// filename (with ext)
      public string Path { get { return fp; } set { fp=value; } }
      public string NameOnly { get { return fn; } set { fn=value; } }
      /// <summary>
      /// Full "Path + Filename.ext"
      /// </summary>
      public string Location {
         get { 
            return System.IO.Path.Combine(fp, fn);
         }// get
         set {
            fp = System.IO.Path.GetDirectoryName(value);
            if (fp==null) fp = ""; // GetDirectoryName can return null in certain cases, fix that here
            fn = System.IO.Path.GetFileName(value);
         }// set
      }
      public override string ToString() {
         return Location;
      }
   } // class wyldeFILEINFO

   public class wyldeSETTINGS {

      private Dictionary<string, string> settings = new Dictionary<string, string>();
      private const string EXT = "sav";// default settings file ext
      public wyldeFILEINFO FileInfo;

      // constructor
      public wyldeSETTINGS() {
         //init w/o settings file specified, create default path/filename from exe path/filename
         string sTmp = Assembly.GetExecutingAssembly().Location;// path + filename of the EXE
         FileInfo.Path = Path.GetDirectoryName(sTmp);
         if (FileInfo.Path==null) FileInfo.Path = ""; // GetDirectoryName can return null in certain cases, fix that here
         FileInfo.NameOnly = Path.GetFileNameWithoutExtension(sTmp)+EXT;// change file ext
      }
      public wyldeSETTINGS(string filename) {
         FileInfo.Location = filename;
      } //constructor


      // destructor
      ~wyldeSETTINGS() { 
         //
      } //destructor

      public bool ReadFile(string filename = "") {
         if (filename=="") filename=FileInfo.Location;
         if (!File.Exists(filename)) return false;
         //do stuff
         string jsonString = File.ReadAllText(filename);
         settings = JsonSerializer.Deserialize< Dictionary<string, string> >(jsonString);
         return true;
      }

      public bool WriteFile(string filename = "") {
         if (filename=="") filename=FileInfo.Location;
         //do stuff
         string jsonString = JsonSerializer.Serialize<Dictionary<string, string>>(settings);
         File.WriteAllText(filename, jsonString);
         return true;
      }

      public string Get(string key) {
         if (settings.ContainsKey(key))
            return settings[key];
         else
            return string.Empty;
      }
      public void Set(string key, string val) { 
         if(settings.ContainsKey(key))
            settings[key] = val;
         else settings.Add(key,val);
      }

   } // class wyldeSETTINGS

} // namespace
