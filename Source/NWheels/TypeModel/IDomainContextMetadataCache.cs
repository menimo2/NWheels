﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWheels.TypeModel
{
    public interface IDomainContextMetadataCache
    {
        IDomainContextMetadata GetDomainContextMetadata(Type contextType);
    }
}
