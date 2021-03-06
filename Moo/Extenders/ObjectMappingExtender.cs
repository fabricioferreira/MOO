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

using System.Diagnostics.CodeAnalysis;
using Moo.Core;

namespace Moo.Extenders
{
    /// <summary>
    ///     Extends the <c>Object</c> class, providing mapping capabilities for all objects.
    /// </summary>
    public static class ObjectMappingExtender
    {
        #region Methods

        /// <summary>
        ///     Maps the values on object the to a target type.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="source">The source object.</param>
        /// <returns>
        ///     The target object, filled according to the mapping instructions in the mapper provided provided by the default
        ///     repository.
        /// </returns>
        [SuppressMessage("Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "The call to Guard already does that.")]
        public static TTarget MapTo<TTarget>(this object source)
        {
            return MapTo<TTarget>(source, MappingRepository.Default);
        }

        /// <summary>
        ///     Maps the values on object the to a target type.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="mapper">The mapper to be used.</param>
        /// <returns>
        ///     The target object, filled according to the mapping instructions in the provided mapper.
        /// </returns>
        [SuppressMessage(
            "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "The call to Guard already does that."),
         SuppressMessage(
             "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
             Justification = "The call to Guard already does that.")]
        public static TTarget MapTo<TTarget>(this object source, IMapper mapper)
        {
            Guard.CheckArgumentNotNull(source, "source");
            Guard.CheckArgumentNotNull(mapper, "mapper");
            return (TTarget) mapper.Map(source);
        }

        /// <summary>
        ///     Maps the values on object the to a target type.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="repo">The repository that will provide the mapper.</param>
        /// <returns>
        ///     The target object, filled according to the mapping instructions in the mapper provided provided by the repository.
        /// </returns>
        [SuppressMessage(
            "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "The call to Guard already does that."),
         SuppressMessage(
             "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
             Justification = "The call to Guard already does that.")]
        public static TTarget MapTo<TTarget>(this object source, IMappingRepository repo)
        {
            Guard.CheckArgumentNotNull(source, "source");
            Guard.CheckArgumentNotNull(repo, "repo");
            IMapper mapper = repo.ResolveMapper(source.GetType(), typeof (TTarget));
            return (TTarget) mapper.Map(source);
        }

        /// <summary>
        ///     Maps the values on object the to a target type.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="target">The target object.</param>
        /// <returns>
        ///     The target object, filled according to the mapping instructions in the mapper provided provided by the default
        ///     repository.
        /// </returns>
        [SuppressMessage(
            "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "The call to Guard already does that."),
         SuppressMessage(
             "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
             Justification = "The call to Guard already does that.")]
        public static TTarget MapTo<TTarget>(this object source, TTarget target)
        {
            return MapTo(source, target, MappingRepository.Default);
        }

        /// <summary>
        ///     Maps the values on the object to a target object.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="target">The target object.</param>
        /// <param name="mapper">The mapper to be used.</param>
        /// <returns>
        ///     The target object, filled according to the mapping instructions in the provided mapper.
        /// </returns>
        [SuppressMessage(
            "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "The call to Guard already does that."),
         SuppressMessage(
             "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
             Justification = "The call to Guard already does that."),
         SuppressMessage(
             "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2",
             Justification = "The call to Guard already does that.")]
        public static TTarget MapTo<TTarget>(this object source, TTarget target, IMapper mapper)
        {
            Guard.CheckArgumentNotNull(source, "source");
            Guard.CheckArgumentNotNull(target, "target");
            Guard.CheckArgumentNotNull(mapper, "mapper");
            return (TTarget) mapper.Map(source, target);
        }

        /// <summary>
        ///     Maps the values on object the to a target type.
        /// </summary>
        /// <typeparam name="TTarget">The type of the target.</typeparam>
        /// <param name="source">The source object.</param>
        /// <param name="target">The target object.</param>
        /// <param name="repo">The repository that will provide the mapper.</param>
        /// <returns>
        ///     The target object, filled according to the mapping instructions in the mapper provided provided by the repository.
        /// </returns>
        [SuppressMessage(
            "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "0",
            Justification = "The call to Guard already does that."),
         SuppressMessage(
             "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "1",
             Justification = "The call to Guard already does that."),
         SuppressMessage(
             "Microsoft.Design", "CA1062:Validate arguments of public methods", MessageId = "2",
             Justification = "The call to Guard already does that.")]
        public static TTarget MapTo<TTarget>(this object source, TTarget target, IMappingRepository repo)
        {
            Guard.CheckArgumentNotNull(source, "source");
            Guard.CheckArgumentNotNull(target, "target");
            Guard.CheckArgumentNotNull(repo, "repo");
            IMapper mapper = repo.ResolveMapper(source.GetType(), typeof (TTarget));
            return (TTarget) mapper.Map(source, target);
        }

        #endregion Methods
    }
}