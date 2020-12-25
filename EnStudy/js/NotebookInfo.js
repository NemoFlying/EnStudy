$(function () {
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
    function GetRequest() {
        var url = location.search; //获取url中"?"符后的字串
        if (url.indexOf("?") != -1) {    //判断是否有参数
            var str = url.substr(1); //从第一个字符开始 因为第0个是?号 获取所有除问号的所有符串
            strs = str.split("=");   //用等号进行分隔 （因为知道只有一个参数 所以直接用等号进分隔 如果有多个参数 要用&号分隔 再用等号进行分隔）
            //alert(strs[1]);          //直接弹出第一个参数 （如果有多个参数 还要进行循环的）
            $.ajax({
                dataType: "json",
                url: "../User/GetStudyNotesById",
                async: false,
                data: {
                    id: strs[1]
                },
                success: function (reData) {
                    console.log(reData.Data);
                    $("#show").append(`
                        <h1>`+ reData.Data.Title+`</h1>
                        <h3>`+ reData.Data.Title + `</h3>
                        <p>`+ unescape(reData.Data.Contents) +`</p>
                    `);

                }
            });
        }
    }
    GetRequest();
    
});