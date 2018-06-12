//tinyMCE.init(
//{
//    selector: "textarea"
//});

$(document).ready(function () {

    $('btnSelectedImage').on('click', function (e) {
        e.preventDefault();
        var finder = new CKFinder();
        finder.selectActionFunction = function (url) {
            $('#txtImage').val(url);
        };
        finder.popup();
    })
})