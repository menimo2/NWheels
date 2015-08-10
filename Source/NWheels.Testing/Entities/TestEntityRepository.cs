﻿using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using NWheels.Conventions.Core;
using NWheels.DataObjects;
using NWheels.DataObjects.Core;
using NWheels.Entities;
using NWheels.Entities.Core;
using NWheels.Extensions;
using NWheels.Utilities;

namespace NWheels.Testing.Entities
{
    public class TestEntityRepository<TEntity> : IEntityRepository<TEntity>, IEntityRepository
        where TEntity : class
    {
        private readonly EntityObjectFactory _objectFactory;
        private readonly HashSet<TEntity> _storedEntities;
        private readonly IDomainObjectFactory _domainObjectFactory;
        private readonly IComponentContext _components;

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        public TestEntityRepository(IComponentContext components, EntityObjectFactory objectFactory, IDomainObjectFactory domainObjectFactory)
        {
            _components = components;
            _objectFactory = objectFactory;
            _storedEntities = new HashSet<TEntity>();
            _domainObjectFactory = domainObjectFactory;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        #region Implementation of IEntityRepository

        object IEntityRepository.New()
        {
            return ((IEntityRepository<TEntity>)this).New();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        object IEntityRepository.New(Type concreteContract)
        {
            return ((IEntityRepository<TEntity>)this).New(concreteContract);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        void IEntityRepository.Insert(object entity)
        {
            ((IEntityRepository<TEntity>)this).Insert((TEntity)entity);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        void IEntityRepository.Update(object entity)
        {
            ((IEntityRepository<TEntity>)this).Update((TEntity)entity);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        void IEntityRepository.Delete(object entity)
        {
            ((IEntityRepository<TEntity>)this).Delete((TEntity)entity);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        Type IEntityRepository.ContractType
        {
            get
            {
                return typeof(TEntity);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        Type IEntityRepository.ImplementationType
        {
            get
            {
                return typeof(TEntity);
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        ITypeMetadata IEntityRepository.Metadata
        {
            get
            {
                throw new NotImplementedException();
            }
        }

        #endregion

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        TEntity IEntityRepository<TEntity>.New()
        {
            return _domainObjectFactory.CreateDomainObjectInstance(_objectFactory.NewEntity<TEntity>());
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        TConcreteEntity IEntityRepository<TEntity>.New<TConcreteEntity>() 
        {
            return _domainObjectFactory.CreateDomainObjectInstance(_objectFactory.NewEntity<TConcreteEntity>());
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        TEntity IEntityRepository<TEntity>.New(Type concreteContract)
        {
            return _domainObjectFactory.CreateDomainObjectInstance((TEntity)_objectFactory.NewEntity(concreteContract));
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        IQueryable<TEntity> IEntityRepository<TEntity>.Include(params System.Linq.Expressions.Expression<Func<TEntity, object>>[] properties)
        {
            return this;
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        void IEntityRepository<TEntity>.Insert(TEntity entity)
        {
            _storedEntities.Add(entity);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        void IEntityRepository<TEntity>.Update(TEntity entity)
        {
            _storedEntities.Add(entity);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        void IEntityRepository<TEntity>.Delete(TEntity entity)
        {
            _storedEntities.Remove(entity);
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        TEntity IEntityRepository<TEntity>.CheckOutOne<TState>(System.Linq.Expressions.Expression<Func<TEntity, bool>> where, System.Linq.Expressions.Expression<Func<TEntity, TState>> stateProperty, TState newStateValue)
        {
            throw new NotImplementedException();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        IEnumerator<TEntity> IEnumerable<TEntity>.GetEnumerator()
        {
            return _storedEntities.GetEnumerator();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return _storedEntities.GetEnumerator();
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        Type IQueryable.ElementType
        {
            get { return _storedEntities.AsQueryable().ElementType; }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        System.Linq.Expressions.Expression IQueryable.Expression
        {
            get { return _storedEntities.AsQueryable().Expression; }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        IQueryProvider IQueryable.Provider
        {
            get { return _storedEntities.AsQueryable().Provider; }
        }
    }
}
