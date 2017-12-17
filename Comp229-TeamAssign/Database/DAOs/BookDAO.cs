﻿using System.Collections.Generic;
using System.Data.Common;
using Comp229_TeamAssign.Database.Models;
using Comp229_TeamAssign.Database.Models.PrimaryKeys;
using Comp229_TeamAssign.Utils;

namespace Comp229_TeamAssign.Database.DAOs
{
    /// <summary>
    /// Class to manage data access to the TBUB_BOOKS table.
    /// </summary>
    public class BookDAO : GenericDAO<DecimalPrimaryKey, Book, BookDAO>, IBookDAO
    {
        /// <summary>
        /// Private constructor to avoid direct instantiation.
        /// </summary>
        private BookDAO() { }

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
                   "order by	1";
        }

        /// <see cref="GenericDAO{PK, M}"/>
        protected override Book CreateObjectFromDataReader(DbDataReader dr)
        {
            var book = new Book();

            // Fills the book fields.
            book.PrimaryKey = new DecimalPrimaryKey(DatabaseUtils.SafeGetDecimal(dr, "BOOK_ISBN"));
            book.Title = DatabaseUtils.SafeGetString(dr, "BOOK_TITLE");
            book.Description = DatabaseUtils.SafeGetString(dr, "BOOK_DESCRIPTION");
            book.PublicationDate = DatabaseUtils.SafeGetDateTime(dr, "BOOK_PUBLICATION_DATE");
            book.Edition = DatabaseUtils.SafeGetDecimal(dr,"BOOK_EDITION");
            book.IsAvailable = DatabaseUtils.SafeGetBoolean(dr,"BOOK_IS_AVAILABLE");
            book.QuantityAvailable = DatabaseUtils.SafeGetDecimal(dr, "BOOK_QUANTITY_AVAILABLE");
            book.ImageUrl01 = DatabaseUtils.SafeGetString(dr, "BOOK_IMG_URL_01");
            book.ImageUrl02 = DatabaseUtils.SafeGetString(dr, "BOOK_IMG_URL_02");
            book.ImageUrl03 = DatabaseUtils.SafeGetString(dr, "BOOK_IMG_URL_03");
            book.ImageUrl04 = DatabaseUtils.SafeGetString(dr, "BOOK_IMG_URL_04");
            book.ImageUrl05 = DatabaseUtils.SafeGetString(dr, "BOOK_IMG_URL_05");
            book.CreateDate = DatabaseUtils.SafeGetDateTime(dr, "BOOK_CREATE_DATE");
            book.RemoveDate = DatabaseUtils.SafeGetDateTime(dr, "BOOK_REMOVE_DATE");
            book.LastUpdateDate = DatabaseUtils.SafeGetDateTime(dr, "BOOK_LAST_UPDATE_DATE");
            book.Categories = new HashSet<Category>();
            book.Authors = new HashSet<Author>();

            // Fills the publisher
            book.Publisher = DatabaseUtils.CreatePublisher(
                dr.GetDecimal(dr.GetOrdinal("PUBLISHER_ID")),
                dr.GetString(dr.GetOrdinal("PUBLISHER_NAME")),
                dr.GetDateTime(dr.GetOrdinal("PUBLISHER_CREATE_DATE"))
            );

            // Fills the categories.
            var categories = DatabaseUtils.SafeGetString(dr, "CATEGORIES");
            if (!string.IsNullOrWhiteSpace(categories))
            {
                foreach (string category in categories.Split(new char[] { ';' }))
                {
                    book.Categories.Add(DatabaseUtils.CreateDomainModelFromStringWithSeparator<Category>(category, new char[] { '|' }));
                }
            }

            // Fills the authors.
            var authors = DatabaseUtils.SafeGetString(dr, "AUTHORS");
            if (!string.IsNullOrWhiteSpace(authors)) {
                foreach (string author in authors.Split(new char[] { ';' }))
                {
                    book.Authors.Add(DatabaseUtils.CreateDomainModelFromStringWithSeparator<Author>(author, new char[] { '|' }));
                }
            }

            return book;
        }
    }
}