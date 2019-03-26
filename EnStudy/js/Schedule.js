
//注意：导航 依赖 element 模块，否则无法进行功能性操作
layui.use('element', function () {
    var element = layui.element;

    //…
});
//富文本

$(function () {
    $('#summernote').summernote({
        lang: 'zh-CN',
        placeholder: '日程提醒',
        tabsize: 2,
        height: 300,
        maxHeight: 300,

    });
    function getNowFormatDate() {
        var date = new Date();
        var seperator1 = "-";
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var strDate = date.getDate();
        if (month >= 1 && month <= 9) {
            month = "0" + month;
        }
        if (strDate >= 0 && strDate <= 9) {
            strDate = "0" + strDate;
        }
        var currentdate = year + seperator1 + month + seperator1 + strDate;
        //console.log(currentdate);

        return currentdate;

    }

    $(".StudySchedueBtn").click(function () {
        var date = new Date();
        var seperator1 = "-";
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var strDate = date.getDate();
        if (month >= 1 && month <= 9) {
            month = "0" + month;
        }
        if (strDate >= 0 && strDate <= 9) {
            strDate = "0" + strDate;
        }
        var currentdate = year + seperator1 + month + seperator1 + strDate;
        //console.log(currentdate);
        var StudyContents = $($("#summernote").summernote("code")).html();
        console.log(StudyContents);
        StudyContents = escape(StudyContents);
        console.log(StudyContents);
        $.ajax({
            dataType: "json",
            url: "../User/AddUserStudySchedue",
            data: {
                StudyDay: currentdate,
                StudyContents: StudyContents
            },
            success: function (reData) {
                console.log(reData);
            }
        });
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