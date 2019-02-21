# LookAndRun
A simple ASP.NET web-site for a company organizing sport-orienteering competitions.

## Main functions of the web-site:
1) Provide information regarding the games (dates, rules, latest race results, photos).
2) Provide customers with the option of regirstering for the upcoming game.
3) Provide customers with the info about all the registered (for the upconing game) teams.

Also, the web-site is a platform for adding temporary custom pages relevant for each particular game. 
All the data is stored in MSSQL database (configured in Web.config file). 

The architecture of the application is quite common, the whole structure is divided into three groups:
1) Data Access layer (folder DA) 
2) Business Logic layer (folder BL)
3) User Interface layer (root folder)

As the service is quite simple, the database contains only two tables:
- Games 
```
          Id:int- game identifier
          Data:int - game date
          Name:nvarchar(MAX) - game name
          Event:nvarchar(MAX) - corresponding Facebook event link 
          Photo:nvarchar(MAX) - corresponding Facebook photoalbum link
```
- Teams 
```
          Id:int - team identifier
          GameId:int - related game identifier
          Members:int - number of team members
          Name:nvarchar(MAX) -  team name
          Language:nvarchar(MAX) - preferable language for the team
          Mobile:nvarchar(MAX) - contact phone number of the team
          Result:nvarchar(MAX) - final result of the game for the team
```
