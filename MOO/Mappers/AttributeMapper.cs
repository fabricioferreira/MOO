﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright company="Diogo Lucas">
//
// Copyright (C) 2010 Diogo Lucas
//
// This file is part of Moo.
//
// Moo is free software: you can redistribute it and/or modify
// it under the +terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along Moo.  If not, see http://www.gnu.org/licenses/.
// </copyright>
// <summary>
// Moo is a object-to-object multi-mapper.
// Email: diogo.lucas@gmail.com
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Moo.Mappers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Moo.Core;

    /// <summary>
    /// Maps between two classes by using the mapping attributes in their members.
    /// </summary>
    /// <typeparam name="TSource">The type of the source.</typeparam>
    /// <typeparam name="TTarget">The type of the target.</typeparam>
    public class AttributeMapper<TSource, TTarget> : BaseMapper<TSource, TTarget>
    {
        #region Constructors (1) 

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeMapper&lt;TSource, TTarget&gt;"/> class.
        /// </summary>
        public AttributeMapper()
        {
            this.GenerateMappings();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AttributeMapper{TSource,TTarget}"/> class. 
        /// </summary>
        /// <param name="constructionInfo">Mapper construction information.</param>
        public AttributeMapper(MapperConstructionInfo constructionInfo)
            : base(constructionInfo)
        {
            this.GenerateMappings();
        }

        #endregion Constructors 

        #region Methods (3) 

        // Protected Methods (1) 

        /// <summary>
        /// Generates the member mappings and adds them to the provided <see cref="TypeMappingInfo{TSource, TTarget}"/> object.
        /// </summary>
        /// <param name="typeMapping">The type mapping where discovered mappings will be added.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage(
            "Microsoft.Design", 
            "CA1062:Validate arguments of public methods", 
            MessageId = "0",
            Justification = "The call to Guard does that.")]
        protected override void GenerateMappings(TypeMappingInfo<TSource, TTarget> typeMapping)
        {
            Guard.CheckArgumentNotNull(typeMapping, "typeMapping");
            var fromType = typeof(TSource);
            var toType = typeof(TTarget);

            foreach (var m in GetMappings(fromType, toType, MappingDirections.From))
            {
                typeMapping.Add(m);
            }

            foreach (var m in GetMappings(toType, fromType, MappingDirections.To))
            {
                typeMapping.Add(m);
            }
        }

        // Private Methods (2)

        /// <summary>
        /// Gets the property mapping for two property types.
        /// </summary>
        /// <param name="firstProp">The first property.</param>
        /// <param name="secondProp">The second property.</param>
        /// <param name="direction">The direction of the mapping.</param>
        /// <returns>A property mapping object.</returns>
        private static ReflectionPropertyMappingInfo<TSource, TTarget> GetMapping(
            PropertyInfo firstProp, 
            PropertyInfo secondProp,
            MappingDirections direction)
        {
            ReflectionPropertyMappingInfo<TSource, TTarget> mappingInfo = null;
            if (direction == MappingDirections.From)
            {
                mappingInfo = new ReflectionPropertyMappingInfo<TSource, TTarget>(
                    firstProp,
                    secondProp,
                    true);
            }
            else
            {
                mappingInfo = new ReflectionPropertyMappingInfo<TSource, TTarget>(
                    secondProp,
                    firstProp,
                    true);
            }

            return mappingInfo;
        }

        // Private Methods (1) 

        /// <summary>
        /// Adds the mappings based on the existing mapping attributes.
        /// </summary>
        /// <param name="sourceType">Type of the source.</param>
        /// <param name="targetType">Type of the target.</param>
        /// <param name="direction">The mapping direction.</param>
        /// <returns>An enumeration of property mappings.</returns>
        private static IEnumerable<ReflectionPropertyMappingInfo<TSource, TTarget>> GetMappings(
            Type sourceType,
            Type targetType,
            MappingDirections direction)
        {
            return from prop in sourceType.GetProperties()
                   from MappingAttribute m in prop.GetCustomAttributes(typeof(MappingAttribute), false)
                   where (m.Direction & direction) == direction
                   where m.OtherType.IsAssignableFrom(targetType)
                   select GetMapping(prop, targetType.GetProperty(m.OtherMemberName), direction);
        }

        #endregion Methods 
    }
}