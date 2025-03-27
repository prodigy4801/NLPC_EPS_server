using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Persistence.DataAccess
{
    public class SequentialGuidStringGenerator : ValueGenerator<string>
    {
        private readonly SequentialGuidValueGenerator guidGenerator = new SequentialGuidValueGenerator();

        public override string Next(EntityEntry entry) => guidGenerator.Next(entry).ToString();

        public override bool GeneratesTemporaryValues => false;
    }
}
