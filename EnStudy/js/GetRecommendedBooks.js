$(function () {
    function GetRecommendedBooks(Data) {
        $(Data).each(function (i, item) {
            console.log(item);
            $(".imgShow").append(`
                <div class="itemImgBook" title='`+item.Id+`'>
                    <img src="`+item.BookImgUrl+`" alt="`+item.BookIntroduction+`" />
                </div>
            `);
        });
    }
    $.ajax({
        dataType: "json",
        url: "../RecommendedBook/GetRecommendedBooks",
        async: false,
        data: {
        },
        success: function (reData) {
            console.log(reData);
            GetRecommendedBooks(reData.Data);
        }, error: function () {
            alert("暂无图书推荐！");
        }
    });
});