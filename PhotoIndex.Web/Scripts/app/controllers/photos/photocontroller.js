app.controller('PhotoCtrl', ['$scope', '$routeParams', '$location', 'photoSvc',
    function ($scope, $routeParams, $location, photoSvc) {
        $scope.photo = {};

        $scope.addPhoto = function (photo) {
            photoSvc.addPhoto(photo).$promise
            .then(function (data) {
                $location.url('/Photos');
            });
        };

        init();

        function init() {
            if ($routeParams.photoId > 0) {
                $scope.photo = photoSvc.getPhoto($routeParams.photoId);
            }
            else {
                $scope.locations = locationSvc.getLocations();
            }
        }
    }
]);