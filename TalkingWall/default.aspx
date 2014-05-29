<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TalkingWall._default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Talking Wall</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="width:320px; margin-left:250px; text-align:left">
        Message:<br />
        <asp:TextBox Width="300" Height="50" TextMode="MultiLine" runat="server" ID="WallInput" /><br />
        Name:<br />
        <asp:TextBox Width="242px" runat="server" ID="WallName" />&nbsp;
        <asp:Button Text="Post" runat="server" ID="PostButton" OnClick="PostButton_Click"/>
    </div>
        <div style="text-align:center">
            <asp:Repeater ID="WallRepeater" runat="server">
                <HeaderTemplate>
                    <div>The Wall</div>
                </HeaderTemplate>
                <ItemTemplate>
                    <div>
                        <div><%# DataBinder.Eval(Container.DataItem, "Message")%></div>
                        <div>
                            <span><%# DataBinder.Eval(Container.DataItem, "Name")%></span>
                            <span><%# DataBinder.Eval(Container.DataItem, "TimeStamp")%></span>
                        </div>
                    </div>
                </ItemTemplate>
                <SeparatorTemplate>
                    <div style="width:100%; height:25px;"></div>
                </SeparatorTemplate>
            </asp:Repeater>
            <asp:GridView ID="WallGrid" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" >
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </form>
</body>
</html>
