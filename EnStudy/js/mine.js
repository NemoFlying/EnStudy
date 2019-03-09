//注意：导航 依赖 element 模块，否则无法进行功能性操作
layui.use('element', function () {
    var element = layui.element;

    //…
});

$(function () {

    //获取对应省份数据


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
    //Demo
    layui.use('form', function () {
        var form = layui.form;
        //监听提交
        form.on('select(test)', function (data) {
            var provinceId = data.value; //得到被选中的值
            $.ajax({
                type: "POST",
                url: "http://119.29.166.254:9090/api/university/getUniversityByProvinceId?id=" + provinceId + "",
                success: function (reData) {
                    $(".university").empty();
                    console.log(reData);
                    $(reData).each(function () {
                        
                        //console.log(this);
                        $(".university").append(`
                            <option value="`+ this.id + `">` + this.name + `</option>
                        `);
                    });
                    form.render("select");
                },
                error: function (data) {
                    alert("下载模板失败！");
                }
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
    });
});