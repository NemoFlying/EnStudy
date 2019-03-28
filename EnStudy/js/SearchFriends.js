$(function () {

    var searchLi = $(".searchLi").find("button");
    searchLi.click(function () {
        var searchInput = $(".searchInput").val();
        searchInput = encodeURI(searchInput);
        if (searchInput == "") {
            alert("请输入搜索好友名称！");

        } else {
            window.location.href = "SearchFriends?SearchNames=" + searchInput;
        }
    });

    //js获取url参数值
    function request(paras) {
        var url = location.href;
        var paraString = url.substring(url.indexOf("?") + 1, url.length).split("&");
        var paraObj = {};
        for (i = 0; j = paraString[i]; i++) {
            paraObj[j.substring(0, j.indexOf("=")).toLowerCase()] = j.substring(j.indexOf("=") + 1, j.length);
        }
        var returnValue = paraObj[paras.toLowerCase()];
        if (typeof (returnValue) == "undefined") {
            return "";
        } else {
            return returnValue;
        }
    }

    var SearchNames = decodeURI(request("SearchNames"));//De=‘未设置’
    console.log(SearchNames);
});