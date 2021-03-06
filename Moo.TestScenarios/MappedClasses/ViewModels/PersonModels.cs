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
namespace Moo.TestScenarios.MappedClasses.ViewModels
{
    using Moo.TestScenarios.MappedClasses.DomainModels;
    using System;

    public class PersonIndexModel
    {
        public int Id { get; set; }

        [Mapping(MappingDirections.Target, typeof(Person), "FirstName")]
        public string Name { get; set; }

        public string AccountLogin { get; set; }

        public string Email { get; set; }

        public string ManagerName { get; set; }

        [Mapping(MappingDirections.Target, typeof(Person), "LastName")]
        public string MessyProp { get; set; }

        public DateTime? BirthDate { get; set; }
    }

    public class PersonEditModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AccountLogin { get; set; }

        public string AccountPassword { get; set; }

        public int ManagerId { get; set; }

        public string Email { get; set; }
    }
}
