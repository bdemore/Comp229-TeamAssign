namespace Comp229_TeamAssign.Database.Models.PrimaryKeys
{
    /// <summary>
    /// Decimal primary key representation for model objects.
    /// </summary>
    public class DecimalPrimaryKey : GenericPrimaryKey
    {
        // The decimal key value.
        public decimal Key { get; set; }

        public override bool Equals(object obj)
        {
            return ((null != obj) && (obj is DecimalPrimaryKey) && (Key == (obj as DecimalPrimaryKey).Key));
        }

        public override int GetHashCode()
        {
            return Key.GetHashCode();
        }

        public override string ToString()
        {
            return Key.ToString();
        }
    }
}