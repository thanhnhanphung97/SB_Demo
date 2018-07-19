//$('#btnSelectedImageIntro').on('click', function (e) {
//    e.preventDefault();
//    var finder = new CKFinder();
//    finder.selectActionFunction = function (url) {
//        $('#txtImageIntro').val(url);
//        document.getElementById("imageIntro").src = url;
//        document.getElementById("imageIntro").style.backgroundColor = 'lightgrey';
//        document.getElementById("imageIntro").hidden = false;
//    }
//    finder.popup();
//})
//function change() {
//    var get = document.getElementById("getColor").value;
//    document.getElementById("txtColor").value = get;
//}
var q = "_intro";
function clickBtn(e, k) {
    var p = e.id + "_1";
    document.getElementById(k).style.display = "none";
    document.getElementById(p).style.display = "block";
    q = k;
}
function NoneBtn(e, k) {
    document.getElementById(e).style.display = "none";
    document.getElementById(k).style.display = "block";
}
var s = "_home";
function clickItem(e) {
    var et = "_" + e.id;
    var m = "create" + q + "_1";
    var n = "details" + q + "_1";
    document.getElementById(s).style.display = "none";
    document.getElementById(m).style.display = "none";
    document.getElementById(n).style.display = "none";
    document.getElementById(et).style.display = "block";
    q = s = et;
}
//$('#btnSelectedBackGround').on('click', function (e) {
//    e.preventDefault();
//    var finder = new CKFinder();
//    finder.selectActionFunction = function (url) {
//        $('#txtBackGround').val(url);
//        document.getElementById("background").src = url;
//        document.getElementById("background").style.backgroundColor = 'lightgrey';
//        document.getElementById("background").hidden = false;
//    };
//    finder.popup();
//});
