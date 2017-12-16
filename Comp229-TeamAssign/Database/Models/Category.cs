using Comp229_TeamAssign.Database.Models.PrimaryKeys;

namespace Comp229_TeamAssign.Database.Models
{
    /// <summary>
    /// Class that will be used to store a category returned from the database table TBUB_CATEGORIES.
    /// </summary>
    public class Category : GenericModel<DecimalPrimaryKey>
    {
        // The category's name.
        public string Name { get; set; }

        public override bool Equals(object obj)
        {
            return ((null != obj) && (obj is Category) && PrimaryKey.Equals((obj as Category).PrimaryKey));
        }

        public override int GetHashCode()
        {
            return PrimaryKey.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("Category: {{ PrimaryKey: \"{0}\", Name: \"{1}\" }}", PrimaryKey, Name);
        }
    }
}