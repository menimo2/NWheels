﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWheels.UI.Toolbox
{
    public interface IAccessParentData<TParentData>
    {
        TParentData ParentData { get; set; }
    }
}