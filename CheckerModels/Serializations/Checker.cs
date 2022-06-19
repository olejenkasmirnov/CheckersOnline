using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using CheckersLogic.Enums;

namespace Models.Checkers
{
	public partial class Checker : IFormatter, ISerializable, IDeserializationCallback
	{
		private SerializationBinder? _binder;
		private StreamingContext _context;
		private ISurrogateSelector? _surrogateSelector;
		internal Checker(SerializationInfo info, StreamingContext context)
		{
			Owner = new Player(info, context);

			Type = (CheckerType)info.GetByte("Type");
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
		{
			
		}
		
		void IDeserializationCallback.OnDeserialization(object? sender)
		{}
		public object Deserialize(Stream serializationStream)
		{
			throw new NotImplementedException();
		}
		public void Serialize(Stream serializationStream, object graph)
		{
			throw new NotImplementedException();
		}
		public SerializationBinder? Binder
		{
			get => _binder;
			set => _binder = value;
		}
		public StreamingContext Context
		{
			get => _context;
			set => _context = value;
		}
		public ISurrogateSelector? SurrogateSelector
		{
			get => _surrogateSelector;
			set => _surrogateSelector = value;
		}


		public void Test()
		{
			Checker tc = new Checker();
			MemoryStream fs = new MemoryStream();
			BinaryFormatter bf = new BinaryFormatter();

			bf.Serialize(fs, tc);
			fs.Close();
		}
	}
}
