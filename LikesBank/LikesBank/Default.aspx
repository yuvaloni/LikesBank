<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="LikesBank.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="GTW.jpg" style="position:fixed;right:0; top:0; height:5%;width:20%;z-index:3;" OnClick="ImageButton1_Click" />
        <div id ="w1" runat="server" visible="false">
        
         <img src="window.png" style="z-index:2;position:fixed; top:30%; left:20%;width:60%; height:30%;"  />
            <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/close.png" style="z-index:3;position:fixed;top:35%;height:2%;width:2%;left:72%;" OnClick="ImageButton2_Click" />
            <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/connect.png" style="height:10%;width:20%;top:40%;left:40%;z-index:4;position:fixed;" OnClick="ImageButton3_Click" />
        </div>
                <div id ="w2" runat="server" visible="false">
        
         <img src="window.png" style="z-index:2;position:fixed; top:30%; left:20%;width:60%; height:30%;"  />
            <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/close.png" style="z-index:3;position:fixed;top:35%;height:2%;width:2%;left:72%;" OnClick="ImageButton4_Click" />
            <p style="position:fixed;top:35%;left:37%;z-index:4;">email: </p>
           <asp:TextBox ID="TextBox1" runat="server" style="position:fixed;top:36.9%;left:41%;z-index:4; height:2%; width:15%;"></asp:TextBox>
                        <p style="position:fixed;top:40%;left:36%;z-index:4;">website: </p>
           <asp:TextBox ID="TextBox2" runat="server" style="position:fixed;top:41.9%;left:41%;z-index:4; height:2%; width:15%;"></asp:TextBox>
                    <asp:ImageButton ID="ImageButton5" runat="server" ImageUrl="~/GO.png" style="position:fixed;top:49%;left:45%;z-index:4; height:5%; width:5%;" OnClick="ImageButton5_Click" />
                    <asp:CheckBox ID="CheckBox1" runat="server" style="position:fixed;top:45.9%;left:37%;z-index:4;" Text="I want likes" />
                    <asp:CheckBox ID="CheckBox2" runat="server" style="position:fixed;top:45.9%;left:45%;z-index:4;" Text="I want shares" />
          
        </div>
        <img src ="bg.jpg" style="top:-1px; left:-1px; position:fixed;height:100%;width:100%;z-index:0;" />
       
<img src ="bar.jpg" style="top:0;left:0;position:fixed;height:5%;width:100%;z-index:0;" />
    <img src ="Logo.jpg" style="top:0;left:39%; position:fixed;height:36px; width:25%;z-index:0;" />
    </form>

</body>
</html>

