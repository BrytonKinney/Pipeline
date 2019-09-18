using System;
using System.Collections.Generic;
using System.Text;

namespace Pipeline.Shared.Entities.Repositories
{
    public class Repository
    {
        public string Name { get; set; }

        public IEnumerable<ChangeSets> Changes { get; set; }
    }
}
