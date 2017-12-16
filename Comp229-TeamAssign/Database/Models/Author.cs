﻿using Comp229_TeamAssign.Database.Models.PrimaryKeys;

namespace Comp229_TeamAssign.Database.Models
{
    /// <summary>
    /// Class that will be used to store an author returned from the database table TBUB_AUTHORS.
    /// </summary>
    public class Author : GenericModel<DecimalPrimaryKey>
    {
        // The author's name.
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return ((null != obj) && (obj is Author) && PrimaryKey.Equals((obj as Author).PrimaryKey));
        }

        public override int GetHashCode()
        {
            return PrimaryKey.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Author: {{ PrimaryKey: \"{0}\", Name: \"{1}\" }}", PrimaryKey, Name);
        }
    }
}