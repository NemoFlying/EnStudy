
//注意：导航 依赖 element 模块，否则无法进行功能性操作
layui.use('element', function () {
    var element = layui.element;

    //…
});
//富文本
function AddUserStudySchedue(data) {
    $(".one").empty();
    $(data).each(function (i, item) {
        $(".one").prepend(`
                <li class='ItemShowLi'>
                    <div class='ItemShow'>
                        <p class='context' name='`+ item.Id + `'>` + unescape(item.StudyContents) + `</p>
                        <p>`+ (new Date(parseInt(item.StudyDay.replace(/\D/igm, "")))).toLocaleString() + `</p>
                        <button class="layui-btn layui-btn-danger delBtn" onClick='delGetUserStudySchedue(this)'>删除</button>
                    </div>
                </li>
            `);
    });
};

function delGetUserStudySchedue(opt) {
    var Id = $(opt).siblings(".context").attr("name");
    console.log(Id);
    $.ajax({
        dataType: "json",
        url: "../User/DeleteStudySchedue",
        data: {
            SchedueId: Id
        },
        success: function (reData) {
            console.log(reData);
            AddUserStudySchedue(reData.Data);
        }
    });
}
$(function () {
    $('#summernote').summernote({
        lang: 'zh-CN',
        placeholder: '日程提醒',
        tabsize: 2,
        height: 300,
        maxHeight: 300,

    });
    $.ajax({
        dataType: "json",
        url: "../User/GetUserStudySchedue",
        data: {
        },
        success: function (reData) {
            //console.log(reData);
            AddUserStudySchedue(reData.Data);
        }
    });
    $(".delBtn").click();

    layui.use('laydate', function () {
        var laydate = layui.laydate;
        var date = new Date();
        var seperator1 = "-";
        var year = date.getFullYear();
        var month = date.getMonth() + 1;
        var strDate = date.getDate();
        strDate = strDate + 1;
        if (month >= 1 && month <= 9) {
            month = "0" + month;
        }
        if (strDate >= 0 && strDate <= 9) {
            strDate = "0" + strDate;
        }
        var currentdate = year + seperator1 + month + seperator1 + strDate;
        //执行一个laydate实例
        laydate.render({
            elem: '#test1', //指定元素
            calendar: true, //允许显示公历节日
            min: currentdate,
            done: function (value, date, endDate) {
                var Date = value;
                console.log(value); //得到日期生成的值，如：2017-08-18
                //console.log(date); //得到日期时间对象：{year: 2017, month: 8, date: 18, hours: 0, minutes: 0, seconds: 0}
                //console.log(endDate); //得结束的日期时间对象，开启范围选择（range: true）才会返回。对象成员同上。
                $(".StudySchedueBtn").click(function () {
                    //var date = new Date();
                    //var seperator1 = "-";
                    //var year = date.getFullYear();
                    //var month = date.getMonth() + 1;
                    //var strDate = date.getDate();
                    //if (month >= 1 && month <= 9) {
                    //    month = "0" + month;
                    //}
                    //if (strDate >= 0 && strDate <= 9) {
                    //    strDate = "0" + strDate;
                    //}
                    //var currentdate = year + seperator1 + month + seperator1 + strDate;
                    //console.log(currentdate);
                    var StudyContents = $($("#summernote").summernote("code")).html();
                    console.log(StudyContents);
                    StudyContents = escape(StudyContents);

                    console.log(StudyContents);
                    $.ajax({
                        dataType: "json",
                        url: "../User/AddUserStudySchedue",
                        data: {
                            StudyDay: Date,
                            StudyContents: StudyContents
                        },
                        success: function (reData) {
                            console.log(reData);
                            AddUserStudySchedue(reData.Data);
                        }
                    });
                });
            }
        });
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