function delBtn(opt) {
    var UserIdId = $(opt).parents("tr").find("td:nth(0) div").text();
    //console.log(UserIdId);

    $.ajax({
        dataType: "json",
        url: "../User/DeleteUser",
        data: {
            UId: UserIdId
        },
        success: function (reData) {
            console.log(reData);
            if (reData.Status != true) {
                alert("删除失败！");
            } else {

                GetUserList(reData.Data);

            }
        }
    });
};
layui.use('form', function () {
    var form = layui.form;




    $(function () {


        function GetUserList(data) {
            layui.use('table', function () {
                var table = layui.table;
                $(".itemShowCount tbody").empty();
                $(data).each(function (i, item) {
                    //console.log(item);
                    
                    $(".itemShowCount tbody").append(`
                        <tr>
                            <td class='UserId'>`+ item.Id + `</td>
                            <td>`+ item.AccountNo + `</td>
                            <td>`+ item.QqId + `</td>
                            <td><button type='button' class="layui-btn layui-btn-danger layui-btn-sm delBtn" onclick='delBtn(this)'>删除</button></td>
                        </tr>
                    `);
                });


                table.init('itemShowCount', {
                    height: "auto" //设置高度
                    //, limit: 10 //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
                    //支持所有基础参数

                });


            });

        }

        $.ajax({
            dataType: "json",
            url: "../User/GetUserList",
            data: {
                key: "*"
            },
            success: function (reData) {
                console.log(reData);
                if (reData.Status != true) {
                    alert("没有用户信息！");
                } else {
                    
                    GetUserList(reData.Data);


                   
                }
            }
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