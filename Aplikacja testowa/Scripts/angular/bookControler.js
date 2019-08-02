var app = angular.module("booksApp", []); 


app.controller("bookCtrl", function ($scope, $http) {

    var getAllBooks = function () {
        $http.get('/api/book/all').then(
            function (response) {
                $scope.books = response.data;
            },
            function (response) {
                console.log(response);
            }
        );
    };

    $scope.addNewBook = function (newBook) {
        $http.post('/api/book/post', newBook).then(
            function (response) {
                getAllBooks();
                console.log(response);
            },
            function (response) {
                console.log(response);
            }
        );
    };

    getAllBooks();
});