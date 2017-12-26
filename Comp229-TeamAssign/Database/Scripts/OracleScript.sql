﻿ALTER SESSION SET NLS_DATE_FORMAT = 'YYYY-MM-DD';

DROP INDEX IX_BOOKS_01;
DROP INDEX IX_BOOKS_02;
DROP INDEX IX_BOOK_RENTAL_01;

DROP TABLE TBUB_BOOK_RENTAL_DETAIL;
DROP TABLE TBUB_BOOKS_CATEGORIES;
DROP TABLE TBUB_BOOKS_AUTHORS;
DROP TABLE TBUB_BOOK_RENTAL;
DROP TABLE TBUB_BOOKS;
DROP TABLE TBUB_PUBLISHERS;
DROP TABLE TBUB_AUTHORS;
DROP TABLE TBUB_CATEGORIES;
DROP TABLE TBUB_USERS;

CREATE TABLE TBUB_PUBLISHERS (
    PUBLISHER_ID
        DECIMAL(6, 0)
        GENERATED ALWAYS AS IDENTITY
        PRIMARY KEY
        NOT NULL
,	PUBLISHER_NAME
        VARCHAR2(64)
        NOT NULL
,	PUBLISHER_CREATE_DATE
        TIMESTAMP
        DEFAULT CURRENT_TIMESTAMP
        NOT NULL
);

CREATE TABLE TBUB_AUTHORS (
    AUTHOR_ID
        DECIMAL(10, 0)
        GENERATED ALWAYS AS IDENTITY
        PRIMARY KEY
        NOT NULL
,	AUTHOR_NAME
        VARCHAR2(128)
        NOT NULL
,	AUTHOR_CREATE_DATE
        TIMESTAMP
        DEFAULT CURRENT_TIMESTAMP
        NOT NULL
);

CREATE TABLE TBUB_CATEGORIES (
    CATEGORY_ID
        DECIMAL(4, 0)
        GENERATED ALWAYS AS IDENTITY
        PRIMARY KEY
        NOT NULL
,	CATEGORY_NAME
        VARCHAR2(64)
        NOT NULL
        UNIQUE
,	CATEGORY_CREATE_DATE
        TIMESTAMP
        DEFAULT CURRENT_TIMESTAMP
        NOT NULL
);

CREATE TABLE TBUB_USERS (
    USER_ID
        DECIMAL(11, 0)
        GENERATED ALWAYS AS IDENTITY
        PRIMARY KEY
        NOT NULL
,	USER_EMAIL
        VARCHAR2(64)
        NOT NULL
        UNIQUE
,	USER_PASSWORD
        CHAR(64)
        NOT NULL
,	USER_FIRST_NAME
        VARCHAR2(32)
        NOT NULL
,	USER_LAST_NAME
        VARCHAR(64)
        NOT NULL
);

CREATE TABLE TBUB_BOOK_RENTAL (
    RENTAL_ID
        DECIMAL(15, 0)
        GENERATED ALWAYS AS IDENTITY
        PRIMARY KEY
        NOT NULL
,	RENTAL_DATE
        DATE
        DEFAULT SYSDATE
        NOT NULL
,	RENTAL_RETURN_DATE
        DATE
        NOT NULL
,	USER_ID
        DECIMAL(11)
        NOT NULL
,   CONSTRAINT FK_BOOK_RENTAL_01
        FOREIGN KEY(USER_ID) REFERENCES TBUB_USERS(USER_ID)
);

CREATE TABLE TBUB_BOOKS (
    BOOK_ISBN
        DECIMAL(13, 0)
        PRIMARY KEY
        NOT NULL
,	BOOK_TITLE
        VARCHAR2(128)
        NOT NULL
,	BOOK_DESCRIPTION
        VARCHAR2(2048)
,	BOOK_PUBLICATION_DATE
        DATE
        NOT NULL
,	BOOK_EDITION
        DECIMAL(2, 0)
        NOT NULL
,	BOOK_IS_AVAILABLE
        DECIMAL(1, 0)
        NOT NULL
,	BOOK_QUANTITY_AVAILABLE
        DECIMAL(3, 0)
        NOT NULL
,	BOOK_IMG_URL_01
        VARCHAR2(255)
        NOT NULL
,	BOOK_IMG_URL_02
        VARCHAR2(255)
,	BOOK_IMG_URL_03
        VARCHAR2(255)
,	BOOK_IMG_URL_04
        VARCHAR2(255)
,	BOOK_IMG_URL_05
        VARCHAR2(255)
,	BOOK_CREATE_DATE
        TIMESTAMP
        DEFAULT CURRENT_TIMESTAMP
        NOT NULL
,	BOOK_REMOVE_DATE
        TIMESTAMP
,	BOOK_LAST_UPDATE_DATE
        TIMESTAMP
,	PUBLISHER_ID
        DECIMAL(6, 0)
        NOT NULL
,       CONSTRAINT FK_BOOKS_01
            FOREIGN KEY(PUBLISHER_ID) REFERENCES TBUB_PUBLISHERS(PUBLISHER_ID)
);

