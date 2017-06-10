(function ($) {
    $(function () {
        var _$taskStateCombobox = $('#TaskStateCombobox');
        _$taskStateCombobox.change(function () {
            location.href = '/Tasks?state=' + _$taskStateCombobox.val();
        });

        $('.btnDelete').click(function () {
            var obj = $(this);
            abp.message.confirm(
                '确定删除吗？',
                '警告',
                function (isConfirmed) {
                    if (isConfirmed) {
                        if (!obj) {
                            abp.message.error('错误', '参数错误');
                        }
                        abp.services.app.task.delete({ id: obj.attr('data-id')})
                            .done(function (response) {
                                console.log(response);
                                location.reload();
                            });
                    }
                }
            );
        })
    });

    
})(jQuery);