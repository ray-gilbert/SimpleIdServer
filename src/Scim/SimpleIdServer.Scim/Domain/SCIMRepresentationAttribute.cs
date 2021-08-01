﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using System;
using System.Diagnostics;

namespace SimpleIdServer.Scim.Domain
{
    [DebuggerDisplay("FullPath = {FullPath}, Id = {Id}, ParentAttributeId = {ParentAttributeId}, AttributeId = {AttributeId}")]
    public class SCIMRepresentationAttribute : ICloneable, IComparable<SCIMRepresentationAttribute>
    {
        public SCIMRepresentationAttribute()
        {
        }

        public SCIMRepresentationAttribute(string id, string attributeId) : this()
        {
            Id = id;
            AttributeId = attributeId;
        }

        public SCIMRepresentationAttribute(string id, string attributeId, SCIMSchemaAttribute schemaAttribute, int? valueInteger = null, 
            bool? valueBoolean = null, 
            string valueString = null, 
            DateTime? valueDateTime = null,
            decimal? valueDecimal = null,
            string valueBinary = null,
            string valueReference = null) : this(id, attributeId)
        {
            SchemaAttribute = schemaAttribute;
            ValueInteger = valueInteger;
            ValueBoolean = valueBoolean;
            ValueString = valueString;
            ValueDateTime = valueDateTime;
            ValueDecimal = valueDecimal;
            ValueBinary = valueBinary;
            ValueReference = valueReference;
            if (schemaAttribute != null)
            {
                FullPath = schemaAttribute.FullPath;
                SchemaAttributeId = schemaAttribute.Id;
            }
        }

        public string Id { get; set; }
        public string AttributeId { get; set; }
        public string ParentAttributeId { get; set; }
        public string SchemaAttributeId { get; set; }
        public string RepresentationId { get; set; }
        public string FullPath { get; set; }
        public string ValueString { get; set; }
        public bool? ValueBoolean { get; set; }
        public int? ValueInteger { get; set; }
        public DateTime? ValueDateTime { get; set; }
        public string ValueReference { get; set; }
        public decimal? ValueDecimal { get; set; }
        public string ValueBinary { get; set; }
        public SCIMSchemaAttribute SchemaAttribute { get; set; }
        public SCIMRepresentation Representation { get; set; }

        public bool IsReadable(bool isGetRequest = false)
        {
            if (SchemaAttribute.Returned == SCIMSchemaAttributeReturned.NEVER
                || SchemaAttribute.Mutability == SCIMSchemaAttributeMutabilities.WRITEONLY
                || SchemaAttribute.Returned == SCIMSchemaAttributeReturned.REQUEST && isGetRequest)
            {
                return false;
            }
            
            return true;
        }

        public bool IsSimilar(SCIMRepresentationAttribute attr)
        {
            if (attr.AttributeId != AttributeId)
            {
                return false;
            }

            switch (attr.SchemaAttribute.Type)
            {
                case SCIMSchemaAttributeTypes.STRING:
                    return attr.ValueString == ValueString;
                case SCIMSchemaAttributeTypes.BINARY:
                    return attr.ValueBinary == ValueBinary;
                case SCIMSchemaAttributeTypes.BOOLEAN:
                    return attr.ValueBoolean == ValueBoolean;
                case SCIMSchemaAttributeTypes.DATETIME:
                    return attr.ValueDateTime == ValueDateTime;
                case SCIMSchemaAttributeTypes.DECIMAL:
                    return attr.ValueDecimal == ValueDecimal;
                case SCIMSchemaAttributeTypes.INTEGER:
                    return attr.ValueInteger == ValueInteger;
                case SCIMSchemaAttributeTypes.REFERENCE:
                    return attr.ValueReference == ValueReference;
            }

            return false;
        }

        public int GetLevel()
        {
            return FullPath.Split('.').Length;
        }

        public object Clone()
        {
            var result = new SCIMRepresentationAttribute(Id, AttributeId)
            {
                Id = Id,
                AttributeId = AttributeId,
                ValueBinary = ValueBinary,
                ValueBoolean = ValueBoolean,
                ValueDateTime = ValueDateTime,
                ValueDecimal = ValueDecimal,
                ValueInteger = ValueInteger,
                ValueReference = ValueReference,
                ValueString = ValueString,
                SchemaAttribute = (SCIMSchemaAttribute)SchemaAttribute.Clone(),
                FullPath = FullPath,
                ParentAttributeId = ParentAttributeId,
                SchemaAttributeId = SchemaAttributeId
            };
            return result;
        }

        public int CompareTo(SCIMRepresentationAttribute other)
        {
            switch(SchemaAttribute.Type)
            {
                case SCIMSchemaAttributeTypes.BINARY:
                    return ValueBinary.CompareTo(other.ValueBinary);
                case SCIMSchemaAttributeTypes.DATETIME:
                    if (ValueDateTime == null) {
                        return -1;
                    }

                    if (other.ValueDateTime == null)
                    {
                        return 1;
                    }

                    return ValueDateTime.Value.CompareTo(other.ValueDateTime.Value);
                case SCIMSchemaAttributeTypes.DECIMAL:
                    if (ValueDecimal == null)
                    {
                        return -1;
                    }

                    if (other.ValueDecimal == null)
                    {
                        return 1;
                    }

                    return ValueDecimal.Value.CompareTo(other.ValueDecimal.Value);
                case SCIMSchemaAttributeTypes.INTEGER:
                    if (ValueInteger == null)
                    {
                        return -1;
                    }

                    if (other.ValueInteger == null)
                    {
                        return 1;
                    }

                    return ValueInteger.Value.CompareTo(other.ValueInteger.Value);
                case SCIMSchemaAttributeTypes.REFERENCE:
                    return ValueReference.CompareTo(other.ValueReference);
                case SCIMSchemaAttributeTypes.STRING:
                    return ValueString.CompareTo(other.ValueString);
            }

            return 0;
        }
    }
}
