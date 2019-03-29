//注意：导航 依赖 element 模块，否则无法进行功能性操作
layui.use('element', function () {
    var element = layui.element;

    //…
});
layui.use('form', function () {
    var form = layui.form;
    $(function () {
        //绑定个人数据
        function GetCurrentUserInfo(data) {
            $(data).each(function (i, item) {
                $(".AccountNo").val(item.AccountNo);
                $(".AccountNo").attr("id", item.Id);
                //昵称
                if (item.NikeName != null) {
                    $(".NikeName").val(item.NikeName);
                }
                //省份
                if (item.Addr != null) {
                    console.log(item.Addr);
                    var province = $(".province");
                    var dl = province.siblings("div.layui-form-select").find('dl');
                    dl.find("dd").removeClass("layui-this");
                    //dl.find('dd:contains(山西)').addClass("layui-this").click();
                    var dd = dl.find('dd:contains("' + item.Addr + '")').addClass("layui-this").click();
                }
                //大学
                if (item.UniversityName != null) {
                    console.log(item.UniversityName);
                    var UniversityName = $(".UniversityName");
                    var dl = UniversityName.siblings("div.layui-form-select").find('dl');
                    console.log(UniversityName.siblings(".layui-form-select").length);
                    dl.find("dd").removeClass();
                    var dd = dl.find('dd:contains(中国民航大学)').addClass("layui-this").click();
                }
                //性别
                if (item.Sex != null) {
                    $(".sex").find("input").removeAttr("checked");
                    $(".sex").find("input[value=" + item.Sex + "]").attr("checked");
                }
                //个性标签
                if (item.PersonalLabel != null) {
                    $(".PersonalLabel").val(item.PersonalLabel);
                }
                //个性签名
                if (item.Signature != null) {
                    $(".Signature").val(item.Signature);
                }
            });
        };
        //获取对应省份数据
        layui.use('form', function () {
            var form = layui.form;
            $.ajax({
                dataType: "json",
                url: "../User/GetCurrentUserInfo",
                data: {
                },
                success: function (reData) {
                    console.log(reData);
                    if (reData.Status != true) {
                    } else {

                        GetCurrentUserInfo(reData.Data);
                    }
                }
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
        //表单
        layui.use('form', function () {
            var form = layui.form;
            //监听提交
            //下拉框的二级联动
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
        //上传图片
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

        $(".submitBtn").click(function () {

        });
        layui.use('form', function () {
            var form = layui.form;
            $(".tianji").click(function () {
                var Id = $(".AccountNo").attr("id");
                var Password = $(".pwd").val();
                var NikeName = $(".NikeName").val();
                var Sex = $(".sex").find("input[name='sex']:checked").val();
                var Addr = $(".province").siblings("div.layui-form-select").find("input").val();
                var UniversityName = $(".university").siblings("div.layui-form-select").find("input").val();
                var PersonalLabel = $(".PersonalLabel").val();
                var Signature = $(".Signature").val();
                console.log(Id);
                console.log(Password);
                console.log(NikeName);
                console.log(Sex);
                console.log(Addr);
                console.log(UniversityName);
                console.log(PersonalLabel);
                console.log(Signature);
                $.ajax({
                    dataType: "json",
                    url: "../User/UpdateUser",
                    data: {
                        Id: Id,
                        Password: Password,
                        NikeName: NikeName,
                        Sex: Sex,
                        Addr: Addr,
                        UniversityName: UniversityName,
                        PersonalLabel: PersonalLabel,
                        Signature: Signature
                    },
                    success: function (reData) {
                        console.log(reData);
                        GetCurrentUserInfo(reData.Data);
                    }
                });
                //var province = $(".province");

                //var dl = province.siblings("div.layui-form-select").find('dl');
                //dl.find("dd").removeClass();
                //var dd = dl.find('dd:contains(山西)').addClass("layui-this").click();
            });

        });


    });
});