var thongke = {
    init: function () {
        thongke.registerEvents();
    },
    registerEvents: function () {
        $('.btn-loc').off('click').on('click')
    }
}
thongke.init();