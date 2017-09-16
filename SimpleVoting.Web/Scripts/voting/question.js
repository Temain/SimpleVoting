function QuestionViewModel(questionViewModel) {
    if (!questionViewModel) {
        questionViewModel = {};
    }

    var self = this;
    self.QuestionId = ko.observable(questionViewModel.QuestionId || 0);
    self.QuestionText = ko.observable(questionViewModel.QuestionText || '');
    self.SelectedAnswerId = ko.observable(questionViewModel.SelectedAnswerId || 0);
    self.Answers = ko.observableArray(questionViewModel.Answers || []);
}

QuestionViewModel.prototype.toJSON = function () {
    var copy = ko.toJS(this);
    delete copy.QuestionText;
    delete copy.Answers;
    return copy;
}