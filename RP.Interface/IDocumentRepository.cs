using System;

using RP.Interfaces;
using RP.Model;

namespace RP.Interfaces
{
	public interface IDocumentRepository : IRepository<RP.Model.Document>
	{
        void AddNewDocument(Model.Document document, string customerCode);

    }
}
