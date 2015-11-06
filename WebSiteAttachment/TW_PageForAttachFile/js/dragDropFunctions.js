var selectedFiles;

$(document).ready(function () {

    if (!Modernizr.draganddrop) {
        alert("This browser doesn't support File API and Drag & Drop features of HTML5!");
        return;
    }

    var box;
    box = document.getElementById("form1");
    if (box.addEventListener) {
        box.addEventListener("dragenter", OnDragEnter, false);
        box.addEventListener("dragover", OnDragOver, false);
        box.addEventListener("drop", OnDrop, false);
        box.addEventListener("dragleave", OnDragLeave, false);
    }
    else {
        box.attachEvent("dragenter", OnDragEnter, false);
        box.attachEvent("dragover", OnDragOver, false);
        box.attachEvent("drop", OnDrop, false);
        box.attachEvent("dragleave", OnDragLeave, false);
    }

    $('#file_upload').on("change", function (e) {
        $('#box').addClass("dragDrop");
        OnDrop(e);
    });

    $('#fileNameBox input').on("click", function () {
        $('#file_upload').removeAttr('hidden');
        $('#fileNameBox').attr("hidden", 'hidden');
        $('#file_upload').click();
    });
});

function OnDragEnter(e) {
    e.stopPropagation();
    e.preventDefault();
    $('#box').addClass("dragDrop");
}

function OnDragOver(e) {
    e.stopPropagation();
    e.preventDefault();
    $("#box").removeClass("errorFile");
    $('#box').text("Drop file here");
    $('#box').addClass("dragOver");
}

function OnDragLeave(e) {
    e.stopPropagation();
    e.preventDefault();
    $("#box").removeClass("dragOver");
}

function OnDrop(e) {
    var isDragDrop = false;
    $("#box").removeClass("dragOver");
    if (e.dataTransfer != undefined) {
        e.stopPropagation();
        e.preventDefault();
        selectedFiles = e.dataTransfer.files;

        var file_upload = $('#file_upload');
        file_upload[0].files = e.dataTransfer.files;
    }
    else if (navigator.userAgent.indexOf("MSIE 7") !== -1) {
        return;
    }
    else {
        selectedFiles = e.currentTarget.files;
        isDragDrop = true;
    }

    IsCorrectFile(isDragDrop);

}

function IsCorrectFile(isDragDrop) {
    if (selectedFiles[0].type == "application/pdf" && selectedFiles[0].size <= 16777216) {
        $("#box").removeClass("errorFile");
        $('#regexValidator').attr("visibility", "none");
        $('#Submit1').removeAttr("disabled", "disabled");

        if (!isDragDrop) {
            var browserName = GetBrowserName();
            if (browserName == "IE" || browserName == "Firefox") {
                $('#fileNameBox').removeAttr("hidden");
                $('#fileName').text(PruningStrings(selectedFiles[0].name));
                $('#file_upload').attr('hidden', 'hidden');

                SetHttpPostedFile();
            }
        }
        else {
            var browserName = GetBrowserName();
            if (browserName == "IE" || browserName == "Firefox") {
                $('#file_upload').removeAttr('hidden');
                $('#fileNameBox').attr("hidden", 'hidden');

                SetHttpPostedFile();
            }
        }
        //SetHttpPostedFile();
    }
    else {
        $("#box").text("Only .PDF files are allowed and size must not exceed 16 Mb");
        $("#box").removeClass("dragOver");
        $("#box").removeClass("dragDrop");
        $("#box").addClass("errorFile");
        $('#Submit1').attr("disabled", "disabled");
       
        if (!isDragDrop) {
            var browserName = GetBrowserName();
            if (browserName == "IE") {
                $('#fileNameBox').removeAttr("hidden");
                $('#fileName').text(PruningStrings(selectedFiles[0].name));
                $('#file_upload').attr('hidden', 'hidden');
            }
        }
        else {
            var browserName = GetBrowserName();
            if (browserName == "IE") {
                $('#file_upload').removeAttr('hidden');
                $('#fileNameBox').attr("hidden", 'hidden');
            }
        }
    }
}

function SetHttpPostedFile() {
    var data = new FormData();
    for (var i = 0; i < selectedFiles.length; i++) {
        data.append(selectedFiles[i].name, selectedFiles[i]);
    }
    $.ajax({
        type: "POST",
        url: "DragDropHandler.ashx",
        contentType: false,
        processData: false,
        data: data,
        success: function (result) {
            $('#Submit1').removeAttr("disabled", "disabled");
            $('#box').text("Drop file here");
        },
        error: function (e) {
            alert("There was error uploading files!");
        },
        beforeSend: function (xhr) {
            $('#box').text("Adding file...");
            $('#Submit1').attr("disabled", "disabled");
        }
    });
}

function GetBrowserName() {

    var ua = navigator.userAgent;
    if (ua.match(/MSIE/)) return 'IE';
    if (ua.indexOf(".NET CLR") != -1) return 'IE';
    if (ua.match(/Firefox/)) return 'Firefox';
    if (ua.match(/Opera/)) return 'Opera';
    if (ua.match(/Chrome/)) return 'Chrome';
    if (ua.match(/Safari/)) return 'Safari';

}

function PruningStrings(str) {
    var result = "";

    if (str.length > 30) {
        var temp = str.substring(0, 23);
        result = temp + "...";
        temp = str.substring(str.length - 6);
        result += temp;
    }
    else
        result = str;

    return result;
}

function ClearFileInputField(Id) {
    document.getElementById(Id).innerHTML = document.getElementById(Id).innerHTML;
}