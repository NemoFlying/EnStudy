//注意：导航 依赖 element 模块，否则无法进行功能性操作
layui.use('form', function () {
    var form = layui.form;

    //各种基于事件的操作，下面会有进一步介绍
    //添加标题加载数据
    function GetStudyNotesType(data) {
        $(".TypeId").empty();
        $(data).each(function (i, item) {
            $(".TypeId").append(`
                <option value="`+ item.Id + `">` + item.TypeName + `</option>
            `);
            $(".TypeIdShow").append(`
                <option value="`+ item.Id + `">` + item.TypeName + `</option>
            `);
            //$(".TypeIdShow").append(`
            //    <dd><a href="" title='`+ item.Id + `'>` + item.TypeName + `</a></dd>
            //`);
        });
    }
    $(function () {
        //获取笔记本类型列表
        $.ajax({
            dataType: "json",
            url: "../User/GetStudyNotesType",
            data: {

            },
            success: function (reData) {
                GetStudyNotesType(reData.Data);
                form.render("select");
            }
        });
        //加载已有笔记
        layui.use('table', function () {
            var table = layui.table;
            function GetStudyNotesBriefByTypeIdItem(Data) {
                $(".itemShowCount tbody").empty();
                $(Data).each(function (i, item) {
                    console.log(item);
                    var a = $(".itemShowCount").length;
                    console.log(a);
                    $(".itemShowCount tbody").append(`
                    <tr>
                        <td>`+ item.TypeName + `</td>
                        <td>`+ item.Description + `</td>
                        <td>sadsa</td>
                        <td><button class="layui-btn layui-btn-sm layui-btn-normal">详情</button></td>
                    </tr>
                `);

                });
                table.init('itemShowCount', {
                    height: "auto" //设置高度
                    //, limit: 10 //注意：请务必确保 limit 参数（默认：10）是与你服务端限定的数据条数一致
                    //支持所有基础参数
                });
            };
            form.on('select(TypeIdShow)', function GetStudyNotesBriefByTypeId(data) {
                //console.log(data.elem); //得到select原始DOM对象
                console.log(data.value); //得到被选中的值
                //console.log(data.othis); //得到美化后的DOM对象
                
                $.ajax({
                    dataType: "json",
                    url: "../User/GetStudyNotesType",
                    data: {
                        id: data.value
                    },
                    success: function (reData) {
                        //console.log(reData.Data);
                        GetStudyNotesBriefByTypeIdItem(reData.Data);
                        //form.render("select");

                    }
                });
            });

        });
        //qq表情
        $('.emotion').qqFace({

            id: 'facebox',

            assign: 'saytext',

            path: '../assets/img/arclist/'	//表情存放的路径

        });
        //添加分类标签
        $(".addSub_btn").click(function () {
            var addTypeIdInput = $(".addTypeIdInput").val();
            var KeyWords = $(".KeyWords").val();
            if (addTypeIdInput == null) {
                alert("请添加标题,不能为空！");
            } else {
                $.ajax({
                    dataType: "json",
                    url: "../User/AddStudyNotesType",
                    data: {
                        TypeName: addTypeIdInput,
                        Description: KeyWords
                    },
                    success: function (reData) {
                        $(".addTypeIdInput").val("");
                        GetStudyNotesType(reData.Data);
                        form.render("select");
                    }
                });
            }

        });

        //添加笔记
        $(".sub_btn").click(function () {
            var TypeId = $(".TypeId").find("option:selected").attr("value");
            var Uid = "admin";
            var Title = $(".Title").val();
            var KeyWords = $(".KeyWords").val();
            var Contents = $(".Contents").val();
            console.log(TypeId);
            console.log(Title);
            console.log(KeyWords);
            console.log(Contents);
            Contents = escape(Contents);
            $.ajax({
                dataType: "json",
                url: "../User/AddStudyNotes",
                data: {
                    TypeId: TypeId,
                    Title: Title,
                    KeyWords: KeyWords,
                    Contents: Contents
                },
                success: function (reData) {
                    console.log(reData)
                }
            });
            //$(".one").append("<li>"+replace_em(str)+"</li>");
            //$(".one").append("<li class='itemMessages'><p><img src='../assets/img/smile.png' alt='头像' /><span>用户名：</span><span>张三</span></p><p class='MessageBoard'>加油！</p></li>")

        });

    });

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
//查看结果
//转换表情
function replace_em(str) {

    str = str.replace(/\</g, '&lt;');

    str = str.replace(/\>/g, '&gt;');

    str = str.replace(/\n/g, '<br/>');

    str = str.replace(/\[em_([0-9]*)\]/g, '<img src="../assets/img/arclist/$1.gif" border="0" />');

    return str;

}

//轮播
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