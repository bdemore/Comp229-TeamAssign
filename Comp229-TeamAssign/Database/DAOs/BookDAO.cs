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
        protected override string BuildFindAllSqlServerQueryString() => BuildBookSelectQueryStringSqlServer() + BuildBookOrderByQueryString();


        /// <see cref="GenericDAO{PK, M}"/>
        protected override string BuildFindAllOracleQueryString() => BuildSelectQueryStringOracle() + BuildBookOrderByQueryString();

        /// <see cref="GenericDAO{PK, M}"/>
        protected override Book CreateObjectFromDataReader(DbDataReader dr)
        {
            var book = new Book
            {

                // Fills the book fields.
                PrimaryKey = new DecimalPrimaryKey(DatabaseUtils.SafeGetDecimal(dr, "BOOK_ISBN")),
                Title = DatabaseUtils.SafeGetString(dr, "BOOK_TITLE"),
                Description = DatabaseUtils.SafeGetString(dr, "BOOK_DESCRIPTION"),
                PublicationDate = DatabaseUtils.SafeGetDateTime(dr, "BOOK_PUBLICATION_DATE"),
                Edition = DatabaseUtils.SafeGetDecimal(dr, "BOOK_EDITION"),
                IsAvailable = DatabaseUtils.SafeGetBoolean(dr, "BOOK_IS_AVAILABLE"),
                QuantityAvailable = DatabaseUtils.SafeGetDecimal(dr, "BOOK_QUANTITY_AVAILABLE"),
                ImageUrl01 = DatabaseUtils.SafeGetString(dr, "BOOK_IMG_URL_01"),
                ImageUrl02 = DatabaseUtils.SafeGetString(dr, "BOOK_IMG_URL_02"),
                ImageUrl03 = DatabaseUtils.SafeGetString(dr, "BOOK_IMG_URL_03"),
                ImageUrl04 = DatabaseUtils.SafeGetString(dr, "BOOK_IMG_URL_04"),
                ImageUrl05 = DatabaseUtils.SafeGetString(dr, "BOOK_IMG_URL_05"),
                CreateDate = DatabaseUtils.SafeGetDateTime(dr, "BOOK_CREATE_DATE"),
                RemoveDate = DatabaseUtils.SafeGetDateTime(dr, "BOOK_REMOVE_DATE"),
                LastUpdateDate = DatabaseUtils.SafeGetDateTime(dr, "BOOK_LAST_UPDATE_DATE"),
                Categories = new HashSet<Category>(),
                Authors = new HashSet<Author>(),

                // Fills the publisher
                Publisher = DatabaseUtils.CreatePublisher(
                    dr.GetDecimal(dr.GetOrdinal("PUBLISHER_ID")),
                    dr.GetString(dr.GetOrdinal("PUBLISHER_NAME")),
                    dr.GetDateTime(dr.GetOrdinal("PUBLISHER_CREATE_DATE"))
                )
            };

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
            if (!string.IsNullOrWhiteSpace(authors))
            {
                foreach (string author in authors.Split(new char[] { ';' }))
                {
                    book.Authors.Add(DatabaseUtils.CreateDomainModelFromStringWithSeparator<Author>(author, new char[] { '|' }));
                }
            }

            return book;
        }

        /// <summary>
        /// Builds the select and from clauses for getting books from the SQL Server database.
        /// </summary>
        /// <returns>The select string</returns>
        private string BuildBookSelectQueryStringSqlServer() =>
               "select		book.* " +
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
               "on          publ.PUBLISHER_ID = book.PUBLISHER_ID ";

        /// <summary>
        /// Builds the select and from clauses for getting books from the Oracle database.
        /// </summary>
        /// <returns>The select string</returns>
        private string BuildSelectQueryStringOracle() =>
               "select		book.* " +
               ",			publ.PUBLISHER_NAME " +
               ",			publ.PUBLISHER_CREATE_DATE " +
               ",           ( " +
               "    select      listagg(catg.CATEGORY_ID || '|' || catg.CATEGORY_NAME || '|' || to_char(catg.CATEGORY_CREATE_DATE, 'YYYY-MM-DD HH24:MI:SS.FF7'), ';') " +
               "                within group(order by catg.CATEGORY_ID) " +
               "    from        TBUB_CATEGORIES         catg " +
               "    inner join  TBUB_BOOKS_CATEGORIES   boca " +
               "    on          boca.CATEGORY_ID        =   catg.CATEGORY_ID " +
               "    where       boca.BOOK_ISBN          =   book.BOOK_ISBN " +
               ")                                       as CATEGORIES " +
               ",           ( " +
               "    select      listagg(auth.AUTHOR_ID || '|' || auth.AUTHOR_NAME || '|' || to_char(auth.AUTHOR_CREATE_DATE, 'YYYY-MM-DD HH24:MI:SS.FF7'), ';') " +
               "                within group(order by auth.AUTHOR_ID) " +
               "    from        TBUB_AUTHORS        auth " +
               "    inner join  TBUB_BOOKS_AUTHORS  boau " +
               "    on          boau.AUTHOR_ID      =   auth.AUTHOR_ID " +
               "    where       boau.BOOK_ISBN      =   book.BOOK_ISBN " +
               ")                                       as AUTHORS " +
               "from		TBUB_BOOKS          book " +
               "inner join  TBUB_PUBLISHERS     publ " +
               "on          publ.PUBLISHER_ID = book.PUBLISHER_ID ";

        /// <summary>
        /// Builds the order by clause for getting books from the database.
        /// </summary>
        /// <returns>The order by clause</returns>
        private string BuildBookOrderByQueryString() => "order by	book.BOOK_TITLE";
    }
}