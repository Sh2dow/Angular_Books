var ViewModel = function () {
    var self = this;
    self.books = ko.observableArray();
    self.error = ko.observable();
    self.detail = ko.observable();
    self.newBook = {
        Author: ko.observable(),
        Genre: ko.observable(),
        Price: ko.observable(),
        Title: ko.observable(),
        Year: ko.observable()
    }

    var booksUri = '/api/books/';

    function ajaxHelper(uri, method, data) {
        self.error(''); // Clear error message
        return $.ajax({
            type: method,
            url: uri,
            dataType: 'json',
            contentType: 'application/json',
            data: data ? JSON.stringify(data) : null
        }).fail(function (jqXHR, textStatus, errorThrown) {
            self.error(errorThrown);
        });
    }

    function getAllBooks() {
        ajaxHelper(booksUri, 'GET').done(function (data) {
            self.books(data);
        });
    }

    function jqtable() {
        ajaxHelper(booksUri, 'GET').done(function () {
            $('#table').bootstrapTable({
                url: booksUri,
                columns: [{
                    field: 'Id',
                    title: 'id'
                }, {
                    field: 'Author',
                    title: 'Author Name'
                }, {
                    field: 'Title',
                    title: 'Title'
                }, {
                    field: 'Year',
                    title: 'Year'
                }, {
                    field: 'Genre',
                    title: 'Genre'
                }, {
                    field: 'Price',
                    title: 'Price'
                }],
                //showRefresh: true,
                silent: true,
                search: true,
            });
        });
    }


    self.getBookDetail = function (item) {
        ajaxHelper(booksUri + item.Id, 'GET').done(function (data) {
            self.detail(data);
        });
    }


    self.addBook = function (formElement) {
        var book = {
            Author: self.newBook.Author(),
            Genre: self.newBook.Genre(),
            Price: self.newBook.Price(),
            Title: self.newBook.Title(),
            Year: self.newBook.Year()
        };

        ajaxHelper(booksUri, 'POST', book).done(function (item) {
            self.books.push(item);
            $('#table').bootstrapTable('refresh');
        });
    }

    // Fetch the initial data.
    jqtable();
};

ko.applyBindings(new ViewModel());