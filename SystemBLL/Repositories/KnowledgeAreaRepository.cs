using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemDAL.Entities.Context;
using SystemDAL.Entities.Knowledges;

namespace SystemDAL.Repositories
{
    public class KnowledgeAreaRepository
    {
        private KnowledgeContext _knowledgeContext;
        public KnowledgeAreaRepository(KnowledgeContext knowladgeContext)
        {
            _knowledgeContext = knowladgeContext;
        }

    }
}
