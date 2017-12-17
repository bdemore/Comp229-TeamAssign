using Comp229_TeamAssign.Database.Models;
using Comp229_TeamAssign.Database.Models.PrimaryKeys;
using System;
using System.Globalization;

namespace Comp229_TeamAssign.Utils
{
    /// <summary>
    /// Utiliy Class to be used by database objects
    /// </summary>
    public class DatabaseUtils
    {
        /// <summary>
        /// Ceates a Publisher with the given parameters.
        /// </summary>
        /// <param name="publisherId">The publisher identification.</param>
        /// <param name="publisherName">The publiher name.</param>
        /// <param name="publisherCreateDate">The publisher create date.</param>
        /// <returns></returns>
        public static Publisher CreatePublisher(decimal publisherId, string publisherName, DateTime publisherCreateDate)
        {
            var publisher = new Publisher();

            publisher.PrimaryKey = new DecimalPrimaryKey(publisherId);
            publisher.Name = publisherName;
            publisher.CreateDate = publisherCreateDate;

            return publisher;
        }

        /// <summary>
        /// Returns a Category from a string separated by the given separator. The Category fields must be in the following order:
        /// <ol>
        ///     <li>PrimaryKey</li>
        ///     <li>Name</li>
        ///     <li>CreateDate</li>
        /// </ol>
        /// </summary>
        /// <param name="separatedString">The string formated with the separator.</param>
        /// <param name="separator">The separator to be used</param>
        /// <returns>The category created</returns>
        public static DM CreateDomainModelFromStringWithSeparator<DM>(string separatedString, char[] separator) where DM : DomainModel<DecimalPrimaryKey>
        {
            var domainModel = ReflectionUtils.ConstructDefault<DM>();
            var domainModelFields = separatedString.Split(separator);

            domainModel.PrimaryKey = new DecimalPrimaryKey(decimal.Parse(domainModelFields[0]));
            domainModel.Name = domainModelFields[1];
            domainModel.CreateDate = DateTime.ParseExact(domainModelFields[2], "yyyy-MM-dd HH:mm:ss.ffffff", CultureInfo.InvariantCulture);

            return domainModel;
        }
    }
}