﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWheels.UI.Toolbox
{
    public class EntityCrud<TEntity> : WidgetComponent<EntityCrud<TEntity>, Empty.Data, Empty.State>
    {
        public override void DescribePresenter(IWidgetPresenter<EntityCrud<TEntity>, Empty.Data, Empty.State> presenter)
        {
        }
    }
}