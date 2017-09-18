function VotingViewModel() {
    var self = this;
    self.User = ko.observable();
    self.Questions = ko.observableArray([]);
    self.ValidationErrors = ko.observableArray([]);
    self.IsDataLoaded = ko.observable(false);
    self.InSaveProcess = ko.observable(false);

    self.InitSemantic = function () {
        $('.ui.dropdown').dropdown({ on: 'hover' });
        $('#form')
            .form({
                selector: {
                    message: '.client.error.message'
                },
                fields: {
                    empty: {
                        identifier: 'username',
                        rules: [
                            {
                                type: 'empty',
                                prompt: 'Необходимо указать имя'
                            }
                        ]
                    },
                    gender: {
                        identifier: 'gender',
                        rules: [
                            {
                                type: 'empty',
                                prompt: 'Выберите пол'
                            }
                        ]
                    },
                    age: {
                        identifier: 'age',
                        rules: [
                            {
                                type: 'empty',
                                prompt: 'Необходимо указать возраст'
                            },
                            {
                                type: 'integer[18..80]',
                                prompt: 'Допускаются только люди возрастом от 18 до 80 лет'
                            }
                        ]
                    }
                }
            });
    };

    self.GetVote = function () {
        $.ajax({
            url: '/api/voting',
            type: 'GET',
            success: function (response) {
                self.User(new UserViewModel(response.User));

                if (response.Questions && response.Questions.length > 0) {
                    for (var i = 0; i < response.Questions.length; i++) {
                        self.Questions.push(new QuestionViewModel(response.Questions[i]));
                    }
                }

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

    self.SaveVote = function () {
        if (!self.ValidateVote()) return;

        self.InSaveProcess(true);
        var postData = ko.toJSON(self);

        $.ajax({
            method: 'POST',
            url: '/api/voting',
            data: postData,
            contentType: "application/json; charset=utf-8",
            // beforeSend: function () { },
            error: function (response) {
                if (response.status == 400) {
                    var errors = response.responseJSON.ModelState;
                    self.ValidateVote(errors);
                } else {
                    var message = 'При сохранении голоса произошла ошибка';
                    var noty = new Noty(notyOptions);
                    noty.options.type = 'error';
                    noty.options.text = message;
                    noty.show();
                }

                self.InSaveProcess(false);
            },
            success: function (response) {
                window.location = '/Home/Congratulations';
            }
        });
    };

    self.ValidateVote = function (errors) {
        $('#clientErrors').hide();
        $('#serverErrors').hide();
        self.ValidationErrors([]);

        if (!errors) {
            $('#form').form('validate form');
            var isValid = $('#form').form('is valid');
            if (isValid) return true;

            $('#clientErrors').show();
        } else {
            for (var error in errors) {
                var selector = error.replace('viewModel.', '');
                var input = $("[name='" + selector + "']");
                var block = input.closest('.field');
                if (!block) {
                    input.addClass('error');
                } else {
                    block.addClass('error');
                }

                for (var message in errors[error]) {
                    self.ValidationErrors.push(errors[error][message]);
                }
            }

            $('#serverErrors').show();
        }

        var message = 'Пожалуйста, исправьте ошибки';
        var noty = new Noty(notyOptions);
        noty.options.type = 'error';
        noty.options.text = message;
        noty.show();

        return false;
    };
};