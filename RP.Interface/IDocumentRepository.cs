using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using RP.Interfaces;
using RP.Model;

namespace RP.Interfaces
{
	public interface IDocumentRepository : IRepository<RP.Model.Document>
	{
        void AddNewDocument(Model.Document document, string customerCode);
        void UpdateDocument(Model.Document document);
    }
}
