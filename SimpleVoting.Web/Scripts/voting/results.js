function ResultsViewModel() {
    var self = this;
    self.Questions = ko.observableArray([]);
    self.IsDataLoaded = ko.observable(false);

    self.InitSemantic = function () {
        $('.ui.progress').progress();
    };

    self.LoadData = function () {
        $.ajax({
            url: '/api/voting/results',
            type: 'GET',
            success: function (response) {
                self.Questions(response);

                setTimeout(function () {
                    self.IsDataLoaded(true);
                }, 500);

                self.InitSemantic();
            },
            error: function (error) {
                var message = 'При получении данных произошла ошибка';
                console.log(message);
                var noty = new Noty(notyOptions);
                noty.options.type = 'error';
                noty.options.text = message;
                noty.show();
            }
        });
    };
}