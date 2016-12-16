$(document).ready(function () {
    function Cities() {
        var self = this;

        self.allCities = ko.observableArray([]);
        self.allCountries = ko.observableArray([]);
        self.selectedCountry = ko.observable();

        self.newCityName = ko.observable();

        self.loadingCities = ko.computed(function () {
            return self.allCities().length === 0;
        });

        self.newCity = function () {
            $.ajax({
                type: 'Post',
                dataType: 'json',
                url: 'api/Cities',
                contentType: 'application/json',
                data: JSON.stringify({
                    Name: self.newCityName(),
                    CountryCode: self.selectedCountry().Code
                }),
                success: function () {
                    self.allCities.push({
                        Name: self.newCityName()
                    });
                }
            });
        };

        $.get('api/Cities', function (data) {
            self.allCities(data);
        });
        $.get('api/Countries', function (data) {
            self.allCountries(data);
        });
    }
    ko.applyBindings(new Cities());
});