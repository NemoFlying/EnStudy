//注意：导航 依赖 element 模块，否则无法进行功能性操作
layui.use('element', function () {
    var element = layui.element;

    //…
});

function replace_em(str) {

    str = str.replace(/\</g, '&lt;');

    str = str.replace(/\>/g, '&gt;');

    str = str.replace(/\n/g, '<br/>');

    str = str.replace(/\[em_([0-9]*)\]/g, '<img src="../assets/img/arclist/$1.gif" border="0" />');

    return str;

}


$(function () {
    $('#emotion').qqFace({

        id: 'facebox',

        assign: 'saytext',

        path: '../assets/img/arclist/'	//表情存放的路径

    });
    //发表说说
    $(".sub_btn").click(function () {

        var str = $("#saytext").val();
        var strs = escape(str);
        console.log(strs);
        $.ajax({
            dataType: "json",
            url: "../User/AddNewSpeak",
            data: {
                contents: str
            },
            success: function (reData) {
                console.log(reData);
                if (reData.Status != true) {
                    alert("发表失败！");
                } else {
                    //GetFriendSpeak(reData.Data);
                    $(".one").append("<li class='itemMessages'><p><img src='../assets/img/smile.png' alt='头像' /><span>用户名：</span><span>张三</span></p><p class='MessageBoard'>" + replace_em(str) + "</p></li>");
                }
            }
        });

        //$(".one").append("<li>"+replace_em(str)+"</li>");
        

    });

    function GetFriendSpeak(data) {
        //console.log(data);
        $(data.userSpeak).each(function ( i,item ) {
            console.log(item);
            var li = $(" <li class='itemMessages'></li>");
            li.append(`
                <p>
                    <img src='../assets/img/smile.png' alt='头像' />
                    <span>`+ item.user.AccountNo+`</span>
                </p>
                <p class='SpeakTime'>`+ (new Date(parseInt(item.SpeakTime.replace(/\D/igm, "")))).toLocaleString() +`</p>
                <p class='MessageBoard' title='`+ item.Id +`'>`+ replace_em(item.Contents) +`</p>
                <div class='Coment'></div>
                    <div class="com_form">
                        <textarea class="input msgText" rows='5' style='resize: none;' id="saytext1" name="saytext" placeholder="试试用外语发表吧，说不定会有小伙伴为你点评哦~"></textarea>
                        <p>
                            <button type="button" class="layui-btn sub_btn">发表</button>

                            <span class="emotion emotion1" id="emotion"></span>
                            <button type="button" id="test2" class='addmsgBtn'>
                                <i class="layui-icon">&#xe660;</i>
                            </button>

                        </p>
                    </div>
            `);
            $(".one").append(li);
            $(item.Coment).each(function (i, item) {
                //console.log(item);
                li.find(".Coment").append(`
                <div class='reply'><p><span>` + item.User.AccountNo + `:</span></p><p>` + replace_em(item.Contents) + `</p>
                    
                    <p class='ComentTime'>`+ (new Date(parseInt(item.ComentTime.replace(/\D/igm, "")))).toLocaleString() +`</p>
                    <div class='CSpeakComent'></div>
                </div>
            `);
                
                $(item.CSpeakComent).each(function (i, item) {
                    //console.log(item);
                    while (item.CSpeakComent) {
                        $(".CSpeakComent").append(`
                        <p>`+ item.User.AccountNo + `</p>
                        <p>`+ replace_em(item.Contents) + `</p>
                        <p class='ComentTimeItems'>`+ (new Date(parseInt(item.ComentTime.replace(/\D/igm, "")))).toLocaleString() + `</p>
                    `);
                    }
                    
                });
            });
            $('.emotion1').qqFace({

                id: 'facebox',

                assign: 'saytext1',

                path: '../assets/img/arclist/'	//表情存放的路径

            });
        });

    };
    $(".addmsgBtn").click(function () {
        // 被留言的说说Id
        var SpeakId = $(".MessageBoard").attr("title");
        // 被留言的用户Id
        var ToUserId
        var msg = $(".msgText").text();
        console.log(msg, SpeakId)
    });
    $.ajax({
        dataType: "json",
        url: "../User/GetFriendSpeak",
        data: {
            
        },
        async: false,
        success: function (reData) {
            if (reData.Status != true) {
                alert("暂无数据！");
            } else {
                GetFriendSpeak(reData.Data);
            }
        }
    });

});

//查看结果


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
layui.use('upload', function () {
    var upload = layui.upload;

    //执行实例
    var uploadInst = upload.render({
        elem: '#test2' //绑定元素
        , url: '/upload/' //上传接口
        , done: function (res) {
            //上传完毕回调
        }
        , error: function () {
            //请求异常回调
        }
    });
});