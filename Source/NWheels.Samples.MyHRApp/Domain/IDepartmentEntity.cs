﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWheels.DataObjects;
using NWheels.Entities;
using NWheels.Stacks.MongoDb;

namespace NWheels.Samples.MyHRApp.Domain
{
    [EntityContract]
    public interface IDepartmentEntity
    {
        [PropertyContract.AutoGenerate(typeof(AutoIncrementIntegerIdGenerator))]
        int Id { get; }

        [PropertyContract.Required, PropertyContract.Semantic.DisplayName]
        string Name { get; set; }

        [PropertyContract.Relation.Aggregation, PropertyContract.Relation.ManyToOne]
        IEmployeeEntity Manager { get; set; }

        [PropertyContract.Relation.Aggregation, PropertyContract.Relation.ManyToMany]
        ICollection<IPositionEntity> Positions { get; }

        [PropertyContract.Calculated]
        string ManagerName { get; }

        [PropertyContract.Calculated]
        string ListOfPositions { get; }
    }

    //---------------------------------------------------------------------------------------------------------------------------------------------------------

    public abstract class DepartmentEntity : IDepartmentEntity
    {
        #region Implementation of IDepartmentEntity

        public abstract int Id { get; }
        public abstract string Name { get; set; }
        public abstract IEmployeeEntity Manager { get; set; }
        public abstract ICollection<IPositionEntity> Positions { get; }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        public string ManagerName
        {
            get
            {
                return Manager.Name.FullName;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        public string ListOfPositions
        {
            get
            {
                return string.Join(", ", Positions.Select(p => p.Name));
            }
        }

        #endregion
    }
}
