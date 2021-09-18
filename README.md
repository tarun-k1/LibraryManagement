# LibraryManagement
# Table of contents

- [Installation](#installation)
   - Microsoft Visual Studio 2019
   - Microsoft Sql Server
   - Web Browser
- [Used Technologies](#UsedTechnologies)
   - Asp.Net and C#
   - HTML and CSS
   - SQL
- [Feature](#feature)
  - [Add, Update and Delete books](#add-update-and-delete-books)
      * Admin can add, update, delete books.
  - [Login and Register](#login-and-register)
       *  User can login and register himself with email for borrowing a book.
  - [Admin Login](#admin-login)
       * Admin can login with username- admin and email - admin@gmail.com.
  - [Show books by available books and books taken by user](#show-books-by-available-books-and-books-taken-by-user)
       *  User can choose show all option for checking all books, available books for only checking available books    and also check books which are taken by user.

   - [Database](#database)
       * There are two tables.
        1.Book
        ``` 
        {
            id_book(pk),
            name,
            author_name,
            id_user(fk)
        }
        ```
        2.User_tbl
        ``` 
        {
           id_user(pk),
           name,
           email
        }
        ```
    