CREATE TABLE TBUB_BOOKS_AUTHORS (
    BOOK_ISBN
        DECIMAL(13, 0)
        NOT NULL
,	AUTHOR_ID
        DECIMAL(10, 0)
        NOT NULL
,	CONSTRAINT PK_BOOKS_AUTHORS
        PRIMARY KEY(BOOK_ISBN, AUTHOR_ID)
,   CONSTRAINT FK_BOOKS_AUTORS_01
        FOREIGN KEY(BOOK_ISBN) REFERENCES TBUB_BOOKS(BOOK_ISBN)
,   CONSTRAINT FK_BOOKS_AUTORS_02
        FOREIGN KEY(AUTHOR_ID) REFERENCES TBUB_AUTHORS(AUTHOR_ID)
);

CREATE TABLE TBUB_BOOKS_CATEGORIES (
    BOOK_ISBN
        DECIMAL(13, 0)
        NOT NULL
,	CATEGORY_ID
        DECIMAL(4, 0)
        NOT NULL
,	CONSTRAINT PK_BOOKS_CATEGORIES
        PRIMARY KEY (BOOK_ISBN, CATEGORY_ID)
,   CONSTRAINT FK_BOOKS_CATEGORIES_01
        FOREIGN KEY(BOOK_ISBN)   REFERENCES TBUB_BOOKS(BOOK_ISBN)
,   CONSTRAINT FK_BOOKS_CATEGORIES_02
        FOREIGN KEY(CATEGORY_ID) REFERENCES TBUB_CATEGORIES(CATEGORY_ID)
);

CREATE TABLE TBUB_BOOK_RENTAL_DETAIL (
    RENTAL_ID
        DECIMAL(15, 0)
        NOT NULL
,	BOOK_ISBN
        DECIMAL(13, 0)
        NOT NULL
,	CONSTRAINT PK_BOOK_RENTAL_DETAIL
        PRIMARY KEY(RENTAL_ID, BOOK_ISBN)
,   CONSTRAINT FK_BOOK_RENTAL_DETAIL_01
        FOREIGN KEY(RENTAL_ID) REFERENCES TBUB_BOOK_RENTAL(RENTAL_ID)
,   CONSTRAINT FK_BOOK_RENTAL_DETAIL_02
        FOREIGN KEY(BOOK_ISBN) REFERENCES TBUB_BOOKS(BOOK_ISBN)
);
    
CREATE INDEX IX_BOOKS_01 ON TBUB_BOOKS(BOOK_TITLE);
CREATE INDEX IX_BOOKS_02 ON TBUB_BOOKS(PUBLISHER_ID);
CREATE INDEX IX_BOOK_RENTAL_01 ON TBUB_BOOK_RENTAL(USER_ID);

INSERT INTO TBUB_CATEGORIES(CATEGORY_NAME) VALUES('Fantasy');
INSERT INTO TBUB_CATEGORIES(CATEGORY_NAME) VALUES('Magic');

INSERT INTO TBUB_AUTHORS(AUTHOR_NAME) VALUES('J. K. Rowling');

INSERT INTO TBUB_PUBLISHERS(PUBLISHER_NAME) VALUES('Bloomsbury Childre''s Books');

INSERT INTO TBUB_BOOKS(BOOK_ISBN, BOOK_TITLE, BOOK_DESCRIPTION, BOOK_PUBLICATION_DATE, BOOK_EDITION, BOOK_IS_AVAILABLE, BOOK_QUANTITY_AVAILABLE, BOOK_IMG_URL_01, PUBLISHER_ID)
VALUES(
	9781408845646, 'Harry Potter and the Philosopher''s Stone',
	'Prepare to be spellbound by Jim Kay''s dazzling depiction of the wizarding world and much loved characters in this full-colour illustrated hardback edition of the natio''s favourite childre''s book – Harry Potter and the Philosopher''s Stone. Brimming with rich detail and humour that perfectly complements J.K. Rowling''s timeless classic, Jim Kay''s glorious illustrations will captivate fans and new readers alike.',
	'2015-10-06', 1, 1, 10, 'https://images-na.ssl-images-amazon.com/images/I/51sTwK7kBxL._AA218_.jpg', 1);
