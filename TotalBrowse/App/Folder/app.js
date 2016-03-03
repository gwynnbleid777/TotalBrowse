(function () {
    var app = angular.module("AppModule", []);

    app.controller("AppCtrl", ["$http", "$scope", function ($http, $scope) {

        $scope.hostName = location.host;
        $scope.name;
        $scope.address;
        $scope.files;
        $scope.filesFullName;
        $scope.filesName;
        $scope.filesPath;
        $scope.filesless10mb;
        $scope.filesless50mb;
        $scope.filesover50mb;
        $scope.parentAddress;
        $scope.subdirs;
        $scope.subdirsFullName;
        $scope.subdirsName;
        $scope.diskName;
        $scope.diskId;
        $scope.diskType;
        $scope.disks;
		
        //"api/browse/getfolder/?address=" + encodeURIComponent($scope.address)
        

        $scope.getFolder = function (address) {
	        
            $scope.resetValues();
            if (address == "")
            {
                $http.get("api/browse/getdrives");
            }

            $http.get("api/browse/getfolder/?address=" + address).success(function (data) {

                // $scope.subdirs = data.Subdirs;
                // $scope.files = data.Files;
                // $scope.updateValues(data);				
                $scope.name = data.Name;
                $scope.address = data.Address;
                $scope.files = data.Files;
                $scope.filesFullName = data.Files.FullName;
                $scope.filesName = data.Files.Name;
                $scope.filesPath = data.Files.Path;
                $scope.filesless10mb = data.FileSizes.NumFilesLess10mb;
                $scope.filesless50mb = data.FileSizes.NumFilesLess50mb;
                $scope.filesover50mb = data.FileSizes.NumFilesOver50mb;
                $scope.parentAddress = data.ParentAddress;
                $scope.subdirs = data.Subdirs;
                $scope.subdirsFullName = data.Subdirs.FullName;
                $scope.subdirsName = data.Subdirs.Name;													                
            });  
        };
		
		
        $scope.getBaseFolder = function () {
            

            $scope.resetValues();
            
            $http.get("api/browse/getbasefolder").success(function (data) {

                $scope.name = data.Name;
                $scope.address = data.Address;
                $scope.files = data.Files;
                $scope.filesFullName = data.Files.FullName;
                $scope.filesName = data.Files.Name;
                $scope.filesPath = data.Files.Path;
                $scope.filesless10mb = data.FileSizes.NumFilesLess10mb;
                $scope.filesless50mb = data.FileSizes.NumFilesLess50mb;
                $scope.filesover50mb = data.FileSizes.NumFilesOver50mb;
                $scope.parentAddress = data.ParentAddress;
                $scope.subdirs = data.Subdirs;
                $scope.subdirsFullName = data.Subdirs.FullName;
                $scope.subdirsName = data.Subdirs.Name;
		
            });
        };
		
        
        $scope.getDisks = function () {
            $http.get("api/browse/getdrives").success(function (data) {
                
                $scope.disks = data.Disks;
                $scope.diskName = data.Disks.Name;
                $scope.diskId = data.Disks.Id;
                $scope.diskType = data.Disks.Type;

            });
        };



        $scope.getFile = function (filesFullName) {
            path = "api/browse/getfile/?path=" + filesFullName
            window.location.assign(path);
        }
    
		
		
		
        $scope.resetValues = function() {
            $scope.name = 0;
			$scope.address = 0;
			$scope.filesFullName = 0;
			$scope.filesName = 0;
			$scope.filesPath = 0;
			$scope.filesless10mb = 0;
			$scope.filesless50mb = 0;
			$scope.filesover50mb = 0;
			$scope.parentAddress = 0;
			$scope.subdirsFullName = 0;
			$scope.subdirsName = 0;
        }
    }]);
})();