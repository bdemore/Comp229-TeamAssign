using Comp229_TeamAssign.Database.Models.PrimaryKeys;
using System;

namespace Comp229_TeamAssign.Database.Models
{
    public class BookRental : GenericModel<DecimalPrimaryKey>
    {
        // The date the rental was made.
        public DateTime RentalDate { get; set; }

        // The maximum date to return the rental.
        public DateTime RentalDueDate { get; set; }

        // The date the rental was returned
        public DateTime RentalReturnDate { get; set; }

        // The user that performed the rental.
        public User User { get; set; }

        public override bool Equals(object obj)
        {
            return ((null != obj) && (obj is BookRental) && PrimaryKey.Equals((obj as BookRental).PrimaryKey));
        }

        public override int GetHashCode()
        {
            return PrimaryKey.GetHashCode();
        }

        public override string ToString()
        {
            return string.Format("BookRental: {{ PrimaryKey: \"{0}\", RentalDate: \"{1}\", RentalDueDate: \"{2}\", RentalReturnDate: \"{3}\", User: \"{4}\" }}", 
                PrimaryKey, RentalDate.ToShortDateString(), RentalDueDate.ToShortDateString(), RentalReturnDate.ToShortDateString(), User.PrimaryKey);
        }

    }
}