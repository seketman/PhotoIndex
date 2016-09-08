app.factory('photoSvc', ['$resource', '$q', 'locationSvc', 'serviceHelperSvc',
    function ($resource, $q, locationSvc, serviceHelper) {
        var Photo = serviceHelper.Photo;

        var getTopPhotos = function () {
            return Photo.query({ count: 5 });
        };
        var getPhotos = function () {
            return Photo.query();
        };
        var deletePhoto = function (resourceId) {
            return Photo.delete({ resourceId: resourceId });
        };
        var addPhoto = function (photo) {
            return Photo.save(photo);
        };
        var editPhoto = function (photo) {
            return Photo.update(photo);
        };
        var getPhoto = function (id) {
            return Photo.get({ photoId: id });
        };

        var createPhotoEditFormModel = function (photoId) {
            var sample = $q.all([this.getPhoto(photoId).$promise, locationSvc.getLocations().$promise]);
            return sample;
        };

        var getPagedPhotos = function (params) {
            return Photo.getPagedItems(params);
        };

        return {
            getTopPhotos: getTopPhotos,
            getPhotos: getPhotos,
            deletePhoto: deletePhoto,
            addPhoto: addPhoto,
            editPhoto: editPhoto,
            getPhoto: getPhoto,
            createPhotoEditFormModel: createPhotoEditFormModel,
            getPagedPhoto: getPagedPhoto
        };
    }
]);