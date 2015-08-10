﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using NWheels.Utilities;

namespace NWheels.Extensions
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T> ConcatIf<T>(this IEnumerable<T> first, IEnumerable<T> secondOrNull) where T : class
        {
            if (secondOrNull != null)
            {
                return first.Concat(secondOrNull);
            }
            else
            {
                return first;
            }
        }

        //-----------------------------------------------------------------------------------------------------------------------------------------------------

        public static IEnumerable<T> InjectDependenciesFrom<T>(this IEnumerable<T> source, IComponentContext components)
        {
            if ( components != null && source != null )
            {
                return new ObjectUtility.DependencyInjectingEnumerable<T>(source, components);
            }
            else
            {
                return source;
            }
        }
    }
}
