<%@ Page Title="Talking Wall" Language="C#" MasterPageFile="~/TalkingWall.Master" AutoEventWireup="true" CodeBehind="default.aspx.cs" Inherits="TalkingWall.defaultPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="LeftCol" runat="server">
    <div class="module">
        <fieldset>
            <legend class="col-lg-offset-1">Post to Wall</legend>
            <div class="form-group">
                <div class="col-lg-offset-1">
                    <asp:TextBox CssClass="form-control" placeholder="Message" TextMode="MultiLine" runat="server" ID="WallInput" ClientIDMode="Static" />
                </div>
                </div>
                  <div class="form-group">
                      <div class="col-lg-offset-1">
                          <asp:TextBox runat="server" ID="WallName" CssClass="form-control" placeholder="User Name"  ClientIDMode="Static" />
                          <asp:Button Text="Post" style="margin-top:5px; float:right;" runat="server" ID="PostButton" OnClick="PostButton_Click" CssClass="btn btn-success bottom-right" />

                      </div>
                  </div>
        </fieldset>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainCol" runat="server">
    
    <div style="text-align: center">
        <asp:Repeater ID="WallRepeater" runat="server">
            <HeaderTemplate>
                <div class="active">
                    <span class="breadcrumb">The Wall</span>
                </div>
            </HeaderTemplate>
            <ItemTemplate>
                <div>
                    <div><%# DataBinder.Eval(Container.DataItem, "Message")%></div>
                    <div>
                        <span><%# DataBinder.Eval(Container.DataItem, "Name")%></span>
                        <span><%# DataBinder.Eval(Container.DataItem, "TimeStamp") %></span>
                    </div>
                </div>
            </ItemTemplate>
            <SeparatorTemplate>
                <div style="width: 100%; height: 25px;"></div>
            </SeparatorTemplate>
        </asp:Repeater>
        <asp:GridView ID="WallGrid" runat="server" Visible="False" CellPadding="4" ForeColor="#333333" GridLines="None">
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
    <div style="height:100%; border: red thin solid;">
        <asp:Button runat="server" ID="ClearButton" Text="Clear" CssClass="btn bottom-right" OnClick="ClearButton_Click" ClientIDMode="Static" style="float:right; vertical-align:bottom" />
    </div>
</asp:Content>
