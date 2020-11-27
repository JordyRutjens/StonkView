$("#StockTable tr").click(function () {
    $(this).addClass('selected').siblings().removeClass('selected');
    var value = $(this).find('td:first').html();
    alert("You have clicked stock "+value + "(For Debugging)");

});

$('.ok').on('click', function (e) {
    alert($("#table tr.selected td:first").html());
});
