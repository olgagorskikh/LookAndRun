<%@ Page Title="Look&run" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="LastResults.aspx.cs" Inherits="WebApplication1.LastResults" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">


   <img class="img-responsive" src="../../img/results.jpg" alt="" />
                <h2><asp:Label ID="Header" runat="server" /></h2>
                
                <table class="results">
                    <thead>
                        <tr>
                            <td>№</td>
                            <td><asp:Label ID="TeamName" runat="server" meta:resourceKey="Name" /></td>
                            <td><asp:Label ID="Members" runat="server" meta:resourceKey="Result" /></td>
                        </tr>
                    </thead>
                    <tbody>
                       <% for (var i = 0; i < TeamList.Count;i++ )
                          {
                              var team = TeamList[i];
                             %>
                              <tr>
                                <td><%= i + 1%></td>
                                <td><%= team.Name%></td>
                                <td><%= team.Result%></td>
                              </tr>
                    <% } %>
                        
                    </tbody>
                    <tfoot>
                        <tr>
                            <td colspan="4">
                                <a id="fbLink" href="" runat="server">Facebook event</a>
                                <a id="fbPhoto" href="" runat="server">Photos</a>
                            </td>
                        </tr>
                    </tfoot>
                </table>
                
</asp:Content>
