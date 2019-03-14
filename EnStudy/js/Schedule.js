$('#summernote').summernote({
    lang: 'zh-CN',
    placeholder: '日程提醒',
    tabsize: 2,
    height: 300,
    maxHeight: 300
});
//注意：导航 依赖 element 模块，否则无法进行功能性操作
layui.use('element', function () {
    var element = layui.element;

    //…
});
//富文本

$(function () {



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