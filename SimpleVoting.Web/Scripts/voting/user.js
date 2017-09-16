function UserViewModel(userViewModel) {
    if (!userViewModel) {
        userViewModel = {};
    }

    var self = this;
    self.UserId = ko.observable(userViewModel.UserId || 0);
    self.Username = ko.observable(userViewModel.Username || '');
    self.Age = ko.observable(userViewModel.Age || '');
    self.GenderId = ko.observable(userViewModel.GenderId || 0);
    self.Genders = ko.observableArray(userViewModel.Genders || []);
}

UserViewModel.prototype.toJSON = function () {
    var copy = ko.toJS(this);
    delete copy.Genders;
    return copy;
}