using System.Collections.Generic;
using System.Data.Common;
using Comp229_TeamAssign.Database.Models;
using Comp229_TeamAssign.Database.Models.PrimaryKeys;
using Comp229_TeamAssign.Utils;

namespace Comp229_TeamAssign.Database.DAOs
{
    /// <summary>
    /// Class to manage data access to the TBUB_BOOKS table.
    /// </summary>
    public class BookDAO : GenericDAO<DecimalPrimaryKey, Book>, IBookDAO
    {
        /// <see cref="GenericDAO{PK, M}"/>
        protected override string BuildFindAllQueryString()
        {
            return "select		book.* " +
                   ",			publ.PUBLISHER_NAME " +
                   ",			publ.PUBLISHER_CREATE_DATE " +
       ",			STUFF(( " +
                   "				select		';' " +
                   "				+			cast(catg.CATEGORY_ID			as VARCHAR)	+	'|' " +
                   "				+			catg.CATEGORY_NAME							+	'|' " +
                   "				+			cast(catg.CATEGORY_CREATE_DATE	as VARCHAR) " +
                   "				from		TBUB_CATEGORIES			catg " +
                   "				inner join	TBUB_BOOKS_CATEGORIES	boca " +
                   "				on			boca.CATEGORY_ID		=	catg.CATEGORY_ID " +
                   "				where		boca.BOOK_ISBN			=	book.BOOK_ISBN " +
                   "				for	xml	path('')), 1, 1, '' " +
                   "			)										as	CATEGORIES " +
                   ",			STUFF(( " +
                   "				select		';' " +
                   "				+			cast(auth.AUTHOR_ID				as VARCHAR)	+	'|' " +
                   "				+			auth.AUTHOR_NAME							+	'|' " +
                   "				+			cast(auth.AUTHOR_CREATE_DATE	as VARCHAR) " +
                   "				from		TBUB_AUTHORS		auth " +
                   "				inner join	TBUB_BOOKS_AUTHORS	boau " +
                   "				on			boau.AUTHOR_ID		=	auth.AUTHOR_ID " +
                   "				where		boau.BOOK_ISBN		=	book.BOOK_ISBN " +
                   "				for	xml	path('')), 1, 1, '' " +
                   "			)										as	AUTHORS " +
                   "from		TBUB_BOOKS	book " +
                   "inner join  TBUB_PUBLISHERS     publ " +
                   "on          publ.PUBLISHER_ID = book.PUBLISHER_ID " +
                   "order by	1 ";
        }

        /// <see cref="GenericDAO{PK, M}"/>
        protected override Book CreateObjectFromDataReader(DbDataReader dr)
        {
            var book = new Book();

            // Fills the book fields.
            book.PrimaryKey = new DecimalPrimaryKey(dr.GetDecimal(dr.GetOrdinal("BOOK_ISBN")));
            book.Title = dr.GetString(dr.GetOrdinal("BOOK_TITLE"));
            book.Description = dr.GetString(dr.GetOrdinal("BOOK_DESCRIPTION"));
            book.PublicationDate = dr.GetDateTime(dr.GetOrdinal("BOOK_PUBLICATION_DATE"));
            book.Edition = dr.GetDecimal(dr.GetOrdinal("BOOK_EDITION"));
            book.IsAvailable = dr.GetBoolean(dr.GetOrdinal("BOOK_IS_AVAILABLE"));
            book.QuantityAvailable = dr.GetDecimal(dr.GetOrdinal("BOOK_QUANTITY_AVAILABLE"));
            book.ImageUrl01 = dr.GetString(dr.GetOrdinal("BOOK_IMG_URL_01"));
            book.ImageUrl02 = dr.GetString(dr.GetOrdinal("BOOK_IMG_URL_02"));
            book.ImageUrl03 = dr.GetString(dr.GetOrdinal("BOOK_IMG_URL_03"));
            book.ImageUrl04 = dr.GetString(dr.GetOrdinal("BOOK_IMG_URL_04"));
            book.ImageUrl05 = dr.GetString(dr.GetOrdinal("BOOK_IMG_URL_05"));
            book.CreateDate = dr.GetDateTime(dr.GetOrdinal("BOOK_CREATE_DATE"));
            book.RemoveDate = dr.GetDateTime(dr.GetOrdinal("BOOK_REMOVE_DATE"));
            book.LastUpdateDate = dr.GetDateTime(dr.GetOrdinal("BOOK_LAST_UPDATE_DATE"));

            // Fills the publisher
            book.Publisher = DatabaseUtils.CreatePublisher(
                dr.GetDecimal(dr.GetOrdinal("PUBLISHER_ID")),
                dr.GetString(dr.GetOrdinal("PUBLISHER_NAME")),
                dr.GetDateTime(dr.GetOrdinal("PUBLISHER_CREATE_DATE"))
            );

            // Fills the categories.
            book.Categories = new HashSet<Category>();
            foreach(string category in dr.GetString(dr.GetOrdinal("CATEGORIES")).Split(new char[] { ';' }))
            {
                book.Categories.Add(DatabaseUtils.CreateDomainModelFromStringWithSeparator<Category>(category, new char[] { '|' }));
            }

            // Fills the authors.
            book.Authors = new HashSet<Author>();
            foreach (string author in dr.GetString(dr.GetOrdinal("AUTHORS")).Split(new char[] { ';' }))
            {
                book.Authors.Add(DatabaseUtils.CreateDomainModelFromStringWithSeparator<Author>(author, new char[] { '|' }));
            }

            return book;
        }
    }
}