using System;
using System.IO;
using System.Runtime.Serialization;
namespace CheckersLogic
{
	public partial class GameHistory : IFormatter
	{
		private SerializationBinder? _binder;
		private StreamingContext _context;
		private ISurrogateSelector? _surrogateSelector;
		
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
	}
}