INSERT INTO TBUB_BOOKS(BOOK_ISBN, BOOK_TITLE, BOOK_DESCRIPTION, BOOK_PUBLICATION_DATE, BOOK_EDITION, BOOK_IS_AVAILABLE, BOOK_QUANTITY_AVAILABLE, BOOK_IMG_URL_01, PUBLISHER_ID)
VALUES(
	9781408845653, 'Harry Potter and the Chamber of Secrets',
	'Prepare to be spellbound by Jim Kay''s dazzling full-colour illustrations in this stunning new edition of J.K. Rowling''s Harry Potter and the Chamber of Secrets. Breathtaking scenes, dark themes and unforgettable characters await inside this fully illustrated edition. With paint, pencil and pixels, award-winning illustrator Jim Kay conjures the wizarding world as we have never seen it before. Fizzing with magic and brimming with humour, this inspired reimagining will captivate fans and new readers alike, as Harry and his friends, now in their second year at Hogwarts School of Witchcraft and Wizardry, seek out a legendary chamber and the deadly secret that lies at its heart.',
	'2016-10-04', 1, 1, 10, 'https://images-na.ssl-images-amazon.com/images/I/61+abdOC5gL._AA218_.jpg', 1);
INSERT INTO TBUB_BOOKS(BOOK_ISBN, BOOK_TITLE, BOOK_DESCRIPTION, BOOK_PUBLICATION_DATE, BOOK_EDITION, BOOK_IS_AVAILABLE, BOOK_QUANTITY_AVAILABLE, BOOK_IMG_URL_01, PUBLISHER_ID)
VALUES(
	9781408845660, 'Harry Potter and the Prisoner of Azkaban',
	'An extraordinary creative achievement by an extraordinary talent, Jim Kay''s inspired reimagining of J.K. Rowling''s classic series has captured a devoted following worldwide. This stunning new fully illustrated edition of Harry Potter and the Prisoner of Azkaban brings more breathtaking scenes and unforgettable characters – including Sirius Black, Remus Lupin and Professor Trelawney. With paint, pencil and pixels, Kay conjures the wizarding world as we have never seen it before. Fizzing with magic and brimming with humour, this full-colour edition will captivate fans and new readers alike as Harry, now in his third year at Hogwarts School of Witchcraft and Wizardry, faces Dementors, death omens and, of course, danger.',
	'2017-10-03', 1, 1, 10, 'https://images-na.ssl-images-amazon.com/images/I/617HC+dtBOL._AA218_.jpg', 1);
INSERT INTO TBUB_BOOKS(BOOK_ISBN, BOOK_TITLE, BOOK_DESCRIPTION, BOOK_PUBLICATION_DATE, BOOK_EDITION, BOOK_IS_AVAILABLE, BOOK_QUANTITY_AVAILABLE, BOOK_IMG_URL_01, PUBLISHER_ID)
VALUES(
	9781408890769, 'Harry Potter - A History of Magic: The Book of the Exhibition',
	'Harry Potter: A History of Magic is the official book of the exhibition, a once-in-a-lifetime collaboration between Bloomsbury, J.K. Rowling and the brilliant curators of the British Library. It promises to take readers on a fascinating journey through the subjects studied at Hogwarts School of Witchcraft and Wizardry - from Alchemy and Potions classes through to Herbology and Care of Magical Creatures.',
	'2017-10-20', 1, 1, 10, 'https://images-na.ssl-images-amazon.com/images/I/61Lo-+FBs+L._AA218_.jpg', 1);

INSERT INTO TBUB_BOOKS_AUTHORS(BOOK_ISBN, AUTHOR_ID) VALUES(9781408845646, 1);
INSERT INTO TBUB_BOOKS_AUTHORS(BOOK_ISBN, AUTHOR_ID) VALUES(9781408845653, 1);
INSERT INTO TBUB_BOOKS_AUTHORS(BOOK_ISBN, AUTHOR_ID) VALUES(9781408845660, 1);
INSERT INTO TBUB_BOOKS_AUTHORS(BOOK_ISBN, AUTHOR_ID) VALUES(9781408890769, 1);

INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845646, 1);
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845646, 2);
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845653, 1);
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845653, 2);
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845660, 1);
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408845660, 2);
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408890769, 1);
INSERT INTO TBUB_BOOKS_CATEGORIES(BOOK_ISBN, CATEGORY_ID) VALUES(9781408890769, 2);

COMMIT;