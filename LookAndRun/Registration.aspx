<%@ Page Title="Look&run" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Dozor.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   <img class="img-responsive" src="img/registration3.jpg" alt="">
   
<%--<h4><asp:Label ID="lClosed" runat="server" meta:resourceKey="Break" ForeColor="Red" Visible = "false"></asp:Label></h4>--%>


<h2><asp:Label ID="Label4" runat="server" meta:resourceKey="Registration" Visible="True" /><asp:Label ID="lDate" runat="server" Visible="True"></asp:Label></h2>


<p><asp:Label ID="lClosed" runat="server" meta:resourceKey="Closed" ForeColor="Red" Visible = "false"></asp:Label></p>

<div id="RegistrDiv" runat="server">
<form action="/" class="registration" id="reg_form">
    <div class="form-group">
        <input type="text" required id="teamname" name="team" runat="server">
        <label for="team-name">Team name <span class="required">*</span></label>
    </div>
    <div class="form-group">
        <input type="text" required id="mobilenumber" name="mobile" runat="server">
        <label for="mobile-number">Mobile number <span class="required">*</span></label>
    </div>
    <div class="form-group">
        <select required id="members" name="members" runat="server">
         <option value="1">1</option>
            <option value="2">2</option>
            <option value="3">3</option>
            <option value="4">4</option>
           <%-- <option value="5">5</option>
            <option value="6">6</option>--%>
        </select>
        <label for="member">Number of team members <span class="required">*</span></label>
    </div>
    <div class="form-group">
        <select required id="language" name="language" runat="server">
            <option value="EN">EN</option>
            <option value="RU">RU</option>
        </select>
        <label for="language">Prefered language for the tasks <span class="required">*</span></label>
    </div>
</form>
<h4><asp:Label ID="Label27" runat="server" meta:resourceKey="note" /></h4>
<ol class="rules">
   <li><asp:Label ID="Label1" runat="server" meta:resourceKey="note1" />
    </li>
    <li><asp:Label ID="Label2" runat="server" meta:resourceKey="note2" />
    </li>
    <li><asp:Label ID="Label3" runat="server" meta:resourceKey="note3" />
    </li>
</ol>

<button class="btn" type="submit" form="reg_form" runat="server"  onserverclick="Register_Click">Register</button>
</div>


</asp:Content>
