var order = {
    init: function () {
        order.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = $(this).data('id');
            $.ajax({
                url: "/Admin/Order/ChangeStatus",
                data: { id: id },
                datatype: "json",
                type: "POST",
                success: function (res) {
                    if (res.status == 1) {
                        btn.text('Đã giao');
                    }
                    else {
                        btn.text('Chưa giao');
                    }
                }
            });
        });
    }
}
order.init();