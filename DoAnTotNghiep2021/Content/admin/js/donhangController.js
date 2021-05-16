var donhang = {
    init: function () {
        donhang.registerEvents();
    },
    registerEvents: function () {
        $('.btn-active').off('click').on('click', function (e) {
            e.preventDefault();
            var btn = $(this);
            var id = btn.data('id');
            $.ajax({
                url: "/Admin/DonHang/ChangeStatus",
                data: { id: id },
                dataType: "json",
                type: "POST",
                success: function (response) {
                    console.log(response);
                    if (response.DaXacNhan == true) {
                        btn.text('Đã xác nhận');
                    }
                    else {
                        btn.text('Xác nhận');
                    }
                }
            });
        });
    }
}
donhang.init();