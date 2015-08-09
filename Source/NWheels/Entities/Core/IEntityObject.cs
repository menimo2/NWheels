﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NWheels.DataObjects.Core;

namespace NWheels.Entities.Core
{
    public interface IEntityObject : IObject, IPersistableObject
    {
        IEntityId GetId();
        void SetId(object value);
    }
}
