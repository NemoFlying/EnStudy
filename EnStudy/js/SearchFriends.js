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

});