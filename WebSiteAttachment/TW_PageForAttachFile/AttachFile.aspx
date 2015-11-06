<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AttachFile.aspx.cs" Inherits="TW_PageForAttachFile.AttachFile" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Web site attachment: New - Microsoft Dynamics CRM</title>
    <link rel="shortcut icon" href="img/icon.gif" type="image/gif" />
    <link href="style/styles.css" rel="stylesheet" type="text/css" />
    <link rel="stylesheet" type="text/css" href="style/uploadify.css" />

    <script type="text/javascript" src="js/scripts.js"></script>
    <script type="text/javascript" src="js/jquery-1.7.2.min.js"></script>
    <script type="text/javascript" src="js/jquery.uploadify.min.js"></script>
    <script type="text/javascript" src="js/uploadify.js"></script>
    <script type="text/javascript" src="js/modernizr-2.5.3.js"></script>
    <script type="text/javascript" src="js/dragDropFunctions.js"></script>

    <!--<script type="text/javascript">
		$(function () {
			$("#file_upload").uploadify({
				'swf'       : 'scripts/uploadify.swf',
				'uploader': 'Upload.ashx',
				'multi': false,
				'fileSizeLimit': '500MB',
				'successTimeout': 72000,
				'auto': true, 
				'width' : 70,
				'height' : 18
			});
		});
	</script>-->
</head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
        <div id="mainDiv">
            <div id="header">
                <h3>Manage Web Site Attachment</h3>
                <p>Click Browse to select and attach a file, click an existing file to view it, or click Remove to remove a file.</p>
            </div>
            <div id="content">
                <div id="nameAll">
                    <div id="lbl_Name">
                        <span>Name:<span class="important">*</span></span>
                    </div>
                    <div id="txbx_NameDiv">
                        <input type="text" name="name" id="txbx_Name" runat="server" />
                        <span id="validField"></span>
                    </div>
                </div>
                <div id="attachType">
                    <div id="lbl_attachType">
                        <span>Attachment Type:<span class="important">*</span></span>
                    </div>
                    <div id="slct_attachType" runat="server">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                            <asp:ListItem Selected="True"></asp:ListItem>
                            <asp:ListItem>Demo</asp:ListItem>
                            <asp:ListItem>Flyer</asp:ListItem>
                            <asp:ListItem>Map</asp:ListItem>
                            <asp:ListItem>Site Plan</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
            </div>
            <div id="attachFile">
                <div id="attachFileImg">
                    <img src="img/secHead.png" name="secHead" alt="secHead.png" />
                    <span class="fileAttachmentText">File Attachment</span>
                </div>

                <div id="attachFileTable">
                    <table>
                        <tr>
                            <td><span id="maxSize" runat="server">Max. file size: 16 Mb</span></td>
                            <td></td>
                        </tr>
                       <tr>
                            <td>
                                <span>File name: <span class="important">*</span></span>
                                <asp:FileUpload ID="file_upload" runat="server" CssClass="file_upload" />

                                <%--<div id="fileNameBox" hidden="hidden">
                                    <span id="fileName"></span>
                                    <input type="button" value="Browse" class="button"/>
                                </div>
                                
                                <div id="box" class="dragDrop">Drag & Drop files here.</div>--%>
                            </td>
                            <td></td>
                            <td>

                                <input id="Submit1" type="submit" name="btn_attach" value="Attach" class="button" runat="server" onclick="document.forms['form1'].submit();" />
                                <script type="text/javascript">
                                    $('#Submit1').click(function () {
                                        $(this).attr("disabled", true);
                                        //document.getElementById("regexValidator").style.display = 'none';
                                    });
                                </script>
                            </td>
                            <td>
                                <input type="button" name="btn_close" value="Close" class="button" onclick="closeWindows();" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="fileNameBox" hidden="hidden">
                                    <span id="fileName"></span>
                                    <input type="button" value="Browse" class="button"/>
                                </div>
                                
                                <%--<asp:RegularExpressionValidator ID="regexValidator" runat="server"
                                     ControlToValidate="file_upload"
                                     ErrorMessage="Only PDF files are allowed" 
                                     ValidationExpression="(.*\.([Pp][Dd][Ff])|.*\.([Pp][Dd][Ff])$)" 

                                     style="color: red; 
                                            font-weight:bold;
                                            display: block;
                                            margin-top: 10px;">
                                </asp:RegularExpressionValidator>--%>
                            </td>
                        </tr>
                    </table>
                    <div id="box" class="dragDrop" runat="server">Drop file here</div>
                </div>
            </div>
            <asp:Label ID="lbl_ErrorMessage" runat="server" Text="" ForeColor="#990000"></asp:Label>
        </div>
    </form>
</body>
</html>
