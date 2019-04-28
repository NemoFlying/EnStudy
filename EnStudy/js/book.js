
layui.use('form', function () {
    var form = layui.form;

    $(function () {
        //绑定书籍信息

        function AddRecommendedBook(Data) {
            //console.log(Data);
            $(".itemShowCount tbody").empty();
            layui.use('table', function () {
                var table = layui.table;
                
                $(Data).each(function (i, item) {
                    console.log(item);
                    
                    $(".itemShowCount tbody").append(`
                        <tr>
                            <td class='bookId'>`+ item.Id + `</td>
                            <td>`+ item.BookName + `</td>
                            <td>`+ item.BookIntroduction + `</td>
                            <td>`+ item.BookShopUrl + `</td>
                            <td><button type='button' class="layui-btn layui-btn-danger layui-btn-sm delBtn">删除</button></td>
                        </tr>
                    `);
                });
                table.init('itemShowCount', {
                    height: "auto" //设置高度
                    //, limit: 10 //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
                    //支持所有基础参数

                });


            });

        };

        //添加图书推荐
        $(".submitBtn").click(function () {
            var BookImgUrl = $(".BookImgUrl").val();
            var BookName = $(".BookName").val();
            var BookIntroduction = $(".BookIntroduction").val();
            var BookShopUrl = $(".BookShopUrl").val();
            $.ajax({
                dataType: "json",
                url: "../RecommendedBook/AddRecommendedBook",
                data: {
                    BookName: BookName,
                    BookIntroduction: BookIntroduction,
                    BookImgUrl: BookImgUrl,
                    BookShopUrl: BookShopUrl
                },
                success: function (reData) {
                    //console.log(reData);
                    if (reData.Status != true) {
                        alert("没有书籍信息！");
                    } else {
                        AddRecommendedBook(reData.Data);
                    }
                }
            });
        });
        //获取书籍
        layui.use('table', function () {
            var table = layui.table;
            $.ajax({
                dataType: "json",
                url: "../RecommendedBook/GetRecommendedBooks",
                data: {
                },
                success: function (reData) {
                    console.log(reData);
                    if (reData.Status != true) {
                        alert("没有书籍信息！");
                    } else {

                        AddRecommendedBook(reData.Data);
                        //删除书籍推荐
                        $(".delBtn").click(function () {
                            var bookId = $(this).parents("tr").find("td:first div").text();
                            console.log(bookId);
                            $.ajax({
                                dataType: "json",
                                url: "../RecommendedBook/DeleteRecommendedBook",
                                async: false,
                                data: {
                                    bookId: bookId
                                },
                                success: function (reData) {
                                    console.log(reData);
                                    AddRecommendedBook(reData.Data);
                                }, error: function () {
                                    alert("删除失败！");
                                }
                            });
                        });
                        //GetUserList(reData.Data);
                        //$(".one").prepend("<li class='itemMessages'><p><img src='../assets/img/smile.png' alt='头像' /><span>用户名：</span><span>张三</span></p><p class='MessageBoard'>" + replace_em(str) + "</p></li>");
                    }
                }
            });
        });
    });
});
//注意：导航 依赖 element 模块，否则无法进行功能性操作
layui.use('element', function () {
    var element = layui.element;

    //…
});
layui.use('table', function () {
    var table = layui.table;

    //转换静态表格
    table.init('itemShowCount', {
        height: "auto" //设置高度
        //, limit: 10 //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
        //支持所有基础参数

    });
});
layui.use('carousel', function () {
    var carousel = layui.carousel;
    //建造实例
    carousel.render({
        elem: '#test1'
        , width: '100%' //设置容器宽度
        , arrow: 'none' //始终显示箭头
        //,anim: 'updown' //切换动画方式
    });
});

