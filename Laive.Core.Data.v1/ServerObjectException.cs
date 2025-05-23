using System.Runtime.Serialization;
using System;

namespace Laive.Core.Data
{
   [Serializable()]
   public class ServerObjectException : ApplicationException
   {

      private int _intNumber = 0;
      public int Number
      {
         get { return _intNumber; }
      }

      public ServerObjectException(string message)
         : base(message)
      {
      }

      public ServerObjectException(int number, string message)
         : base(message)
      {
         _intNumber = number;

      }

      public ServerObjectException(SerializationInfo info, StreamingContext context)
         : base(info, context)
      {
      }

      public ServerObjectException(int number, SerializationInfo info, StreamingContext context)
         : base(info, context)
      {
         _intNumber = number;
      }

      public ServerObjectException(string message, Exception inner)
         : base(message, inner)
      {
      }

      public override void GetObjectData(SerializationInfo info, StreamingContext context)
      {
         base.GetObjectData(info, context);
      }

   }
}