<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="arduinoweb.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style3 {
            height: 157px;
        }
        .auto-style4 {
            height: 157px;
            width: 367px;
        }
        .auto-style5 {
            width: 367px;
        }
        .auto-style6 {
            width: 76px;
        }
        .auto-style7 {
            width: 64px;
        }
        .auto-style8 {
            height: 157px;
            width: 120px;
        }
        .auto-style9 {
            width: 120px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
 
      <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" style="height: 26px" Text="Button" />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="Button" />
    
        <br />
        <br />
        <br />
        <table class="auto-style1">
            <tr>
                <td class="auto-style4">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                    <asp:Image ID="Image1" runat="server" Height="328px" ImageUrl="~/resimler/suvar.gif" Width="175px" />
                </td>
                <td class="auto-style8">
                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style3">
                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                </td>
                <td class="auto-style3"></td>
            </tr>
            <tr>
                <td colspan="2">
                    <asp:Image ID="Image2" runat="server" Height="254px" ImageUrl="~/resimler/suhavuz.gif" Width="437px" />
                </td>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                </td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">
                    <table class="auto-style1">
                        <tr>
                            <td class="auto-style6">&nbsp;</td>
                            <td class="auto-style7">DURUM</td>
                            <td>&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style6">Motor 1</td>
                            <td class="auto-style7">
                                <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="Button3" runat="server" Text="Button" OnClick="Button3_Click" />
                            </td>
                            <td>
                                <asp:Button ID="Button4" runat="server" Text="Button" OnClick="Button4_Click" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">Motor 2</td>
                            <td class="auto-style7">
                                <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="Button5" runat="server" Text="Button" />
                            </td>
                            <td>
                                <asp:Button ID="Button6" runat="server" Text="Button" />
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style6">Motor 3</td>
                            <td class="auto-style7">
                                <asp:Label ID="Label6" runat="server" Text="Label"></asp:Label>
                            </td>
                            <td>
                                <asp:Button ID="Button7" runat="server" Text="Button" />
                            </td>
                            <td>
                                <asp:Button ID="Button8" runat="server" Text="Button" />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td class="auto-style5">&nbsp;</td>
                <td class="auto-style9">&nbsp;</td>
                <td>&nbsp;</td>
                <td>&nbsp;</td>
            </tr>
        </table>
    
    </div>
      
                <asp:Label ID="Label7" runat="server" Text="Label"></asp:Label>
                <asp:Timer ID="Timer1" runat="server" Interval="1000" OnTick="Timer1_Tick">
                </asp:Timer>
                <asp:ScriptManager ID="ScriptManager1" runat="server">
                </asp:ScriptManager>
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
