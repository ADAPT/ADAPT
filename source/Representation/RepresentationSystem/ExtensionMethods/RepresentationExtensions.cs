﻿/*******************************************************************************
  * Copyright (C) 2015 AgGateway and ADAPT Contributors
  * Copyright (C) 2015 Deere and Company
  * All rights reserved. This program and the accompanying materials
  * are made available under the terms of the Eclipse Public License v1.0
  * which accompanies this distribution, and is available at
  * http://www.eclipse.org/legal/epl-v10.html <http://www.eclipse.org/legal/epl-v10.html> 
  *
  * Contributors:
  *    Tarak Reddy, Tim Shearouse - initial API and implementation
  *******************************************************************************/
using System.Linq;
using AgGateway.ADAPT.ApplicationDataModel.Common;
using AgGateway.ADAPT.ApplicationDataModel.Representations;

namespace AgGateway.ADAPT.Representation.RepresentationSystem.ExtensionMethods
{
   public static class RepresentationExtensions
   {
      public static ApplicationDataModel.Representations.NumericRepresentation ToModelRepresentation(this NumericRepresentation representation)
      {
          var numericRepresentation = new ApplicationDataModel.Representations.NumericRepresentation
          {
              Code = representation.DomainId,
              Description = representation.Description,
              CodeSource = RepresentationCodeSourceEnum.ADAPT
          };
          if (representation.Ddi.HasValue)
          {
            numericRepresentation.Id.UniqueIds.Add(new UniqueId
            {
               Id = representation.Ddi.Value.ToString(),
               IdType = IdTypeEnum.LongInt,
               Source = "http://dictionary.isobus.net/isobus/",
               SourceType = IdSourceTypeEnum.URI
            });
          }
          return numericRepresentation;
      }

       public static ApplicationDataModel.Representations.EnumeratedRepresentation ToModelRepresentation(this EnumeratedRepresentation representation)
      {
          var enumeratedRepresentation = new ApplicationDataModel.Representations.EnumeratedRepresentation
          {
              Code = representation.DomainId,
              Description = representation.Description,
              CodeSource = RepresentationCodeSourceEnum.ADAPT,
              EnumeratedMembers = representation.EnumerationMembers.Select(m => m.ToModelEnumMember()).ToList(),
          };
          if (representation.Ddi.HasValue)
          {
            enumeratedRepresentation.Id.UniqueIds.Add(new UniqueId
            {
               Id = representation.Ddi.Value.ToString(),
               IdType = IdTypeEnum.LongInt,
               Source = "http://dictionary.isobus.net/isobus/",
               SourceType = IdSourceTypeEnum.URI
            });
          }
          return enumeratedRepresentation;
      }

       public static ApplicationDataModel.Representations.EnumerationMember ToModelEnumMember(this EnumerationMember enumMember)
      {
         return new ApplicationDataModel.Representations.EnumerationMember
         {
            Code = (int)enumMember.DomainTag,
            Value = enumMember.Name
         };
      }

      public static EnumerationMember ToInternalEnumMember(this EnumeratedValue enumMember)
      {
         var representation = enumMember.Representation.ToInternalRepresentation();
         return representation.EnumerationMembers.First(em => em.DomainTag == enumMember.Value.Code);
      }

      public static NumericRepresentation ToInternalRepresentation(this ApplicationDataModel.Representations.NumericRepresentation representation)
      {
         return (NumericRepresentation)RepresentationManager.Instance.Representations[representation.Code];
      }

      public static EnumeratedRepresentation ToInternalRepresentation(this ApplicationDataModel.Representations.EnumeratedRepresentation representation)
      {
         return (EnumeratedRepresentation)RepresentationManager.Instance.Representations[representation.Code];
      }
   }
}
