<%@ Page Title="Database" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="DatabasePage.aspx.cs" Inherits="DatabasePage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <title>
        Database
    </title>

    <h1>
        DatabasePage
    </h1>
    <asp:Label ID="Label1" runat="server" Text="SubmitScrapedComics"></asp:Label> &nbsp


    <asp:Button ID="ExplosmLinqButton" runat="server" Text="ExplosmLinqButton" 
    onclick="ExplosmButton_Click" />


    <asp:Button ID="AnticsLinqButton" runat="server" Text="AnticsLinqButton" 
        onclick="AnticsLinqButton_Click" />

            <br />

    &nbsp
    &nbsp
    &nbsp
    &nbsp
    
    <br />
    <br />

    </asp:Content>

