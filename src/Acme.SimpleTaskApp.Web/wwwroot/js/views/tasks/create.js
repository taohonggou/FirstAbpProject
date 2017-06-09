﻿(function ($) {
    $(function () {
        var _$form = $('#TaskCreationFrom');
        _$form.find('input:first').focus();
        _$form.validate();
        _$form.find('button[type=submit]')
            .click(function (e) {
                e.preventDefault();

                if (!_$form.valid()) {
                    return;
                }

                var input = _$form.serializeFormToObject();
                abp.services.app.task.create(input)
                    .done(function (response) {
                        console.log(response);
                        location.href = '/Tasks';
                    });
            });
    })
})(jQuery);