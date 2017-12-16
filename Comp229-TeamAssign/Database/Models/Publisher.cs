﻿using Comp229_TeamAssign.Database.Models.PrimaryKeys;

namespace Comp229_TeamAssign.Database.Models
{
    /// <summary>
    /// Class that will be used to store a publisher returned from the database table TBUB_PUBLISHERS.
    /// </summary>
    public class Publisher : GenericModel<DecimalPrimaryKey>
    {
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return ((null != obj) && (obj is Publisher) && PrimaryKey.Equals((obj as Publisher).PrimaryKey));
        }

        public override int GetHashCode()
        {
            return PrimaryKey.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Publisher: {{ PrimaryKey: \"{0}\", Name: \"{1}\" }}", PrimaryKey, Name);
        }
    }
}