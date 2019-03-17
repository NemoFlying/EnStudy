$(function () {
    function GetFriendSpeak(data) {
        $(data.userSpeak).each(function ( i,item) {
            console.log(item)
            $(".one").append(`
                <li class='itemMessages'>
                    <p>
                        <img src='../assets/img/smile.png' alt='头像' />
                        <span>`+ item.user.AccountNo+`</span>
                    </p>
                    <p class='SpeakTime'>`+ (new Date(parseInt(item.SpeakTime.replace(/\D/igm, "")))).toLocaleString() +`</p>
                    <p class='MessageBoard'>`+ item.Contents +`</p>
                    <div class='Coment'></div>
                </li>
            `);
            $(item.Coment).each(function (i, item) {
                //console.log(item);
                $(".Coment").append(`
                <div class='reply'><p><span>` + item.User.AccountNo + `:</span></p><p>` + item.Contents + `</p>
                    
                    <p class='ComentTime'>`+ (new Date(parseInt(item.ComentTime.replace(/\D/igm, "")))).toLocaleString() +`</p>
                    <div class='CSpeakComent'></div>
                </div>
            `);
                $(item.CSpeakComent).each(function (i, item) {
                    console.log(item);
                    $(".CSpeakComent").append(`
                        <p>`+ item.User.AccountNo +`</p>
                        <p>`+ item.Contents +`</p>
                        <p class='ComentTimeItems'>`+ (new Date(parseInt(item.ComentTime.replace(/\D/igm, "")))).toLocaleString()+`</p>
                    `);
                });
            });
        });

    }
    $.ajax({
        dataType: "json",
        url: "../User/GetFriendSpeak",
        data: {
            
        },
        success: function (reData) {
            if (reData.Status != true) {
                alert("暂无数据！");
            } else {
                GetFriendSpeak(reData.Data);
            }
        }
    });
});