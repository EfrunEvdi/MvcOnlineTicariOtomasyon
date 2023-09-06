// Call the dataTables jQuery plugin
$(document).ready(function () {
    $('#dataTable').DataTable();
});

$(document).ready(function () {
    $(".sb-sidenav-menu").on("mouseenter", function () {
        // Yan çubuðun üzerine gelindiðinde içeriði göster
        $(this).css("overflow-y", "auto");
    });

    $(".sb-sidenav-menu").on("mouseleave", function () {
        // Yan çubuktan çýkýldýðýnda kaydýrma çubuðunu gizle
        $(this).css("overflow-y", "hidden");
    });
});