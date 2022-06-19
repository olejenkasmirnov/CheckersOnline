using System;
using System.Runtime.Serialization;
namespace Models.Checkers
{
	public partial class Player
	{
		internal Player(SerializationInfo info, StreamingContext context)
		{
			Guid = new Guid(info.GetString("Id")!);

			Name = info.GetString("Name")!;
		}
		[OnSerializing]
		private void OnSerializing(StreamingContext context)
		{}
		
		[OnSerialized]
		private void OnSerialized(StreamingContext context)
		{}
		
		[OnDeserializing]
		private void OnDeserializing(StreamingContext context)
		{}
		
		[OnDeserialized]
		private void OnDeserialized(StreamingContext context)
		{}
		
		public void GetObjectData(SerializationInfo info, StreamingContext context)
		{}
		
		void IDeserializationCallback.OnDeserialization(object? sender)
		{}
	}
}
