'use strict';
app.controller('PhotosCtrl', ['$scope', 'photosSvc', 'ngTableParams',
    function ($scope, photosSvc, ngTableParams) {
        var fetchPagedStruct = function (pagedStruct) {
            var sorting = pagedStruct.sorting();
            var sortField;
            var sortOrder;
            if (sorting) {
                for (var prop in sorting) {
                    sortField = prop;
                    sortOrder = sorting[prop];
                    break;
                }
            }

            return {
                page: pagedStruct.page(),
                count: pagedStruct.count()
            }
        };

        $scope.tableParams = new ngTableParams({
            page: 1,            // show first page
            count: 10
        }, {
            counts: [],
            total: 0,
            getData: function ($defer, params) {
                photosSvc.getPagedPhoto(fetchPagedStruct(params))
                    .$promise.then(function (data) {
                        params.total(data.TotalCount);           
                        $defer.resolve(data.Data);
                    }).catch(function (error) {
                        console.log(error);
                    });
            }
        });

        $scope.deletePhoto = function (photoId) {
            photosSvc.deletePhoto(photoId).$promise
            .then(function (data) {
                if ($scope.tableParams.page() !== 1 && $scope.tableParams.data.length === 1) {
                    $scope.tableParams.page(1);
                }
                $scope.tableParams.reload();
            });
        };
    }
]);